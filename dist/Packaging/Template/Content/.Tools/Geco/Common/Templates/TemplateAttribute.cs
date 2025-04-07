namespace Geco.Common.Templates;

/// <summary>
///    Identifies a generator template
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class TemplateAttribute(string templateName) : ServiceAttribute(typeof(IDbTemplate))
{
   public string TemplateName { get; } = templateName;
}