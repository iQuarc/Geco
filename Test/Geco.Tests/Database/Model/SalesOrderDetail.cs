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
    public partial class SalesOrderDetail
    {
        // Key Properties
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }

        // Scalar Properties
        public string CarrierTrackingNumber { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public SalesOrderHeader SalesOrderHeader { get; set; } //Column: SalesOrderID, FK: FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
        public SpecialOfferProduct SpecialOfferProduct { get; set; } //Columns: SpecialOfferID, ProductID, FK: FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID

    }
}