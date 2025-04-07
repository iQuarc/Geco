namespace Geco.Database;

public class DatabaseSchemaCompareOptions
{
   public string? ScmpFile    { get; set; } = "";
   public string? SqlProjFile { get; set; } = "";
   public string  Dsp         { get; set; } = "Sql140"; // see: Microsoft.Data.Tools.Schema.SchemaModel.SqlPlatforms 

   public string FolderStructure { get; set; } =
      "SchemaObjectType"; // DacPac, File, Flat, ObjectType, Schema, SchemaObjectType
}