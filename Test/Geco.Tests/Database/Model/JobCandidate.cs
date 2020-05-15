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
    public partial class JobCandidate
    {
        // Key Properties
        public int JobCandidateID { get; set; }

        // Scalar Properties
        public int? BusinessEntityID { get; set; }
        public string Resume { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Employee Employee { get; set; } //Column: BusinessEntityID, FK: FK_JobCandidate_Employee_BusinessEntityID

    }
}