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
    public partial class CountryRegionCurrency
    {
        // Key Properties
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }

        // Scalar Properties
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public CountryRegion CountryRegion { get; set; } //Column: CountryRegionCode, FK: FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
        public Currency Currency { get; set; } //Column: CurrencyCode, FK: FK_CountryRegionCurrency_Currency_CurrencyCode

    }
}