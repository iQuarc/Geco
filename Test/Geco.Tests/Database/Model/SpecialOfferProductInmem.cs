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
    [GeneratedCode("Geco", "1.0.4.0")]
    public partial class SpecialOfferProductInmem
    {
        // Key Properties
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }

        // Scalar Properties
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public ProductInmem ProductInmem { get; set; }
        public SpecialOfferInmem SpecialOfferInmem { get; set; }

        // Reverse navigation
        public List<SalesOrderDetailInmem> SalesOrderDetailInmems { get; set; }

        public SpecialOfferProductInmem()
        {
            this.SalesOrderDetailInmems = new List<SalesOrderDetailInmem>();
        }
    }
}