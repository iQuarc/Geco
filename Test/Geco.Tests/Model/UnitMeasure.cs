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
    public partial class UnitMeasure
    {
        // Key Properties
        public string UnitMeasureCode { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<BillOfMateria> BillOfMaterias { get; set; }
        public List<Product> ProductsSizeUnitMeasureCode { get; set; }
        public List<Product> ProductsWeightUnitMeasureCode { get; set; }
        public List<ProductVendor> ProductVendors { get; set; }

        public UnitMeasure()
        {
            this.BillOfMaterias = new List<BillOfMateria>();
            this.ProductsSizeUnitMeasureCode = new List<Product>();
            this.ProductsWeightUnitMeasureCode = new List<Product>();
            this.ProductVendors = new List<ProductVendor>();
        }
    }
}