using System;
using System.Data.SqlClient;
using Geco.Common;
using Microsoft.Extensions.Configuration;
using static System.ConsoleColor;

namespace Geco.Database
{
    /// <summary>
    /// Deletes all the data in the specified database (SqlServer only) by disabling all triggers and constraints, deleting the data then re enabling them back.
    /// </summary>
    /// <remarks>
    /// Deleting of data is done in a transaction, so either all data is deleted or none is.
    /// </remarks>
    [Options(typeof(DatabaseCleanerOptions))]
    public class DatabaseCleaner : BaseGenerator
    {
        private readonly IConfigurationRoot configurationRoot;
        private readonly DatabaseCleanerOptions options;
        private static string where = "AND o.Name NOT IN (''sysdiagrams'', ''__RefactorLog'')";
        private static string ctx = "SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS ON;SET NUMERIC_ROUNDABORT OFF;";
        private static readonly FormattableString[] Statements =
        {
            $@"EXEC sp_MSForEachTable @command1='{ctx}DISABLE TRIGGER ALL ON ?', @whereand='{where}'",
            $@"EXEC sp_MSForEachTable @command1='{ctx}ALTER TABLE ? NOCHECK CONSTRAINT ALL', @whereand='{where}'",
            $@"EXEC sp_MSForEachTable @command1='{ctx}DELETE FROM ?', @whereand='{where}'",
            $@"EXEC sp_MSForEachTable @command1='{ctx}ALTER TABLE ? CHECK CONSTRAINT ALL', @whereand='{where}'",
            $@"EXEC sp_MSForEachTable @command1='{ctx}ENABLE TRIGGER ALL ON ?', @whereand='{where}'",
            $@"EXEC sp_MSforeachtable @command1 = 'DBCC CHECKIDENT (''?'', RESEED, 1)', @whereand = 'AND EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id = o.ID AND c.is_identity = 1)'"
        };

        private bool exit = false;

        public DatabaseCleaner(IConfigurationRoot configurationRoot, DatabaseCleanerOptions options, IInflector inf) : base(inf)
        {
            this.configurationRoot = configurationRoot;
            this.options = options;
        }

        protected override void Generate()
        {
            if (exit)
                return;
            var connectionString = configurationRoot.GetConnectionString(options.ConnectionName ?? "DefaultConnection");
            CleanDatabase(connectionString);
        }

        public static void CleanDatabase(string connectionString)
        {
            using (var cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (var tran = cnn.BeginTransaction())
                {
                    foreach (var statement in Statements)
                    {
                        using (var cmd = new SqlCommand(statement.ToString(), cnn, tran))
                        {
                            ColorConsole.WriteLine(("Running: ", Yellow), (string.Format(statement.Format, "", "***"), White));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Rollback();
                }
            }
        }

        public override bool GetUserConfirmation()
        {
            ColorConsole.Write($"Are you sure you want to delete all data in the target database? (y/n):", White);
            return string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);
        }
    }
}