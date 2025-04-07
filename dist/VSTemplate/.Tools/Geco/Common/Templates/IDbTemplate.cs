namespace Geco.Common.Templates;

public interface IDbTemplate
{
   string GetTemplate(MetadataItem item, DatabaseMetadata db, object? options = null);
}