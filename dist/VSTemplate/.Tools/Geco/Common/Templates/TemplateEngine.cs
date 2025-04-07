using System.Reflection;

namespace Geco.Common.Templates;

[Service(typeof(TemplateEngine))]
public class TemplateEngine
{
   private readonly IMetadataProvider               metadataProvider;
   private readonly Dictionary<string, IDbTemplate> templates = new();

   public TemplateEngine(IEnumerable<IDbTemplate> dbTemplates, IMetadataProvider metadataProvider)
   {
      this.metadataProvider = metadataProvider;
      foreach (var dbTemplate in dbTemplates)
      {
         var typeInfo          = dbTemplate.GetType().GetTypeInfo();
         var templateAttribute = typeInfo.GetCustomAttribute<TemplateAttribute>();
         var templateName      = templateAttribute?.TemplateName;
         if (string.IsNullOrEmpty(templateName))
         {
            WriteLine($"Template [{typeInfo.Name}] does not contain the [TemplateAttribute] and was Ignored.",
               DarkYellow);
            continue;
         }

         templates[templateName] = dbTemplate;
      }
   }

   public string RunTemplate(string name, MetadataItem item, object? options = null)
   {
      if (string.IsNullOrEmpty(name))
         return "";
      return templates[name].GetTemplate(item, metadataProvider.GetMetadata(), options);
   }
}