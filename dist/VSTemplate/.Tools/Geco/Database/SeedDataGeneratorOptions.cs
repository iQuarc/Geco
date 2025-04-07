namespace Geco.Database;

public class SeedDataGeneratorOptions
{
   public string?                    ConnectionName      { get; set; }
   public string?                    OutputFileName      { get; set; }
   public List<string>               Tables              { get; } = new();
   public string?                    TablesRegex         { get; set; }
   public List<string>               DeleteTables        { get; } = new();
   public string?                    DeleteTablesRegex   { get; set; }
   public List<string>               ExcludedTables      { get; } = new();
   public string?                    ExcludedTablesRegex { get; set; }
   public int                        ItemsPerStatement   { get; set; } = 1000;
   public string?                    FilterTemplate      { get; set; }
   public bool                       Compressed          { get; set; } = false;
   public bool                       SkipEmpty           { get; set; } = true;
   public string                     Filter              { get; set; } = "";
   public Dictionary<string, string> TableFilters        { get; }      = new();
}