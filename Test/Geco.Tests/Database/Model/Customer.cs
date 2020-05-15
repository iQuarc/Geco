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
    public partial class Customer
    {
        // Key Properties
        public int CustomerID { get; set; }

        // Scalar Properties
        public int? PersonID { get; set; }
        public int? StoreID { get; set; }
        public int? TerritoryID { get; set; }
        public string AccountNumber { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Person Person { get; set; } //Column: PersonID, FK: FK_Customer_Person_PersonID
        public Store Store { get; set; } //Column: StoreID, FK: FK_Customer_Store_StoreID
        public SalesTerritory SalesTerritory { get; set; } //Column: TerritoryID, FK: FK_Customer_SalesTerritory_TerritoryID

        // Reverse navigation
        public List<SalesOrderHeader> SalesOrderHeaders { get; set; }

        public Customer()
        {
            this.SalesOrderHeaders = new List<SalesOrderHeader>();
        }
    }
}