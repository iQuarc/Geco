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
    public partial class Culture
    {
        // Key Properties
        public string CultureID { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }

        public Culture()
        {
            this.ProductModelProductDescriptionCultures = new List<ProductModelProductDescriptionCulture>();
        }
    }
}