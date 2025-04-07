using Microsoft.SqlServer.Dac;

namespace Geco.Database;

public class DatabasePublishOptions
{
   public string?           ConnectionName              { get; set; }
   public string?           ProjectName                 { get; set; }
   public string?           PublishProfile              { get; set; }
   public bool?             BlockOnPossibleDataLoss     { get; set; }
   public bool?             RemoveObjectsNotInSource    { get; set; }
   public bool              RegisterDataTierApplication { get; set; } = true;
   public bool              BlockWhenDriftDetected      { get; set; }
   public DacDeployOptions? DacOptions                  { get; set; }
}