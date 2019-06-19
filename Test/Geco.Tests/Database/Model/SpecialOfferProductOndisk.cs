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
    public partial class SpecialOfferProductOndisk
    {
        // Key Properties
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }

        // Scalar Properties
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public ProductOndisk ProductOndisk { get; set; }
        public SpecialOfferOndisk SpecialOfferOndisk { get; set; }

        // Reverse navigation
        public List<SalesOrderDetailOndisk> SalesOrderDetailOndisks { get; set; }

        public SpecialOfferProductOndisk()
        {
            this.SalesOrderDetailOndisks = new List<SalesOrderDetailOndisk>();
        }
    }
}