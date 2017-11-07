# Geco, (Ge)nerator (Co)nsole
Simple code generator based on a console project, running on .Net core and using C# interpolated strings.

Geco runs on .Net Core 2.0 [Download and Install](http://dot.net)

## Installation

Geco can be installed as `dotnet new` template. Run the following command on a console or terminal:

```Batchfile
dotnet new -i iQuarc.Geco.CSharp
```

Then create a new project using the newly installed template:

```Batchfile  
dotnet new geco
```

## Code Generation examples

From the included Entity Framework Core Reverse model generator:

![Geco Preview1](https://github.com/iQuarc/Geco/blob/dev/GecoResources/PreviewImage.JPG?raw=true)

From the included SQL Seed Scrip Generator:

![Geco Preview2](https://github.com/iQuarc/Geco/blob/dev/GecoResources/PreviewImage2.JPG?raw=true)

Running geco in interactive mode:

![Geco Preview3](https://github.com/iQuarc/Geco/blob/dev/GecoResources/PreviewImage3.JPG?raw=true)


## Description

Geco uses C# string interpolation as a template engine for code generation, in order to allow:

 - Easy customization of templates (Simply edit the .cs file)
 - Easy debugging (Place a breakpoint an run)
 - Easy extensibility (Add a new task by creating a new C# class and implement a simple interface `IRunnable`)
 
Geco uses tass discovery at runtime and each task is configured using Dependency Injection. The generation tasks can be run during build or from interactive mode (Debug Run).

## Included generators

The following generator tasks are included in current version.

 - Entity Framework Reverse model generator
 - SQL Seed data script generator (Generates MERGE scripts)
 - SQL Script runner
 - Database cleaner

## Customizing

1. The first customization option involves changing task parameters from `appsettings.json` configuration file. Each geco task defines it's own set of parameters (see the corresponding Options class):

```JSon
{
    "ConnectionStrings": {
        "DefaultConnection": "Integrated Security=True;Initial Catalog=AdventureWorks;Data Source=.\\SQLEXPRESS;"
    },
    "RunAtBuildTasks": [
        "Generate EF Core model"
    ],
    "Tasks": [
        {
            "Name": "Generate EF Core model",
            "TaskClass": "Geco.Database.EntityFrameworkCoreReverseModelGenerator",
            "BaseOutputPath": "..\\..\\Generated\\Model\\",
            "OutputToConsole": "false",
            "CleanFilesPattern": "*.cs",
            "Options": {
                "ConnectionName": "DefaultConnection",
                "Namespace": "Model",
                "OneFilePerEntity": true,
                "JsonSerialization": true,
                "GenerateComments": true,
                "UseSqlServer": true,
                "ConfigureWarnings": true,
                "GeneratedCodeAttribute": false,
                "NetCore": true,
                "ContextName":"AdventureworksContext"
            }
        }
    ]
}
```

2. By customizing existing templates directly.

3. By creating new code generation tasks as a C# class which implements the `IRunnable` interface.

`IRunnable` is a single method interface containing the `Run` method:

 ```CSharp
     /// <summary>
    /// Represents a runable task, for code generation or purposes or others
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Invoked when this task is executed
        /// </summary>     
 ```

A code generation class can be accompanied by an Option POCO class to hold options which can be customized from `appsettings.json`

Example:

```CSharp
    public class SeedDataGeneratorOptions
    {
        public string ConnectionName { get; set; }
        public string OutputFileName { get; set; }
        public List<string> Tables { get; } = new List<string>();
        public string TablesRegex { get; set; }
        public List<string> ExcludedTables { get; } = new List<string>();
        public string ExcludedTablesRegex { get; set; }
        public int ItemsPerStatement { get; set; } = 1000;
    }
        /// <summary>
    /// Generates seed scripts with merge statements for (Sql Server)
    /// </summary>
    [Options(typeof(SeedDataGeneratorOptions))]
    public class SeedDataGenerator : BaseGeneratorWithMetadata
    {
    // ...
    }
    
```
