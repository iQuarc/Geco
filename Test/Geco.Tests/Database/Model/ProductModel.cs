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
    [GeneratedCode("Geco", "1.0.8.0")]
    public partial class ProductModel
    {
        // Key Properties
        public int ProductModelID { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public string Instructions { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<Product> Products { get; set; }
        public List<ProductModelIllustration> ProductModelIllustrations { get; set; }
        public List<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }

        public ProductModel()
        {
            this.Products = new List<Product>();
            this.ProductModelIllustrations = new List<ProductModelIllustration>();
            this.ProductModelProductDescriptionCultures = new List<ProductModelProductDescriptionCulture>();
        }
    }
}