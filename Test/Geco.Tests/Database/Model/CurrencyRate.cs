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
    public partial class CurrencyRate
    {
        // Key Properties
        public int CurrencyRateID { get; set; }

        // Scalar Properties
        public DateTime CurrencyRateDate { get; set; }
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal AverageRate { get; set; }
        public decimal EndOfDayRate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Currency CurrencyFromCurrencyCode { get; set; } //Column: FromCurrencyCode, FK: FK_CurrencyRate_Currency_FromCurrencyCode
        public Currency CurrencyToCurrencyCode { get; set; } //Column: ToCurrencyCode, FK: FK_CurrencyRate_Currency_ToCurrencyCode

        // Reverse navigation
        public List<SalesOrderHeader> SalesOrderHeaders { get; set; }

        public CurrencyRate()
        {
            this.SalesOrderHeaders = new List<SalesOrderHeader>();
        }
    }
}