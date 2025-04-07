using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Geco.Common.Inflector;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Dac;

namespace Geco.Database;

[Options(typeof(DatabasePublishOptions))]
public class DatabasePublish : BaseGenerator
{
   private readonly IConfigurationRoot configurationRoot;

   public DatabasePublish(DatabasePublishOptions options, IInflector inf, IConfigurationRoot configurationRoot)
      : base(inf)
   {
      this.configurationRoot = configurationRoot;
      Options                = options;
   }

   public DatabasePublishOptions Options { get; }

   protected override void Generate()
   {
      var visualStudioPath = FindVisualStudio();
      if (visualStudioPath == null)
      {
         WriteLine($"Error: Cannot find {("msbuild.exe", Yellow)} path!", Red);
         return;
      }

      var msbuildPath = Path.Combine(visualStudioPath, @"MSBuild\Current\Bin");

      var psi = new ProcessStartInfo($@"{msbuildPath}\msbuild.exe",
         $"\"{Options.ProjectName}.sqlproj\" /P:Configuration=Release ")
      {
         WorkingDirectory = BaseOutputPath
      };
      var pb = Process.Start(psi);
      pb?.WaitForExit();

      if (pb?.ExitCode != 0)
      {
         WriteLine($"Error: Build failed for {($"{Options.ProjectName}.sqlproj", Yellow)} project!", Red);
         return;
      }

      var connectionString = configurationRoot.GetConnectionString(Options.ConnectionName ??
                                                                   throw new InvalidOperationException(
                                                                      "Connection name cannot be null"));
      var dacpacFile  = Path.Combine(Path.GetFullPath(BaseOutputPath), $@"bin\Release\{Options.ProjectName}.dacpac");
      var profileFile = Path.Combine(Path.GetFullPath(BaseOutputPath), $@"bin\Release\{Options.PublishProfile}");

      PublishDacpac(connectionString, profileFile, dacpacFile);
   }

   private static string? FindVisualStudio()
   {
      var pi = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft Visual Studio\Installer\vswhere.exe",
         "-products * -requires Microsoft.Component.MSBuild -prerelease -latest -utf8 -format text");
      pi.RedirectStandardOutput = true;
      var p      = Process.Start(pi);
      var output = p.StandardOutput.ReadToEnd();
      p.WaitForExit();
      var installationPath = Regex.Match(output, @"^installationPath:\s*(.*)\r$", RegexOptions.Multiline);

      if (installationPath.Success)
         return installationPath.Groups[1].Value;

      return null;
   }


   public Task<bool> PublishDacpac(string? connectionString, string? publishProfileName, string dacPacFile)
   {
      if (connectionString == null)
         throw new InvalidOperationException("Connection string cannot be null");

      var cnnSb = new SqlConnectionStringBuilder(connectionString);
      WriteLine($"Begin Dacpac Publish for [{(cnnSb.InitialCatalog, Yellow)}]...", Green);

      var log     = new StringBuilder();
      var success = true;

      try
      {
         var dacOptions = string.IsNullOrEmpty(publishProfileName)
            ? Options.DacOptions ?? new DacDeployOptions()
            : DacProfile.Load(publishProfileName).DeployOptions;

         var dacService = new DacServices(connectionString);

         dacService.Message += (_, e) => log.AppendLine(e.Message.Message);
         dacService.ProgressChanged += (_, e) =>
            success = success && e.Status is not (DacOperationStatus.Faulted or DacOperationStatus.Cancelled);

         dacOptions.BlockOnPossibleDataLoss     = Options.BlockOnPossibleDataLoss ?? true;
         dacOptions.DropObjectsNotInSource      = Options.RemoveObjectsNotInSource ?? false;
         dacOptions.RegisterDataTierApplication = Options.RegisterDataTierApplication;
         dacOptions.BlockWhenDriftDetected      = Options.BlockWhenDriftDetected;


         using (var dacpac = DacPackage.Load(dacPacFile))
         {
            WriteLine(
               $"Deploying: {(Path.GetFileNameWithoutExtension(dacPacFile), Yellow)} Version: {(dacpac.Version, Cyan)}",
               Green);
            dacService.Deploy(dacpac, cnnSb.InitialCatalog,
               true,
               dacOptions);
         }

         WriteLine($"Log: {(log, DarkGray)}", Yellow);
         WriteLine($"Finished Dacpac Publish for [{(cnnSb.InitialCatalog, Yellow)}]...", Green);
      }
      catch (Exception ex)
      {
         WriteLine($"Log: {(log, DarkGray)}", Yellow);
         WriteLine($"Error applying DacPac: {(ex, DarkRed)}", Red);
         return Task.FromResult(false);
      }

      return Task.FromResult(success);
   }
}