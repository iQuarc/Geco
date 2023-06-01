// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable UnusedMember.Global
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Geco.Tests.Database.Model
{
    [GeneratedCode("Geco", "1.0.9.0")]
    public partial class WorkOrderRouting
    {
        // Key Properties
        public int WorkOrderID { get; set; }
        public int ProductID { get; set; }
        public short OperationSequence { get; set; }

        // Scalar Properties
        public short LocationID { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal? ActualResourceHrs { get; set; }
        public decimal PlannedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Location Location { get; set; } //Column: LocationID, FK: FK_WorkOrderRouting_Location_LocationID
        public WorkOrder WorkOrder { get; set; } //Column: WorkOrderID, FK: FK_WorkOrderRouting_WorkOrder_WorkOrderID

    }
}