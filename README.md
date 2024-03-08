# Become an Entity Framework Ninja 🥷

Slide-deck: [DDD - BoosterConf](https://instechas-my.sharepoint.com/:p:/g/personal/stig_nielsen_instech_no/EZCh10uwmQdNhL_lNy-pLm0B1-mP2juwa5-AD0KZ1ExSGg?e=780smi)

## The tasks
This repository is a template repository, so use this guide:

[Github - Creating a repository from a template](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template)

This repository cannot be forked. 

## The Requirements
These were mentioned in the program, but in case you are not running on Windows or think Microsoft has enough monopoly over development tools, we have given you some alternatives.
We assume that if you don't really know much about DB design, you stick with defaults (in bold). This is what you will need:

* a GitHub account, or else using the template above will prove difficult :boom:
* [.NET SDK](https://dotnet.microsoft.com/en-us/download) - this is the crux of our exercise. Make sure you at least have this installed.
* IDE for C# (We will be using Visual Studio 2022, with latest updates). In a standard setup, you will then already have EF version 8.x installed. Alternatives:
    - JetBrains Rider
    - VS Code + dotnet CLI
* **[MS SQL SERVER - Developer](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)** - there are alternatives, but this workshop is designed for MS SQL Server, so try and stick with it.
* **[MS SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)** or another SQL Management tool. Some alternatives:
    - [Azure Data Studio](https://learn.microsoft.com/en-us/azure-data-studio/download-azure-data-studio). Great minimal tool, but doesn't allow for a lot of advanced automations or diagram generation.
    - [DBeaver](https://dbeaver.io/download/) - Open source and works with a lot of database engines, not just MS SQL.
    - Visual Studio or JetBrains Rider have builtin tools. VS Code extensions also can be used for this as well, but are not as well supported.
* [EF core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools) - those should be installed as a part of Visual Studio, but make sure you can run `dotnet ef` or `dotnet-ef` 

Maximum preparedness checklist:
- You can navigate into the solution folder and run `dotnet build` - this means you have setup .NET correctly
- You can connect to sql local DB via your database management tool of choice
- `dotnet ef` (or `dotnet-ef`) runs successfully. This means you installed the EntityFramework tools correctly.

> ### Note for non-windows users
> There is a docker-compose.yml available, if you want to avoid hosting the SQL server locally, but it [might not work](https://github.com/microsoft/mssql-docker/issues/868)
> on latest linux kernel. If you want to use it, you need to do the following:
>
> - `docker-compose up -d` in the root of the solution.
> - Change the connection strings to `Server=localhost;Database=EfNinja;User Id=sa;Password=P@ssw0rd!;Encrypt=False`.
> You can find them in the `appsettings.json` in `*.Database` and `*.Api` project.
> - When you are done, `docker-compose down` in the root of the solution.


### Task A - The Basics

---
 **What is EF (really):** 
 
 It is a powerful Object-Relational Mapping framework for .NET. It enables you (as a dev) to focus on the domain specific models/stuff, without having to think too much about the underlying database tables and columns. 

 One of the key features is the code first approach. You do **everything** in C# / VB.Net. EF will then do the heavy lifting for you and create the DDL queries / scripts for you which will create the DB schemas for you. 
 
 Migrations is another powerful feature. It keeps you database schemas (tables ++) in synch with your EF C# models and preserving data between changes. When you change your models, EF will figure out the difference between your current model and the existing schema and update the database accordingly. You can basically do whatever you want, and the migrations will also enable you to rollback changes if needed. 

 ---

Ok, we have the initial setup, but something is off. We are missing the migrations in our dotnet solution.

Scaffolding the migrations (from the CLI):

```bash
dotnet ef migrations add InitialMigration
```
This command generates a migration C# file alongside the current snapshot of the database schema in your
project under `Migrations`.

If you need to redo something, you can always remove the most recent migration:

```bash
dotnet ef migrations remove
```

> **NOTE:** Only migrations not applied to the DB can be removed. In our workshop, just delete the database if this prevents you from removing a migration. You can do that in the context meny in SQL Management Studio (delete), or by running ```DROP DATABASE <NAME_OF_DB>```.

In order to apply the migration, you need to run:

```bash
dotnet ef database update
```
This will have updated the schema for the database. If you then inspect the schema for your database using your
management studio, it should looks like this:

![Original Schema](/Images/Task_One_Original_Setup.png)

On first look, this looks fine, but I want you to fix a couple of things / bugs:

* One of the foreign key fields in Claims has a name not adhering to standard (CoverEntityId):

    ![Wrong field names](/Images/Wrong_FK_Name.png)

    Hint! The ClaimsEntity lacks the (navigation) property which represents the FK. You can also decorate that field with an annotation `[ForeignKey("CoverId")]` to make the Entity class easier to read (or if you have schemas which does not allow the ef core engine to naturally resolve these FK references).

* When running the initial migration above, there were some warnings written to the console. Get rid of them:
    * The schemas now uses nvarchar(max) as type for the string fields. This has a performance penalty.
    
        Hint! Look at the StringLength or MaxLength attribute (these are equivalent in ef core). What should the appropriate values be?
    * Decimal precision is not specified. 
        Hint! Use the DecimalPrecision attribute. What is the appropriate value for our use cases?
    
* Indexes (or Indicies if you are pedantic about the terminology)
    * Finding a customer by a FirstName, LastName combination will be common use case. Add a composite index consisting of these fields.

### Task B - More advanced features

You will probably have to run the same migrations multiple times, so a few helpful snippets:

```sql
-- Drop existing database. Make sure you are not connected to it, or else it might get locked.
-- Naturally, you gotta run it inside SQL management studio
DROP DATABASE [BoosterConfEfNinjaTaskOne-TaskB]
```

```bash
# Regenerate the migration
dotnet ef migrations add InitialMigraton 
```

```bash
# This removes the latest migration, if it wasn't applied
dotnet ef migrations remove
```

* Supporting multiple schemas names (prefixes apart from dbo.*)
    * We want to have a separate set of tables of Auditing. The schema (prefix) should be "Audit.". 
        * `audit.Claims`
        * `audit.Covers`
    
    Hint! Edit the AuditClaimEntityConfiguration.cs and AuditCoverEntityConfiguration.cs
```csharp
builder.ToTable("Claims", "audit"); //similar for audit.Covers
```

* Seeding lookup data in a migration. We need to seed the ClaimStatus table.

```
| ID | Name      | Description |
|----|-----------|-------------|
| 1  | Submitted | The claim has been submitted and is awaiting review. |
| 2  | Approved  | The claim has been approved for payment. |
| 3  | Paid      | The claim has been paid to the policyholder. |
```
Hint! EntityTypeBuilder has a "HasData" method:

```csharp
modelBuilder
    .Entity<ClaimStatusEntity>()
    .HasData([
        new()
        {
            Id = 1, ExternalId = new("d578489e45e04ff89ef65b529ed5d95c"), 
            Name = "Submitted",
            Description = "The claim has been submitted and is awaiting review."
        },
        // ...
    ]);
```

* Editing the migrations (adding your own stuff). 
* Run custom queries (to fix bugs for instance)

Hint! Create an empty migration, add your own custom content using this format:
```csharp
protected override void Up(MigrationBuilder migrationBuilder)
{
    // Basically you can run any query as a part of a migration.
    // I often use this to provision views/procedures and other resources if needed.
    migrationBuilder.Sql("UPDATE dbo.ClaimStatus SET [Name] = 'Paid Out' WHERE Id = 3");
}
```
    
### Task 3 - Inheritance

The model has changed slightly. Now there is a base claim, and two subtypes `LifeClaim` and `AutoClaim`:

![Claim class diagram](/Images/Claim-models.jpeg)

We will cover the different types:

* TPH - one table per hierarchy (using a discriminator)
* TBT - table per type (the sub type specific fields are stored in separate tables)
* TPC - table per concrete type (all fields are stored in separate tables)

The concepts are explained here: [EF Core Inheritance](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance).

Note: Task C does not have a ".Solved" project, the output will be quite different based on the inheritance strategy you select, so this is just for you to experiment. 

#### TPH - This is the default setup, you do not have to do anything

#### TBT - Do the following:

```csharp
//In ClaimEntityConfiguration.cs
builder.ToTable("Claims"); //this is stating the obvious, but we need to be explicit

//In AutoClaimEntityConfiguration.cs
builder.ToTable("AutoClaims");

//In LifeClaimEntityConfiguration.cs
builder.ToTable("LifeClaims");
```

The expected output after running the migrations:

![Table-Per-Type](/Images/Table-Per-Type.png)

#### TPC - Do the following:

```csharp
//In ClaimEntityConfiguration.cs
builder.ToTable("Claims").UseTpcMappingStrategy();

//In AutoClaimEntityConfiguration.cs
builder.ToTable("AutoClaims").UseTpcMappingStrategy();

//In LifeClaimEntityConfiguration.cs
builder.ToTable("LifeClaims").UseTpcMappingStrategy();
```

The expected output after running the migrations:

![Table-Per-Concrete-Type](/Images/Table-Per-Concrete-Type.png)

### Task 4 - Scaffolding

There are certain scenarios where you start out with a set of schemas already existing. What to do then and how to move into a code-first setup?

Go to folder ```{repository root}/Scripts``` - copy paste the script into you ssms instance (or however you choose to run your DB scripts), run it. You now have as set of tables related to each other, constraints already added ++

You should now have the DB schemas on your localDb:

![Task D Schemas](/Images/TaskD_Initial_Setup.png)

Open a terminal, navigate to the Task ```BoosterConf.Ef.Ninja\BoosterConf.Ef.Ninja.TaskD``` folder (it must be the folder where the .csproj file is located). Run the following command:

```bash
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EfNinja-TaskD" Microsoft.EntityFrameworkCore.SqlServer
```

More details on what happens in this article: [EF Core Scaffolding](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli)

Examine the output. Is this a good starting point for further development?
IMO: Some cleanup is required. The classes created as partial (they are not!), the DbContext is messy, I would move configuration of the entities into static files. But hey! That is up to you.
This TaskD does not have a "Solved" project, the expected output is the same as TaskA.Solved.

That's it! We hope you enjoyed the workshop! Thank you from Eugene and Stig!

![Instech Logo](/Images/instech_logo.png)
