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
    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class Currency
    {
        // Key Properties
        public string CurrencyCode { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public List<CurrencyRate> CurrencyRatesFromCurrencyCode { get; set; }
        public List<CurrencyRate> CurrencyRatesToCurrencyCode { get; set; }

        public Currency()
        {
            this.CountryRegionCurrencies = new List<CountryRegionCurrency>();
            this.CurrencyRatesFromCurrencyCode = new List<CurrencyRate>();
            this.CurrencyRatesToCurrencyCode = new List<CurrencyRate>();
        }
    }
}