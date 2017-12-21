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
    [GeneratedCode("Geco", "1.0.2.0")]
    public partial class SalesOrderHeader
    {
        // Key Properties
        public int SalesOrderID { get; set; }

        // Scalar Properties
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int? SalesPersonID { get; set; }
        public int? TerritoryID { get; set; }
        public int BillToAddressID { get; set; }
        public int ShipToAddressID { get; set; }
        public int ShipMethodID { get; set; }
        public int? CreditCardID { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public int? CurrencyRateID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Address Addresses { get; set; }
        public CreditCard CreditCards { get; set; }
        public CurrencyRate CurrencyRates { get; set; }
        public Customer Customers { get; set; }
        public SalesPerson SalesPeople { get; set; }
        public ShipMethod ShipMethods { get; set; }
        public Address AddressesShipToAddress { get; set; }
        public SalesTerritory SalesTerritories { get; set; }

        // Reverse navigation
        public List<SalesOrderDetail> SalesOrderDetails { get; set; }
        public List<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }

        public SalesOrderHeader()
        {
            this.SalesOrderDetails = new List<SalesOrderDetail>();
            this.SalesOrderHeaderSalesReasons = new List<SalesOrderHeaderSalesReason>();
        }
    }
}