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
    public partial class BusinessEntityContact
    {
        // Key Properties
        public int BusinessEntityID { get; set; }
        public int PersonID { get; set; }
        public int ContactTypeID { get; set; }

        // Scalar Properties
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public BusinessEntity BusinessEntity { get; set; } //Column: BusinessEntityID, FK: FK_BusinessEntityContact_BusinessEntity_BusinessEntityID
        public ContactType ContactType { get; set; } //Column: ContactTypeID, FK: FK_BusinessEntityContact_ContactType_ContactTypeID
        public Person Person { get; set; } //Column: PersonID, FK: FK_BusinessEntityContact_Person_PersonID

    }
}