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
    public partial class ProductVendor
    {
        // Key Properties
        public int ProductID { get; set; }
        public int BusinessEntityID { get; set; }

        // Scalar Properties
        public int AverageLeadTime { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal? LastReceiptCost { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }
        public string UnitMeasureCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Vendor Vendor { get; set; } //Column: BusinessEntityID, FK: FK_ProductVendor_Vendor_BusinessEntityID
        public Product Product { get; set; } //Column: ProductID, FK: FK_ProductVendor_Product_ProductID
        public UnitMeasure UnitMeasure { get; set; } //Column: UnitMeasureCode, FK: FK_ProductVendor_UnitMeasure_UnitMeasureCode

    }
}