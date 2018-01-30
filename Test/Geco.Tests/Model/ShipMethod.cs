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
    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class ShipMethod
    {
        // Key Properties
        public int ShipMethodID { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public decimal ShipBase { get; set; }
        public decimal ShipRate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public List<SalesOrderHeader> SalesOrderHeaders { get; set; }

        public ShipMethod()
        {
            this.PurchaseOrderHeaders = new List<PurchaseOrderHeader>();
            this.SalesOrderHeaders = new List<SalesOrderHeader>();
        }
    }
}