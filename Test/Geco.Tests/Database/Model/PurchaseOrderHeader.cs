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
    public partial class PurchaseOrderHeader
    {
        // Key Properties
        public int PurchaseOrderID { get; set; }

        // Scalar Properties
        public byte RevisionNumber { get; set; }
        public byte Status { get; set; }
        public int EmployeeID { get; set; }
        public int VendorID { get; set; }
        public int ShipMethodID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Employee Employee { get; set; } //Column: EmployeeID, FK: FK_PurchaseOrderHeader_Employee_EmployeeID
        public ShipMethod ShipMethod { get; set; } //Column: ShipMethodID, FK: FK_PurchaseOrderHeader_ShipMethod_ShipMethodID
        public Vendor Vendor { get; set; } //Column: VendorID, FK: FK_PurchaseOrderHeader_Vendor_VendorID

        // Reverse navigation
        public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public PurchaseOrderHeader()
        {
            this.PurchaseOrderDetails = new List<PurchaseOrderDetail>();
        }
    }
}