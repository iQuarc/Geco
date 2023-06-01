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
    public partial class BillOfMaterial
    {
        // Key Properties
        public int BillOfMaterialsID { get; set; }

        // Scalar Properties
        public int? ProductAssemblyID { get; set; }
        public int ComponentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UnitMeasureCode { get; set; }
        public short BOMLevel { get; set; }
        public decimal PerAssemblyQty { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Product Component { get; set; } //Column: ComponentID, FK: FK_BillOfMaterials_Product_ComponentID
        public Product ProductAssembly { get; set; } //Column: ProductAssemblyID, FK: FK_BillOfMaterials_Product_ProductAssemblyID
        public UnitMeasure UnitMeasure { get; set; } //Column: UnitMeasureCode, FK: FK_BillOfMaterials_UnitMeasure_UnitMeasureCode

    }
}