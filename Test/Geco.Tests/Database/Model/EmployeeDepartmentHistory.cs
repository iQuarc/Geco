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
    public partial class EmployeeDepartmentHistory
    {
        // Key Properties
        public int BusinessEntityID { get; set; }
        public short DepartmentID { get; set; }
        public byte ShiftID { get; set; }
        public DateTime StartDate { get; set; }

        // Scalar Properties
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Employee Employee { get; set; } //Column: BusinessEntityID, FK: FK_EmployeeDepartmentHistory_Employee_BusinessEntityID
        public Department Department { get; set; } //Column: DepartmentID, FK: FK_EmployeeDepartmentHistory_Department_DepartmentID
        public Shift Shift { get; set; } //Column: ShiftID, FK: FK_EmployeeDepartmentHistory_Shift_ShiftID

    }
}