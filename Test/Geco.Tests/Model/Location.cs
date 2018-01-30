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

namespace Geco.Tests.Model
{
    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class Location
    {
        // Key Properties
        public short LocationID { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<ProductInventory> ProductInventories { get; set; }
        public List<WorkOrderRouting> WorkOrderRoutings { get; set; }

        public Location()
        {
            this.ProductInventories = new List<ProductInventory>();
            this.WorkOrderRoutings = new List<WorkOrderRouting>();
        }
    }
}