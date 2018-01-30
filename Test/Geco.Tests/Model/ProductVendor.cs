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
    public partial class ProductVendor
    {
        // Key Properties
        public int ProductID { get; set; }
        public int BusinessEntityID { get; set; }

        // Scalar Properties
        public int AverageLeadTime { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal LastReceiptCost { get; set; }
        public DateTime LastReceiptDate { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }
        public string UnitMeasureCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Vendor Vendors { get; set; }
        public Product Products { get; set; }
        public UnitMeasure UnitMeasures { get; set; }

    }
}