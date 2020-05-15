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
    public partial class StateProvince
    {
        // Key Properties
        public int StateProvinceID { get; set; }

        // Scalar Properties
        public string StateProvinceCode { get; set; }
        public string CountryRegionCode { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }
        public string Name { get; set; }
        public int TerritoryID { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public CountryRegion CountryRegion { get; set; } //Column: CountryRegionCode, FK: FK_StateProvince_CountryRegion_CountryRegionCode
        public SalesTerritory SalesTerritory { get; set; } //Column: TerritoryID, FK: FK_StateProvince_SalesTerritory_TerritoryID

        // Reverse navigation
        public List<Address> Addresses { get; set; }
        public List<SalesTaxRate> SalesTaxRates { get; set; }

        public StateProvince()
        {
            this.Addresses = new List<Address>();
            this.SalesTaxRates = new List<SalesTaxRate>();
        }
    }
}