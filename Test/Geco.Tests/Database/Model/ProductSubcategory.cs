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
    public partial class ProductSubcategory
    {
        // Key Properties
        public int ProductSubcategoryID { get; set; }

        // Scalar Properties
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public ProductCategory ProductCategory { get; set; } //Column: ProductCategoryID, FK: FK_ProductSubcategory_ProductCategory_ProductCategoryID

        // Reverse navigation
        public List<Product> Products { get; set; }

        public ProductSubcategory()
        {
            this.Products = new List<Product>();
        }
    }
}