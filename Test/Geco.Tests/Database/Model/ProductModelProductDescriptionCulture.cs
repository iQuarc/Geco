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
    public partial class ProductModelProductDescriptionCulture
    {
        // Key Properties
        public int ProductModelID { get; set; }
        public int ProductDescriptionID { get; set; }
        public string CultureID { get; set; }

        // Scalar Properties
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Culture Culture { get; set; } //Column: CultureID, FK: FK_ProductModelProductDescriptionCulture_Culture_CultureID
        public ProductDescription ProductDescription { get; set; } //Column: ProductDescriptionID, FK: FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID
        public ProductModel ProductModel { get; set; } //Column: ProductModelID, FK: FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID

    }
}