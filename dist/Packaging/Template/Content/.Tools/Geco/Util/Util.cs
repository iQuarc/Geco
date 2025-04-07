using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace Geco;

public static class Util
{
   public static bool TableNameMatchesRegex(this Table table, string? tablesRegex, bool onNull)
   {
      if (string.IsNullOrWhiteSpace(tablesRegex))
         return onNull;
      return
         Regex.IsMatch(table.Name, tablesRegex) ||
         Regex.IsMatch($"[{table.Name}]", tablesRegex) ||
         Regex.IsMatch($"{table.Schema.Name}.{table.Name}", tablesRegex) ||
         Regex.IsMatch($"[{table.Schema.Name}].[{table.Name}]", tablesRegex);
   }

   public static bool TableNameMatches(this Table table, string? name)
   {
      return name == "*" ||
             string.Equals(name, table.Name, StringComparison.OrdinalIgnoreCase) ||
             string.Equals(name, $"[{table.Name}]", StringComparison.OrdinalIgnoreCase) ||
             string.Equals(name, $"{table.Schema.Name}.{table.Name}", StringComparison.OrdinalIgnoreCase) ||
             string.Equals(name, $"[{table.Schema.Name}].[{table.Name}]", StringComparison.OrdinalIgnoreCase);
   }

   public static bool ColumnNameMatches(this Column column, string? name)
   {
      return name == "*" ||
             string.Equals(name, column.Name, StringComparison.OrdinalIgnoreCase) ||
             string.Equals(name, $"[{column.Name}]", StringComparison.OrdinalIgnoreCase) ||
             string.Equals(name, $"{column.Table.Name}.{column.Name}", StringComparison.OrdinalIgnoreCase) ||
             string.Equals(name, $"[{column.Table.Name}].[{column.Name}]", StringComparison.OrdinalIgnoreCase) ||
             string.Equals(name, $"{column.Table.Schema.Name}.{column.Table.Name}.{column.Name}",
                StringComparison.OrdinalIgnoreCase) ||
             string.Equals(name, $"[{column.Table.Schema.Name}].[{column.Table.Name}].[{column.Name}]",
                StringComparison.OrdinalIgnoreCase);
   }

   public static bool HasTableKey<TU>(this IDictionary<string, TU> dictionary, Table table)
   {
      return dictionary.ContainsKey($"{table.Name}") ||
             dictionary.ContainsKey($"[{table.Name}]") ||
             dictionary.ContainsKey($"{table.Schema.Name}.{table.Name}") ||
             dictionary.ContainsKey($"[{table.Schema.Name}].[{table.Name}]");
   }

   public static bool TryGetWithTableNameKey<TU>(this IDictionary<string, TU> dictionary, Table table,
      [MaybeNullWhen(false)] out                      TU                      value)
   {
      return dictionary.TryGetValue($"{table.Name}", out value) ||
             dictionary.TryGetValue($"[{table.Name}]", out value) ||
             dictionary.TryGetValue($"{table.Schema.Name}.{table.Name}", out value) ||
             dictionary.TryGetValue($"[{table.Schema.Name}].[{table.Name}]", out value);
   }

   public static StringBuilder Append(this StringBuilder builder, string? value, bool? append)
   {
      if (append == true)
         builder.Append(value);
      return builder;
   }
}