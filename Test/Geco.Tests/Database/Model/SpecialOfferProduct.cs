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
    public partial class SpecialOfferProduct
    {
        // Key Properties
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }

        // Scalar Properties
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Product Product { get; set; } //Column: ProductID, FK: FK_SpecialOfferProduct_Product_ProductID
        public SpecialOffer SpecialOffer { get; set; } //Column: SpecialOfferID, FK: FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID

        // Reverse navigation
        public List<SalesOrderDetail> SalesOrderDetails { get; set; }

        public SpecialOfferProduct()
        {
            this.SalesOrderDetails = new List<SalesOrderDetail>();
        }
    }
}