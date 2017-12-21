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
    [GeneratedCode("Geco", "1.0.2.0")]
    public partial class Illustration
    {
        // Key Properties
        public int IllustrationID { get; set; }

        // Scalar Properties
        public string Diagram { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<ProductModelIllustration> ProductModelIllustrations { get; set; }

        public Illustration()
        {
            this.ProductModelIllustrations = new List<ProductModelIllustration>();
        }
    }
}