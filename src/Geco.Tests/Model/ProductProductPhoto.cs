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
    public partial class ProductProductPhoto
    {
        // Key Properties
        public int ProductID { get; set; }
        public int ProductPhotoID { get; set; }

        // Scalar Properties
        public bool Primary { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Product Products { get; set; }
        public ProductPhoto ProductPhotos { get; set; }

    }
}