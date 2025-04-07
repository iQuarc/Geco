namespace Geco.Database;

public class DatabaseCleanerOptions
{
   public string?      ConnectionName { get; set; }
   public int          TimeoutSeconds { get; set; }
   public bool         UseTransaction { get; set; } = true;
   public List<string> ExcludeTables  { get; set; } = new();
}