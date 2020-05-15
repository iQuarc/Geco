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
    [GeneratedCode("Geco", "1.0.5.0")]
    public partial class Address
    {
        // Key Properties
        public int AddressID { get; set; }

        // Scalar Properties
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public StateProvince StateProvince { get; set; }

        // Reverse navigation
        public List<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public List<SalesOrderHeader> SalesOrderHeadersBillToAddress { get; set; }
        public List<SalesOrderHeader> SalesOrderHeadersShipToAddress { get; set; }

        public Address()
        {
            this.BusinessEntityAddresses = new List<BusinessEntityAddress>();
            this.SalesOrderHeadersBillToAddress = new List<SalesOrderHeader>();
            this.SalesOrderHeadersShipToAddress = new List<SalesOrderHeader>();
        }
    }
}