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
    public partial class CreditCard
    {
        // Key Properties
        public int CreditCardID { get; set; }

        // Scalar Properties
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        public List<PersonCreditCard> PersonCreditCards { get; set; }
        public List<SalesOrderHeader> SalesOrderHeaders { get; set; }

        public CreditCard()
        {
            this.PersonCreditCards = new List<PersonCreditCard>();
            this.SalesOrderHeaders = new List<SalesOrderHeader>();
        }
    }
}