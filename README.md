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

### Task 1 - The basics
Ok, we have the initial setup, but something is off. 

Running the migrations (from the CLI):

```
dotnet ef migrations add InitialMigration
```
The output looks like this:

![Wrong Schema](/Images/Ninja_WrongSchema_Task1.png)

The models are quite simple. But for the different types, you should add the following constraints:

* Table ..., add a unique constraint on field ...
* Foreign key relationships using annotations. 





### Task 2 - More advanced features

* Manipulating the migrations (adding your own stuff). 
    * Run custom queries
    * Seeding




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

Read this article on how to run the scaffolding command

..

Examine the output. Is this a good starting point for further development?


