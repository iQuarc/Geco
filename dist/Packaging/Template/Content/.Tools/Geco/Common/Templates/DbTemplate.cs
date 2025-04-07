namespace Geco.Common.Templates;

public abstract class DbTemplate<T, TOptions> : IDbTemplate
   where T : MetadataItem
   where TOptions : class, new()
{
   protected TOptions Options { get; private set; } = new();

   string IDbTemplate.GetTemplate(MetadataItem item, DatabaseMetadata db, object? options)
   {
      Options = options as TOptions ?? Options;
      return GetTemplate((T)item, db);
   }

   protected abstract string GetTemplate(T item, DatabaseMetadata db);
}

public abstract class DbTemplate<T> : DbTemplate<T, dynamic>
   where T : MetadataItem
{
}