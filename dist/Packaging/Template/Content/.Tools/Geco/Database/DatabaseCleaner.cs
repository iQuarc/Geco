using Geco.Common.Inflector;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Geco.Database;

/// <summary>
///    Deletes all the data in the specified database (SqlServer only) by disabling all triggers and constraints, deleting
///    the data then re-enabling them back.
/// </summary>
/// <remarks>
///    Deleting of data is done in a transaction, so either all data is deleted or none is.
/// </remarks>
[Options(typeof(DatabaseCleanerOptions))]
public class DatabaseCleaner(
   IConfigurationRoot     configurationRoot,
   DatabaseCleanerOptions options,
   IInflector             inf)
   : BaseGenerator(inf)
{
   private static readonly string where = "AND o.Name NOT IN (''sysdiagrams'', ''__RefactorLog''{0})";

   private static readonly string ctx =
      "SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS ON;SET NUMERIC_ROUNDABORT OFF;";

   private static readonly FormattableString[] Statements =
   {
      $@"EXEC sp_MSForEachTable @command1='{ctx}DISABLE TRIGGER ALL ON ?', @whereand='{where}'",
      $@"EXEC sp_MSForEachTable @command1='{ctx}ALTER TABLE ? NOCHECK CONSTRAINT ALL', @whereand='{where}'",
      $@"EXEC sp_MSForEachTable @command1='{ctx}DELETE FROM ?', @whereand='{where}'",
      $@"EXEC sp_MSForEachTable @command1='{ctx}ALTER TABLE ? CHECK CONSTRAINT ALL', @whereand='{where}'",
      $@"EXEC sp_MSForEachTable @command1='{ctx}ENABLE TRIGGER ALL ON ?', @whereand='{where}'",
      $@"EXEC sp_MSforeachtable @command1 = 'DBCC CHECKIDENT (''?'', RESEED, 0)', @whereand = 'AND EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id = o.ID AND c.is_identity = 1)'"
   };

   private readonly bool exit = false;

   protected override void Generate()
   {
      if (exit)
         return;
      var connectionString = configurationRoot.GetConnectionString(options.ConnectionName ?? "DefaultConnection");
      CleanDatabase(connectionString, options.TimeoutSeconds);
   }

   public void CleanDatabase(string connectionString, int timeoutSeconds)
   {
      using var cnn = new SqlConnection(connectionString);

      cnn.Open();
      using var tran = options.UseTransaction ? cnn.BeginTransaction() : null;

      foreach (var statement in Statements)
      {
         var tables = options.ExcludeTables.Count > 0
            ? ", " + string.Join(", ", options.ExcludeTables.Select(x => "''" + x + "''"))
            : "";
         var       sql = string.Format(statement.Format, ctx, string.Format(where, tables));
         using var cmd = new SqlCommand(sql, cnn, tran) { CommandTimeout = timeoutSeconds };

         WriteLine(("Running: ", Yellow),
            (string.Format(statement.Format, "", "***"), White));
         cmd.ExecuteNonQuery();
      }

      tran?.Commit();
   }

   public override bool GetUserConfirmation()
   {
      Write($"Are you sure you want to delete all data in the target database? (y/n):", White);
      return string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
   }
}