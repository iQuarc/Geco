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
    [GeneratedCode("Geco", "1.0.4.0")]
    public partial class Person
    {
        // Key Properties
        public int BusinessEntityID { get; set; }

        // Scalar Properties
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        public string AdditionalContactInfo { get; set; }
        public string Demographics { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        public BusinessEntity BusinessEntities { get; set; }

        // Reverse navigation
        public List<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public List<Customer> Customers { get; set; }
        public List<EmailAddress> EmailAddresses { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Password> Passwords { get; set; }
        public List<PersonCreditCard> PersonCreditCards { get; set; }
        public List<PersonPhone> PersonPhones { get; set; }

        public Person()
        {
            this.BusinessEntityContacts = new List<BusinessEntityContact>();
            this.Customers = new List<Customer>();
            this.EmailAddresses = new List<EmailAddress>();
            this.Employees = new List<Employee>();
            this.Passwords = new List<Password>();
            this.PersonCreditCards = new List<PersonCreditCard>();
            this.PersonPhones = new List<PersonPhone>();
        }
    }
}