using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using Geco.Common.Inflector;
using Microsoft.Build.Evaluation;
using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.Compare;

namespace Geco.Database;

[Options(typeof(DatabaseSchemaCompareOptions))]
public class DatabaseSchemaCompare(
   DatabaseSchemaCompareOptions options,
   IInflector                   inf)
   : BaseGenerator(inf)
{
   public DatabaseSchemaCompareOptions Options { get; } = options;

   protected override void Generate()
   {
      if (BaseOutputPath == null)
         throw new InvalidOperationException($"{nameof(BaseOutputPath)} is not set in configuration");

      var scmpFile = Path.Combine(Path.GetFullPath(BaseOutputPath),
         Options.ScmpFile ?? throw new InvalidOperationException(".scmp file path not configured"));

      var sqlProjFile = Path.Combine(Path.GetFullPath(BaseOutputPath),
         Options.SqlProjFile ?? throw new InvalidOperationException(".sqlproj file path not configured"));

      WriteLine($"Starting schema compare using: {(Options.ScmpFile, Yellow)}", White);
      var transformedScmpFile = TransformScm(scmpFile, sqlProjFile);
      var compare             = new SchemaComparison(transformedScmpFile);
      var result              = compare.Compare();

      if (!result.IsValid)
      {
         WriteLine($"Schema compare failed for: {(Options.ScmpFile, Yellow)}", Red);
         WriteLine($"Errors:", Red);

         foreach (var error in result.GetErrors()) WriteLine($"{error.Message}", DarkRed);
         return;
      }

      if (result.Differences.Any())
      {
         WriteLine($"Schema differences:", Cyan);

         foreach (var schemaDifference in result.Differences.WithInfo())
            WriteLine($"{schemaDifference.Index + 1}. {(schemaDifference.Item.Name, Green)}", White);

         var pResult = result.PublishChangesToProject(
            BaseOutputPath ?? throw new InvalidOperationException("project folder not configured in BaseOutputPath"),
            DacExtractTarget.SchemaObjectType);

         if (pResult.Success)
         {
            foreach (var file in pResult.AddedFiles)
               WriteLine($"Added: {(Grp(file), Green)}", White);
            foreach (var file in pResult.ChangedFiles)
               WriteLine($"Changed: {(Grp(file), Green)}", White);
            foreach (var file in pResult.DeletedFiles)
               WriteLine($"Deleted: {(Grp(file), Green)}", White);
         }
         else
         {
            WriteLine($"Error updating project {(pResult.ErrorMessage, DarkRed)}:", Red);
         }

         string Grp(string path)
         {
            return Path.GetRelativePath(BaseOutputPath, path);
         }
      }
      else
      {
         WriteLine($"No Schema differences", Cyan);
      }
   }

   private string TransformScm(string scmpFile, string projFile)
   {
      if (BaseOutputPath == null)
         throw new InvalidOperationException($"{nameof(BaseOutputPath)} is not set in configuration");

      var        xScmp    = XDocument.Load(File.OpenRead(scmpFile));
      var        xProj    = XDocument.Load(File.OpenRead(projFile));
      var        fullPath = Path.GetFullPath(BaseOutputPath);
      XNamespace xp       = @"http://schemas.microsoft.com/developer/msbuild/2003";
      var projFiles = xProj.Root!.Descendants(xp + "Build")
         .Select(x => x.Attribute("Include")?.Value)
         .Where(x => x != null && Path.GetExtension(x) == ".sql")
         .Select(x => Path.Combine(fullPath, x!))
         .ToList();

      XNamespace xs  = "";
      var        smp = xScmp.XPathSelectElement("/SchemaComparison/SourceModelProvider");
      var        tmp = xScmp.XPathSelectElement("/SchemaComparison/TargetModelProvider");
      var        spc = smp.Descendants().First();
      var        tpc = tmp.Descendants().First();
      var connectionElement = spc.Name == "ConnectionBasedModelProvider" ? spc :
         tpc.Name == "ConnectionBasedModelProvider"                      ? tpc : null;
      var projectElement = tpc.Name == "ProjectBasedModelProvider" ? tpc :
         spc.Name == "ProjectBasedModelProvider"                   ? spc : null;

      if (connectionElement == null || projectElement == null)
         throw new InvalidOperationException("The .scmp file does not contain the Connection or Project elements");

      smp.RemoveNodes();
      tmp.RemoveNodes();

      projectElement.Add(new XElement(xs + "ProjectFilePath", projFile));
      projectElement.Add(new XElement(xs + "TargetScripts", $"[{string.Join(",", projFiles)}]"));
      projectElement.Add(new XElement(xs + "Dsp", Options.Dsp));
      projectElement.Add(new XElement(xs + "FolderStructure", Options.FolderStructure));

      tmp.Add(projectElement);
      smp.Add(connectionElement);

      var localPath = Path.Combine(Path.GetDirectoryName(typeof(DatabaseSchemaCompare).Assembly.Location)!,
         Path.GetFileName(scmpFile));
      xScmp.Save(localPath);
      return localPath;
   }
}