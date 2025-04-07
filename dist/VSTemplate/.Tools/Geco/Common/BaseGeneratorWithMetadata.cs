using Geco.Common.Inflector;

namespace Geco.Common;

public abstract class BaseGeneratorWithMetadata(
   IMetadataProvider provider,
   IInflector        inf,
   string            connectionName
)
   : BaseGenerator(inf)
{
   protected readonly string ConnectionName = connectionName;

   public DatabaseMetadata  Db       => Provider.GetMetadata(ConnectionName);
   public IMetadataProvider Provider { get; } = provider;

   protected void ReloadMetadata()
   {
      Provider.Reload();
   }

   protected virtual void OnMetadataLoaded(DatabaseMetadata db)
   {
   }

   protected string GetCSharpTypeName(Type type)
   {
      if (type == typeof(bool)) return "bool";
      if (type == typeof(byte)) return "byte";
      if (type == typeof(sbyte)) return "sbyte";
      if (type == typeof(char)) return "char";
      if (type == typeof(decimal)) return "decimal";
      if (type == typeof(double)) return "double";
      if (type == typeof(float)) return "float";
      if (type == typeof(int)) return "int";
      if (type == typeof(uint)) return "uint";
      if (type == typeof(long)) return "long";
      if (type == typeof(ulong)) return "ulong";
      if (type == typeof(object)) return "object";
      if (type == typeof(short)) return "short";
      if (type == typeof(ushort)) return "ushort";
      if (type == typeof(string)) return "string";
      if (type == typeof(byte[])) return "byte[]";
      return type.Name;
   }
}