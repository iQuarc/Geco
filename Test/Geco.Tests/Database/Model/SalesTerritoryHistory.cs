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
    public partial class SalesTerritoryHistory
    {
        // Key Properties
        public int BusinessEntityID { get; set; }
        public int TerritoryID { get; set; }
        public DateTime StartDate { get; set; }

        // Scalar Properties
        public DateTime? EndDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public SalesPerson SalesPerson { get; set; } //Column: BusinessEntityID, FK: FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID
        public SalesTerritory SalesTerritory { get; set; } //Column: TerritoryID, FK: FK_SalesTerritoryHistory_SalesTerritory_TerritoryID

    }
}