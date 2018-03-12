using System;
using System.Text.RegularExpressions;
using Geco.Common.SimpleMetadata;

namespace Geco
{
    public class Util
    {
        public static bool TableNameMachesRegex(Table table, string tablesRegex, bool onNull)
        {
            if (String.IsNullOrWhiteSpace(tablesRegex))
                return onNull;
            return
                (
                    Regex.IsMatch(table.Name, tablesRegex) ||
                    Regex.IsMatch($"[{table.Name}]", tablesRegex) ||
                    Regex.IsMatch($"{table.Schema.Name}.{table.Name}", tablesRegex) ||
                    Regex.IsMatch($"[{table.Schema.Name}].[{table.Name}]", tablesRegex)
                );
        }

        public static bool TableNameMaches(Table table, string name)
        {
            return string.Equals(name, table.Name, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(name, $"[{table.Name}]", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(name, $"{table.Schema.Name}.{table.Name}", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(name, $"[{table.Schema.Name}].[{table.Name}]", StringComparison.OrdinalIgnoreCase);
        }
    }
}