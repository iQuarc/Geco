using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using Geco.Common.Inflector;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Geco.Database;

[Options(typeof(SeedScriptRunnerOptions))]
public class SeedScriptRunner : BaseGeneratorWithMetadata
{
   private readonly IConfigurationRoot      configurationRoot;
   private readonly SeedScriptRunnerOptions options;

   public SeedScriptRunner(SeedScriptRunnerOptions options, IConfigurationRoot configurationRoot,
      IMetadataProvider                            metadataProvider,
      IInflector                                   inf) : base(metadataProvider, inf, options.ConnectionName)
   {
      this.options           = options;
      this.configurationRoot = configurationRoot;
   }

   protected override void Generate()
   {
      string currentFileName = null;
      try
      {
         foreach (var fileName in options.Files)
         {
            currentFileName = fileName;
            RunScripts(Path.Combine(BaseOutputPath, fileName));
         }
      }
      catch (Exception ex)
      {
         WriteLine(("Error running merge script:", Red), (currentFileName, Yellow));
         WriteLine($"{ex}", DarkRed);
      }
   }

   private void RunScripts(string file)
   {
      WriteLine($"Running scripts from: {(file, Yellow)}", Gray);
      var connectionString = configurationRoot.GetConnectionString(options.ConnectionName);
      if (!File.Exists(file))
      {
         WriteLine($"File:[{(Path.GetFullPath(file), Yellow)}] does not exit on disk. {("Skipping!", Red)}",
            Gray);
         return;
      }

      using (var f = OpenFile(file))
      using (var cnn = new SqlConnection(connectionString))
      {
         cnn.Open();
         SqlTransaction tran = null;
         if (options.OpenTransaction)
            tran = cnn.BeginTransaction();

         foreach (var inf in AddFkGuards(Filter(GetCommands(f))).WithInfo())
         {
            if (inf.Index < options.StartIndex)
               continue;

            var commandText = inf.Item;
            using (var cmd = new SqlCommand(commandText.Command, cnn, tran)
                      { CommandTimeout = options.CommandTimeout })
            {
               Write($"{commandText.TableName}", Cyan);
               var affectedRows = cmd.ExecuteNonQuery();
               WriteLine(($" ({affectedRows} row(s) affected)", White), ($" N:{inf.Index}", Gray));
            }
         }

         if (options.OpenTransaction)
            tran.Commit();
         Console.WriteLine();
         Console.WriteLine();
      }
   }

   private StreamReader OpenFile(string fileName)
   {
      if (fileName.EndsWith(".gz"))
         return new StreamReader(new GZipStream(File.OpenRead(fileName), CompressionMode.Decompress), Encoding.UTF8);

      return File.OpenText(fileName);
   }

   private IEnumerable<(string Command, string TableName)> GetCommands(StreamReader streamReader)
   {
      var tableName = "";
      var buffer    = new StringBuilder();
      while (!streamReader.EndOfStream)
      {
         var line = streamReader.ReadLine();
         if (string.IsNullOrWhiteSpace(line))
            continue;

         var tableMatch = Regex.Match(line, @"\s*MERGE\s*(.*)\s+AS");
         if (tableMatch.Success)
            tableName = tableMatch.Groups[1].Value;

         if (Regex.IsMatch(line, @"^\s*-{0,2}GO\s*$"))
         {
            if (buffer.Length > 0)
               yield return (buffer.ToString(), tableName);
            buffer.Clear();
            tableName = "";
         }
         else
         {
            buffer.AppendLine(line);
         }
      }
   }

   private IEnumerable<(string Command, string TableName)> Filter(
      IEnumerable<(string Command, string TableName)> source)
   {
      if (options.ExcludedTables.Count != 0)
         source = source.Where(x =>
            options.ExcludedTables.All(e => !string.Equals(e, x.TableName, StringComparison.OrdinalIgnoreCase)));

      if (!string.IsNullOrEmpty(options.ExcludedTablesRegex))
         source = source.Where(x => !Regex.IsMatch(x.TableName, options.ExcludedTablesRegex, RegexOptions.IgnoreCase));

      return source.Where(x => Db.Find<Table>(x.TableName) != null);
   }

   private IEnumerable<(string Command, string TableName)> AddFkGuards(
      IEnumerable<(string Command, string TableName)> source)
   {
      if (!options.AddFKGuards)
         return source;

      return source.Select(tuple =>
      {
         var (command, tableName) = tuple;
         var c      = new Regex(@"Source\s+\((\[(?<c>[\w@$#_\s]+)\],?\s*)+\)");
         var r1     = new Regex(@"(WHEN\sMATCHED)\s(THEN)");
         var r2     = new Regex(@"(WHEN\sNOT\sMATCHED)\s(THEN)");
         var filter = new StringBuilder();
         var cols   = c.Match(command).Groups["c"].Captures.Select(c => c.Value).ToHashSet();

         foreach (var fk in Db.Find<Table>(tableName).ForeignKeys)
         foreach (var fkcols in fk.FromColumns.Zip(fk.ToColumns).Where(x => cols.Contains(x.First.Name)))
            filter.Append(
               $" AND (Source.[{fkcols.First.Name}] IS NULL OR EXISTS( SELECT 1 FROM {fk.TargetTable.FullyQualifiedName} WHERE {fkcols.Second.Name} = Source.[{fkcols.First.Name}]))");

         command = r1.Replace(command, $"$1{filter} $2");
         command = r2.Replace(command, $"$1{filter} $2");
         return (command.Replace("\r", ""), tableName);
      });
   }
}