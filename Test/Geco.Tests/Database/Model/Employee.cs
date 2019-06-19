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
    [GeneratedCode("Geco", "1.0.8.0")]
    public partial class Employee
    {
        // Key Properties
        public int BusinessEntityID { get; set; }

        // Scalar Properties
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        public short? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public Person Person { get; set; }

        // Reverse navigation
        public List<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public List<EmployeePayHistory> EmployeePayHistories { get; set; }
        public List<JobCandidate> JobCandidates { get; set; }
        public List<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public List<SalesPerson> SalesPeople { get; set; }

        public Employee()
        {
            this.EmployeeDepartmentHistories = new List<EmployeeDepartmentHistory>();
            this.EmployeePayHistories = new List<EmployeePayHistory>();
            this.JobCandidates = new List<JobCandidate>();
            this.PurchaseOrderHeaders = new List<PurchaseOrderHeader>();
            this.SalesPeople = new List<SalesPerson>();
        }
    }
}