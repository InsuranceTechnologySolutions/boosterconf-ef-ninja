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

Also, this project contains multiple DbContext to support multiple schemas. When adding the migration(s), you will get a warning if not using the --context switch:

```
dotnet ef migrations add InitialMigraton --context InsuranceDbContext
dotnet ef migrations add InitialMigraton --context AuditDbContext
```

```
dotnet ef migrations remove --context InsuranceDbContext
```

```
dotnet ef migrations remove --context AuditDbContext
```

* Supporting multiple schemas 
    * We want to have a separate set of tables of Auditing. The schema (prefix) should be "Audit.". 
        * Audit.Claim
        * Audit.Cover
    
    Hint! Edit the AuditClaimEntityConfiguration.cs and AuditCoverEntityConfiguration.cs
    ```
    builder.ToTable("Claim", "audit"); //similar for audit.Cover
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

We will cover the different types:

* TPH - one table per hierarchy
* TBT - table per type
* TPC - table per concrete type

### Task 4 - Performance tips

The current code needs to be refactored. The following queries are not performing well, can you see why?

* Class.cs, lines x-xx
* Class2.cs, lines x-xx
* Class3.cs, lines x-xx

### Task 5 - Scaffolding

There are certain scenarios where you start out with a set of schemas already existing. What to do then and how to move into a code-first setup?

Go to folder /Script - copy paste the script into you ssms instance (or however you choose to run your DB scripts), run it. You now have as set of tables related to eachother, constraints already added ++

Open a terminal, navigate to folder ....

´´´

´´´

More details on what happens in this article: 

Examine the output. Is this a good starting point for further development?