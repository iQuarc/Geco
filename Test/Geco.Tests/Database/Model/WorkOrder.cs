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
    public partial class WorkOrder
    {
        // Key Properties
        public int WorkOrderID { get; set; }

        // Scalar Properties
        public int ProductID { get; set; }
        public int OrderQty { get; set; }
        public int StockedQty { get; set; }
        public short ScrappedQty { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public short? ScrapReasonID { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Product Product { get; set; } //Column: ProductID, FK: FK_WorkOrder_Product_ProductID
        public ScrapReason ScrapReason { get; set; } //Column: ScrapReasonID, FK: FK_WorkOrder_ScrapReason_ScrapReasonID

        // Reverse navigation
        public List<WorkOrderRouting> WorkOrderRoutings { get; set; }

        public WorkOrder()
        {
            this.WorkOrderRoutings = new List<WorkOrderRouting>();
        }
    }
}