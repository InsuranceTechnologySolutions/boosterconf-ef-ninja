# boosterconf-ef-ninja
Entity Framework Workshop 🥷

## Short DDD introduction

Slide-deck: [DDD - BoosterConf](https://instechas-my.sharepoint.com/:p:/g/personal/stig_nielsen_instech_no/EZCh10uwmQdNhL_lNy-pLm0B1-mP2juwa5-AD0KZ1ExSGg?e=780smi)


## The tasks
This repository is a template repository, so use this guide:

[Github - Creating a repository from a template](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template)

This repository cannot be forked. 

## The Requirements
These were mentioned in the outline for the workshop in the program, but outlining them here:

* YOU do need a local DBMS setup, preferably SQL Express or a developer edition of SQL Server. 
* MS SQL Server Management Studio. 
* A C# compliant IDE (We will be using Visual Studio 2022, patched to version 17.8.6). In a standard setup, you will then already have EF version 8.x installed. 
* Github account, or else using the template above will not work :boom:
* EF core Tools (but those should be installed as a part of Visual Studio)
    * EF Core CLI Tools ```dotnet tool install --global dotnet-ef```

### Task A - The basics
Ok, we have the initial setup, but something is off. 

Running the migrations (from the CLI):

```
dotnet ef migrations add InitialMigration
```
The output looks like this:

![Original Schema](/Images/Task_One_Original_Setup.png)

On first look, this looks fine, but I want you to fix a couple of things / bugs:

* One of the foreign key fields have "wrong name":

    ![Wrong field names](/Images/Wrong_FK_Name.png)

    Hint! The ...entity lacks the field which represents the FK. You can decorate that field property with an annotation [ForeignKey("NameOfField")] to make the Entity class easier to read (or if you have schemas which does not allow the ef core engine to naturally resolve these FK references).

* When running the initial migration above, there were some warnings written to the console. Get rid of them
    * The schemas now uses nvarchar(max) as type for the string fields.
    
        Hint! Look at the StringLength attribute. What should the appropriate values be?
    * Decimal precision is not specified. 
        Hint! Use the DecimalPrecision attribute. What is the appropriate value for our use cases?
    
* Indicies
    * Finding a customer by a FirstName, LastName combination will be common use case. Add a composite index consisting of these fields.


### Task B - More advanced features

You will probably have to run the same migrations multiple times, so a few helping snippets:

``` 
DROP DATABASE [BoosterConfEfNinjaTaskOne-TaskB]
```

```
dotnet ef migrations add InitialMigraton 
```

```
dotnet ef migrations remove
```


* Supporting multiple schemas 
    * We want to have a separate set of tables of Auditing. The schema (prefix) should be "Audit.". 
        * audit.Claims
        * audit.Covers
    
    Hint! Edit the AuditClaimEntityConfiguration.cs and AuditCoverEntityConfiguration.cs
    ```
    builder.ToTable("Claims", "audit"); //similar for audit.Covers
    ```

* Seeding lookup data in a migration. We need to seed the ClaimStatus table.


    | ID | Name      | Description |
    |----|-----------|-------------|
    | 1  | Submitted | The claim has been submitted and is awaiting review. |
    | 2  | In Review | The claim is currently being reviewed by an insurance adjuster. |
    | 3  | Approved  | The claim has been approved for payment. |
    | 4  | Rejected  | The claim has been rejected and will not be paid. |
    | 5  | Paid      | The claim has been paid to the policyholder. |

    Hint! EntityTypeBuilder has a "HasData" method:

    ```
    builer.HasData(new List<ClaimStatusEntity>
        new() { Id = 1, Name = "Submitted", Description = "The claim has been submitted and is..."},
        ...
    );
    ```


* Editing the migrations (adding your own stuff). 
    * Run custom queries (to fix bugs for instance)

    Hint! Create an empty migration, add your own custom content using this format:
    ```
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete dbo.ClaimStatus where ID = 5");
        }
    ```
    
### Task 3 - Inheritance

The model has changed slightly. Now there is a base claim, and to subtypes; LifeClaim and AutoClaim:

![Claim class diagram](/Images/Claim-models.jpeg)

We will cover the different types:

* TPH - one table per hierarchy (using a discriminator)
* TBT - table per type (the sub type specific fields are stored in separate tables)
* TPC - table per concrete type (all fields are stored in separate tables)

The concepts are explained here: [EF Core Inheritance](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance).

Note: Task C does not have a ".Solved" project, the output will be quite different based on the inheritance strategy you select, so this is just for you to experiment. 

#### TPH - This is the default setup, you do not have to do anything

#### TBT - Do the following:

```
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

```
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

Go to folder ```{repository root}/Scripts``` - copy paste the script into you ssms instance (or however you choose to run your DB scripts), run it. You now have as set of tables related to eachother, constraints already added ++

You should now have the DB schemas on your localDb:

![Task D Schemas](/Images/TaskD_Initial_Setup.png)

Open a terminal, navigate to the Task ```BoosterConf.Ef.Ninja\BoosterConf.Ef.Ninja.TaskD``` folder (it must be the folder where the .csproj file is located). Run the following command:

```
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BoosterConfEfNinjaTaskOne-TaskD" Microsoft.EntityFrameworkCore.SqlServer
```

More details on what happens in this article: [EF Core Scaffolding](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli)

Examine the output. Is this a good starting point for further development?

IMO: Some cleanup is required. The classes created as partial (they are not!), the DbContext is messy, I would move configuration of the entities into static files. But hey! That is up to you. 

This TaskD does not have a "Solved" project, the expected output is the same as TaskA.Solved. 

That's it! We hope you enjoyed the workshop! 

Thank you from Morten and Stig! 

![Instech Logo](/Images/instech_logo.png)