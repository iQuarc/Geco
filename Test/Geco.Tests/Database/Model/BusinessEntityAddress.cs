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
    public partial class BusinessEntityAddress
    {
        // Key Properties
        public int BusinessEntityID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }

        // Scalar Properties
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Address Address { get; set; } //Column: AddressID, FK: FK_BusinessEntityAddress_Address_AddressID
        public AddressType AddressType { get; set; } //Column: AddressTypeID, FK: FK_BusinessEntityAddress_AddressType_AddressTypeID
        public BusinessEntity BusinessEntity { get; set; } //Column: BusinessEntityID, FK: FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID

    }
}