# Become an Entity Framework Ninja 🥷

Slide-deck: [DDD - BoosterConf](https://instechas-my.sharepoint.com/:p:/g/personal/stig_nielsen_instech_no/EZCh10uwmQdNhL_lNy-pLm0B1-mP2juwa5-AD0KZ1ExSGg?e=780smi)

## The tasks
This repository is a template repository, so use this guide:

[Github - Creating a repository from a template](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template)

***NOTE***: When creating your own repository, you must include all branches.

![Inclue All Branches](/Images/Include_All_Branches.png)

This repository should not be forked.

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

> ### Note for people who prefer docker or don't run windows
> There is a docker-compose.yml available, if you want to avoid hosting the SQL server locally, but it [might not work](https://github.com/microsoft/mssql-docker/issues/868)
> on latest linux kernel. If you want to use it, you need to do the following:
>
> - `docker-compose up -d` in the root of the solution.
> - `cd` into the `*.Database` or `*.Api` project and set the connection string to your DB with:
> ```bash
> dotnet user-secrets set "ConnectionStrings:InsuranceDb" "Server=localhost;Database=EfNinja;User Id=sa;Password=P@ssw0rd!;Encrypt=False"`.
> ````
> - When you are done with the workshop, `docker-compose down` in the root of the solution.
> - If you have questions, find one of us before the workshop and we can help you figure it out.

Maximum preparedness checklist:
- You can navigate into the solution folder and run `dotnet build` - this means you have setup .NET correctly
- You can connect to sql local DB via your database management tool of choice
- `dotnet ef` (or `dotnet-ef`) runs successfully. This means you installed the EntityFramework tools correctly.

## Before we start
1. If you feel lost at any point during the workshop, ask us or knowledgeable people around you.
2. In case you want to skip a task and get back to it later, you can always use one of the `checkpoints` that we have setup for you:
```bash
# Stash or commit your code to git
git add .
git commit -m "My work!"

# This will restore the codebase to the state where task B has just been completed.
git checkout checkpoint/task-b-done
```

Note! This will only work if you included all branches when creating the repo from template.

### Task A - The Basics
> The goal of this task is to get familiar with how to create DB schemas based on the csharp entities and how to configure them.

---
#### What is EF (really)

 It is a powerful Object-Relational Mapping framework for .NET. It enables you (as a dev) to focus on the domain specific models/stuff, without having to think too much about the underlying database tables and columns.

 One of the key features is the code first approach. You do **everything** in C# / F#. EF will then do the heavy lifting for you and create the DDL queries / scripts for you which will create the DB schemas for you.

#### DbContext
This is the representation of the database schema in C#. This is the entry point for any database interaction and it contains the definitions for tables (or `DbSet`s), configuration for schema (In form of actions specified in `OnModelCreating`) and more.

If you want your C# code to interact with the database, you do so through injecting and using an instance of `DbContext`. You usually subclass the base `DbContext` and specify schema specific to your application.


#### Migrations
Is a mechanism of EF which help sync your C# models and database schema, preserving data between changes. When you change your models, EF will figure out the difference between your current model and the existing schema and update the database accordingly. You can basically do whatever you want, and the migrations will also enable you to rollback changes if needed.

 ---

Ok, we have the initial setup, but something is off. We are missing the migrations in our dotnet solution.

Scaffolding the migrations (from the CLI):

```bash
dotnet ef migrations add InitialMigration
```

> **NOTE:** All CLI commands, as the one above, has to be run from the folder where `*.Database` project is.

This command generates a migration C# file alongside the current snapshot of the database schema in your
project under `Migrations`.

If you need to redo something, you can always remove the most recent migration:

```bash
dotnet ef migrations remove
```

> **NOTE:** Only migrations not applied to the DB can be removed. In our workshop, just delete the database if this prevents you from removing a migration. You can do that in the context menu in SQL Management Studio (delete), or by running ```DROP DATABASE <NAME_OF_DB>```.

In order to apply the migration, you need to run:

```bash
dotnet ef database update
```
This will have updated the schema for the database. If you then inspect the schema for your database using your
management studio, it should looks like this:

![Original Schema](/Images/Task_One_Original_Setup.png)

On first look, this looks fine, but I want you to fix a couple of things / bugs:

> **Note**: All code changes are done within the `*.Database` project(s).

* One of the foreign key fields in Claims has a name not adhering to convention (the name is `CoverEntityId`, but our convention is `CoverId`):

    ![Wrong field names](/Images/Wrong_FK_Name.png)

    ```
    Hint! The ClaimsEntity lacks the (navigation) property which represents the FK. You can also decorate that field with an annotation `[ForeignKey("CoverId")]` to make the Entity class easier to read (or if you have schemas which does not allow the ef core engine to naturally resolve these FK references).
    ```

* When running the initial migration above, there were some warnings written to the console (yellow squiggly lines in your IDE). Get rid of them:
    * The schemas are using nvarchar(max) as type for the string fields by default. This has a performance penalty. We want to limit the size of those strings for optimisation reasons.
        ```
        Hint! Look at the StringLength or MaxLength attribute (these are equivalent in ef core). What should the appropriate values be?

        You can also do this in DbContext's OnModelCreating.
        ```
    * Decimal precision is not specified.
        ```
        Hint! Use the DecimalPrecision attribute. What is the appropriate value for our use cases?
        ```

* Indicies
    * Finding a customer by a FirstName, LastName combination will be common use case. Add a composite index consisting of these fields.
        ```
        Hint! Try messing with modelBuilder in OnModelCreating.
        You can attach an index to an Entity of a given type.
        ```


### Task B - More advanced features
> The goal of this task is to partition data into different schemas (perhaps based on different bounded context). Also showing how to seed data (value-objects) through migrations.

You will probably have to run the same migrations multiple times, so a few helpful snippets.

```sql
-- Drop existing database. Make sure you are not connected to it, or else it might get locked.
-- Naturally, you gotta run it inside SQL management studio
DROP DATABASE [EfNinja]
```
You can do this if you mess the migration up and want to regenerate it.

```bash
# Regenerate the migration
dotnet ef migrations add InitialMigraton
```

```bash
# This removes the latest migration, if it wasn't applied
dotnet ef migrations remove
```

* Sometimes it is useful to split the data into multiple sub-schemas in the same database. You can use to distinguish between different bounded contexts. In our scenario, we have two tables which need extra attention because they contain Personal Identifiable Information (PII).

    * We want to move our data into a separate schema. The schema (prefix) should be `insurance`. Like this:
        * `insurance.Claims`
        * `insurance.Covers`
        * ...
    * The non-insurance stuff (PII) should be in `pii` schema:
        * `pii.Customers`
        * `pii.CustomerAddresses`

    ```
    Hint! You can set the default schema name for the entire DbContext
    with .HasDefaultSchema(...) and for individual tables by using [Table(...)] annotations.

    Check OnModelCreating in DbContext.
    ```

* Seeding lookup data in a migration. We need to seed the ClaimStatus table.

```
| ID | Name      | Description |
|----|-----------|-------------|
| 1  | Submitted | The claim has been submitted and is awaiting review. |
| 2  | Approved  | The claim has been approved for payment. |
| 3  | Paid      | The claim has been paid to the policy holder. |
```

```csharp
// Hint! EntityTypeBuilder has a "HasData" method:
modelBuilder
    .Entity<ClaimStatusEntity>()
    .HasData([
        new()
        {
            Id = 1,
            ExternalId = new("d578489e45e04ff89ef65b529ed5d95c"),
            Name = "Submitted",
            Description = "The claim has been submitted and is awaiting review."
        },
        // ...
    ]);
```

* Sometimes you need to make empty migrations which you fill manually. This could be useful to fix mistakes or run custom SQL not supported by EF.

```csharp
// Hint! you can run any query as a part of a migration.
// We often use this to provision views/procedures and other resources if needed or just mess with data.
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql("UPDATE dbo.ClaimStatus SET [Name] = 'Paid Out' WHERE Id = 3");
}

// Don't forget to include Down in case this migration needs to be reverted!
```

### Task C - Inheritance
> The goal of this task is to demonstrate the different inheritance strategies available in Entity Framework.

The model has changed slightly. Now there is a base claim, and two subtypes `LifeClaimEntity` and `AutoClaimEntity`:

![Claim class diagram](/Images/Claim-models.jpeg)

```csharp
// Add these to your ClaimEntity.cs
public class AutoClaimEntity : ClaimEntity
{
    [MaxLength(length: 32)]
    public required string VehicleId { get; set; }

    [MaxLength(length: 512)]
    public required string AccidentReport { get; set; }

    [Precision(14, 2)]
    public required decimal RepairEstimate { get; set; }
}

public class LifeClaimEntity : ClaimEntity
{
    [MaxLength(length: 128)]
    public required string PolicyHolderName { get; set; }

    [MaxLength(length: 128)]
    public required string BeneficiaryName { get; set; }

    [MaxLength(length: 32)]
    public required string DeathCertificate { get; set; }
}
```
By convention, EF will not automatically scan for base or derived types; this means that if you want a CLR type in your hierarchy to be mapped, you must explicitly specify that type on your model.
You can do this through one of multiple ways:
- Setup the base types in the model configuration:
```csharp
    // In OnModelCreating:
    modelBuilder.Entity<AutoClaimEntity>().HasBaseType<ClaimEntity>();
    modelBuilder.Entity<LifeClaimEntity>().HasBaseType<ClaimEntity>();
```
- Have an explicit DB set of that type in your context:
```csharp
    // In DbContext:
    public DbSet<LifeClaimEntity> LifeClaims => Set<LifeClaimEntity>();
    public DbSet<AutoClaimEntity> AutoClaims => Set<AutoClaimEntity>();
```
Which way you choose is up to you. We prefer the model configuration since it is cleaner, but if you need to query each type separately, it might be a better fit.

Inheritance like this can be represented in your DB schema, and so EntityFramework supports the following strategies:

* Table per Hierarchy (TPH) - using a discriminator field and a single table
* Table per Type (TPT) - common fields are stored in the base table and type-specific fields are in their own tables.
* Table per Concrete Type (TPC) - All types are stored separately with all of their fields.

The concepts are explained here: [EF Core Inheritance](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance).

Note: Task C only has one checkpoint variant (for TPT) and is available on `checkpoint/task-c-done`. You are encouraged to try the other strategies by yourself.

#### Table per Hierarchy
This is the default setup, you do not have to do anything.

Create a migration, apply it and examine the schema in your database management tool.

When done, Drop the DB, remove the migration to start fresh trying the other strategies. The order is important.

```sql
DROP DATABASE [EfNinja]
```

```csharp
dotnet ef migrations remove
```

#### Table per Type

You need to configure that different entities map to different tables. EF will map the tables with FKs.

```csharp
// In OnModelCreating method in DbContext:
modelBuilder.Entity<AutoClaimEntity>().ToTable("AutoClaims");
modelBuilder.Entity<LifeClaimEntity>().ToTable("LifeClaims");
```
Note that you don't need to map the base table. Also note that you still only have one `DbSet` of the base type.

The expected output after running the migrations:

![Table-Per-Type](/Images/Table-Per-Type.png)

Note that Id field of AutoClaims and LifeClaims also act as Foreign Keys.

> When done, Drop the DB, remove the migration to start fresh trying the remaining strategy.

```sql
DROP DATABASE [EfNinja]
```

```csharp
dotnet ef migrations remove
```

#### Table per Concrete Type

> Creating a migration for TPC inheritance can be problematic. Most likely you have to DROP the DB, remove all migration files and create a new initial migration.
If not you will most likely get this error message ```To change the IDENTITY property of a column, the column needs to be dropped and recreated.```

This will generate a table per each concrete type in the hierarchy and duplicate all of the properties from base types.
This is by far the newest type of inheritance supported by EF. It can sometimes be quirky, so don't get discouraged if 
it doesn't work :)

```csharp
modelBuilder.Entity<ClaimEntity>().UseTpcMappingStrategy().ToTable("Claims");
modelBuilder.Entity<AutoClaimEntity>().ToTable("AutoClaims");
modelBuilder.Entity<LifeClaimEntity>().ToTable("LifeClaims");
```

The expected output after running the migrations:

![Table-Per-Concrete-Type](/Images/Table-Per-Concrete-Type.png)

### Task D - Scaffolding the Database First approach
> The goal is to demonstrate the EF scaffolding command and explain what it does. Has a big potential when migrating legacy code / database migrations to a new code base based on csharp / entity framework.

This task is a bit different from the others - it will not be based on the previous task(s). And if we are short on time, you can do this task later on your own if you like.

There are certain scenarios where you start out with a set of schemas already existing. What do you do then and how do you migrate to using entity framework for schema management?

Go to folder ```{repository root}/Scripts``` - copy paste the script into you ssms instance (or however you choose to run your DB scripts), run it. You now have as set of tables related to each other, constraints and all.

If you inspect the schema in your localDb, it should look like this:

![Task D Schemas](/Images/TaskD_Initial_Setup.png)

To start scaffolding, let us create a separate project for the new database infrastructure.
- In your IDE, create a new `classlib` project: `BoosterConf.Ef.Ninja.DbFirstDatabase`
- Install the following Nuget packages:
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.SqlServer
```bash
# Hint! You can use dotnet CLI for this. Go to the solution folder and use the CLI:
# Make the project:
mkdir BoosterConf.Ef.Ninja.DbFirstDatabase
cd BoosterConf.Ef.Ninja.DbFirstDatabase
dotnet new classlib
rm Class1.cs

# Add the Nuget packages
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# Add project to solution:
cd ..
dotnet sln add BoosterConf.Ef.Ninja.DbFirstDatabase
```

You should now have an empty project into which we are going to scaffold our infrastructure.

Open a terminal, navigate to the project ```BoosterConf.Ef.Ninja\BoosterConf.Ef.Ninja.DbFirstDatabase``` and run the following command:

```bash
# Make sure you are using the correct connection string if using docker.
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EfNinja-TaskD" Microsoft.EntityFrameworkCore.SqlServer
```

More details on what happens in this article: [EF Core Scaffolding](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli)

Examine the output. Is this a good starting point for further development?
IMO: Some cleanup is required. The classes created as partial (they are not!), the DbContext is messy, there are connection strings in there and many more issues for you to tackle, but it is a good start!

### The end
That's it! We hope you enjoyed the workshop!
Thank you from Eugene and Stig!

![Instech Logo](/Images/instech_logo.png)
