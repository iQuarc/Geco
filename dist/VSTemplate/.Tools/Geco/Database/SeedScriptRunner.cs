using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Geco.Common;
using Microsoft.Extensions.Configuration;
using static System.ConsoleColor;
using static Geco.Common.ColorConsole;

namespace Geco.Database
{
    [Options(typeof(SeedScriptRunnerOptions))]
    public class SeedScriptRunner : BaseGenerator
    {
        private readonly IConfigurationRoot configurationRoot;
        private readonly SeedScriptRunnerOptions options;

        public SeedScriptRunner(SeedScriptRunnerOptions options, IConfigurationRoot configurationRoot,
            IInflector inf) : base(inf)
        {
            this.options = options;
            this.configurationRoot = configurationRoot;
        }

        protected override void Generate()
        {
            string currentFileNamme = null;
            try
            {
                foreach (var fileName in options.Files)
                {
                    currentFileNamme = fileName;
                    RunScripts(Path.Combine(BaseOutputPath, fileName));
                }
            }
            catch (Exception ex)
            {
                WriteLine(("Error running merge script:", Red), (currentFileNamme, Yellow));
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

            using (var f = File.OpenText(file))
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (var tran = cnn.BeginTransaction())
                {
                    foreach (var commandText in GetCommands(f))
                        using (var cmd = new SqlCommand(commandText.Command, cnn, tran)
                            {CommandTimeout = options.CommandTimeout})
                        {
                            Write($"{commandText.TableName}", Cyan);
                            var affectedRows = cmd.ExecuteNonQuery();
                            WriteLine($" ({affectedRows} row(s) affected)", White);
                        }

                    tran.Commit();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        private IEnumerable<(string Command, string TableName)> GetCommands(StreamReader streamReader)
        {
            var tableName = "";
            var buffer = new StringBuilder();
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var tableMatch = Regex.Match(line, @"\s*MERGE\s*(.*)\s*AS");
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
    }
}