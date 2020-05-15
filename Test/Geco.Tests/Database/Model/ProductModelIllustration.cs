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
    public partial class ProductModelIllustration
    {
        // Key Properties
        public int ProductModelID { get; set; }
        public int IllustrationID { get; set; }

        // Scalar Properties
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Illustration Illustration { get; set; } //Column: IllustrationID, FK: FK_ProductModelIllustration_Illustration_IllustrationID
        public ProductModel ProductModel { get; set; } //Column: ProductModelID, FK: FK_ProductModelIllustration_ProductModel_ProductModelID

    }
}