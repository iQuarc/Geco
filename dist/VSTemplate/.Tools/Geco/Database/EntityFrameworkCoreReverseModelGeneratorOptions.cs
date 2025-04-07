using System.Diagnostics.CodeAnalysis;

namespace Geco.Database;

[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class EntityFrameworkCoreReverseModelGeneratorOptions
{
   public string?                    ConnectionName { get; set; }
   public string?                    Namespace { get; set; }
   public List<string>               AdditionalNamespaces { get; set; } = new();
   public List<string>               ModelNamespaces { get; set; } = new();
   public bool                       OneFilePerEntity { get; set; } = true;
   public bool                       JsonSerialization { get; set; }
   public bool                       SerializableAttribute { get; set; } = true;
   public bool                       GenerateComments { get; set; } = true;
   public bool                       UseSqlServer { get; set; }
   public bool                       NullableCSharp { get; set; } = true;
   public bool                       ConfigureWarnings { get; set; }
   public bool                       DisableCodeWarnings { get; set; } = false;
   public bool                       GeneratedCodeAttribute { get; set; } = true;
   public bool                       FolderPerSchema { get; set; }
   public bool                       GenerateMappings { get; set; } = true;
   public bool                       GenerateEntities { get; set; } = true;
   public bool                       GenerateContext { get; set; } = true;
   public bool                       ConfigurationsInsideContext { get; set; } = false;
   public string?                    ContextName { get; set; }
   public List<string>               Tables { get; } = new();
   public string?                    TablesRegex { get; set; }
   public List<string>               ExcludedTables { get; } = new();
   public List<string>               FilteredTables { get; } = new();
   public string?                    ExcludedTablesRegex { get; set; }
   public HashSet<string>            ExcludedColumns { get; set; } = new(StringComparer.InvariantCultureIgnoreCase);
   public List<string>               ExcludeNavigation { get; set; } = new();
   public List<string>               ExcludeReverseNavigation { get; set; } = new();
   public List<string>               ExcludeReverseNavigationExcept { get; set; } = new();
   public bool                       AdvancedGeneration { get; set; }
   public List<ConvertOption>        ColumnTypes { get; set; } = new();
   public Dictionary<string, string> EntityNamespace { get; set; } = new();
   public Dictionary<string, string> NavigationNames { get; set; } = new();
   public string                     ClassInterfaceTemplate { get; set; } = "ClassInterfaces";
   public Dictionary<string, string> Enums { get; set; } = new();
}

public class ConvertOption
{
   public string? ColumnName    { get; set; }
   public string? TypeName      { get; set; }
   public string? TypeConverter { get; set; }
   public string? ValueComparer { get; set; }
}