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
    public partial class PersonPhone
    {
        // Key Properties
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }

        // Scalar Properties
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Person Person { get; set; } //Column: BusinessEntityID, FK: FK_PersonPhone_Person_BusinessEntityID
        public PhoneNumberType PhoneNumberType { get; set; } //Column: PhoneNumberTypeID, FK: FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID

    }
}