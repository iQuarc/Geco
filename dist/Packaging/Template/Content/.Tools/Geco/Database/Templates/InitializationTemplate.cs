using Geco.Common.Templates;

namespace Geco.Database.Templates;

[Template("MemberInitialization")]
public class InitializationTemplate : DbTemplate<Column, EntityFrameworkCoreReverseModelGeneratorOptions>
{
   public DatabaseMetadata Db { get; set; }

   protected override string GetTemplate(Column column, DatabaseMetadata db)
   {
      Db = db;
      var clrTypeName = GetClrTypeName(column);

      if (clrTypeName == "String" && !column.IsNullable)
         return " = \"\";";

      if (TryGetColumnTypeNameFromOptions(column, out _) &&
          TryGetClrTypeName(column, out var clrName) &&
          clrName == "String" &&
          !column.IsNullable
         )
         return " = new();";

      return "";
   }

   private string GetClrTypeName(Column column)
   {
      var sysType = "string";

      if (TryGetColumnTypeNameFromOptions(column, out var clrTypeName)) return clrTypeName;

      if (TryGetClrTypeName(column, out clrTypeName)) return clrTypeName;

      return sysType;
   }

   private bool TryGetClrTypeName(Column column, out string? clrTypeName)
   {
      if (Db.TypeMappings.TryGetValue(column.DataType, out var clrType))
      {
         if (clrType == typeof(char))
         {
            clrTypeName = "string";
            return true;
         }

         clrTypeName = clrType.Name;
         return true;
      }

      clrTypeName = null;
      return false;
   }

   private bool TryGetColumnTypeNameFromOptions(Column column, out string? clrTypeName)
   {
      foreach (var columnType in Options.ColumnTypes)
         if (column.ColumnNameMatches(columnType.ColumnName))
         {
            clrTypeName = columnType.TypeName + GetNullable(column);
            return true;
         }

      clrTypeName = null;
      return false;
   }

   private string GetNullable(Column column)
   {
      if (column.IsNullable && Db.TypeMappings[column.DataType] != typeof(char))
         return "?";
      return "";
   }
}