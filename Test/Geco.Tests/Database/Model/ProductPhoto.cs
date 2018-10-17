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
    [GeneratedCode("Geco", "1.0.6.0")]
    public partial class ProductPhoto
    {
        // Key Properties
        public int ProductPhotoID { get; set; }

        // Scalar Properties
        public Byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public Byte[] LargePhoto { get; set; }
        public string LargePhotoFileName { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<ProductProductPhoto> ProductProductPhotos { get; set; }

        public ProductPhoto()
        {
            this.ProductProductPhotos = new List<ProductProductPhoto>();
        }
    }
}