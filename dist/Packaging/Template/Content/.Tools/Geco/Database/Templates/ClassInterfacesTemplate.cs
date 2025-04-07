using System.Collections.Generic;
using System.Linq;
using Geco.Common.SimpleMetadata;
using Geco.Common.Templates;
using static System.ConsoleColor;
using static Geco.Common.Util.ColorConsole;

namespace Geco.Database.Templates
{
    /// <summary>
    /// Determine the interfaces that must be added to an entity
    /// </summary>
    [Template("ClassInterfaces")]
    public class ClassInterfacesTemplate : DbTemplate<Table, EntityFrameworkCoreReverseModelGeneratorOptions>
    {
        protected override string GetTemplate(Table table, DatabaseMetadata db)
        {
            return string.Join(", ", GetAll());

            IEnumerable<string> GetAll()
            {
                // Sample IAuditable interface implementation
                if (CheckTypeAndNullability("CreatedDate",     "datetime", false, "IAuditable")
                    && CheckTypeAndNullability("ModifiedDate", "datetime", false, "IAuditable")
                    && CheckTypeAndNullability("ModifiedBy",       "nvarchar",  true,  "IAuditable"))
                    yield return "IAuditable";
            }

            bool CheckTypeAndNullability(string columnName, string expectedType, bool expectedIsNullable, string interfaceOrBaseClass, bool warnType = true, bool warnNullable = true,
                                         string? targetTable = null)
            {
                if (!table.Columns.ContainsKey(columnName))
                    return false;

                Column column = table.Columns[columnName];

                if (column.DataType != expectedType)
                {
                    if (warnType)
                        WriteLine(
                            $"Column {($"[{column.Table.Schema.Name}].[{column.Table.Name}].[{column.Name}]", Yellow)} has unexpected data type and the {($"[{interfaceOrBaseClass}]", Yellow)} class was not Implemented.",
                            DarkYellow);

                    return false;
                }

                if (column.IsNullable != expectedIsNullable)
                {
                    if (warnNullable)
                        WriteLine(
                            $"Column {($"[{column.Table.Schema.Name}].[{column.Table.Name}].[{column.Name}]", Yellow)} is [{(column.IsNullable ? "Nullable" : "Not Nullable", Yellow)}] and the {($"[{interfaceOrBaseClass}]", Yellow)} class was not Implemented.",
                            DarkYellow);

                    return false;
                }

                if (!string.IsNullOrEmpty(targetTable))
                {
                    if (column.ForeignKey == null || !column.ForeignKey.TargetTable.TableNameMatches(targetTable))
                    {
                        WriteLine(
                            $"Column {($"[{column.Table.Schema.Name}].[{column.Table.Name}].[{column.Name}]", Yellow)} is not a Foreign Key to {targetTable} and the {($"[{interfaceOrBaseClass}]", Yellow)} class was not Implemented.",
                            DarkYellow);

                        return false;
                    }
                }

                return true;
            }
        }
    }
}