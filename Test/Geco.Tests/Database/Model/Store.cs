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
    [GeneratedCode("Geco", "1.0.5.0")]
    public partial class Store
    {
        // Key Properties
        public int BusinessEntityID { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public int? SalesPersonID { get; set; }
        public string Demographics { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public BusinessEntity BusinessEntity { get; set; }
        public SalesPerson SalesPerson { get; set; }

        // Reverse navigation
        public List<Customer> Customers { get; set; }

        public Store()
        {
            this.Customers = new List<Customer>();
        }
    }
}