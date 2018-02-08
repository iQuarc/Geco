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
using Newtonsoft.Json;

namespace Geco.Tests.DataSync.Model
{
    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class Address
    {
        // Key Properties
        public int AddressID { get; set; }

        // Scalar Properties
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        [JsonIgnore]
        public StateProvince StateProvinces { get; set; }

        // Reverse navigation
        [JsonIgnore]
        public List<BusinessEntityAddress> BusinessEntityAddresses { get; set; }

        public Address()
        {
            this.BusinessEntityAddresses = new List<BusinessEntityAddress>();
        }
    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class AddressType
    {
        // Key Properties
        public int AddressTypeID { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        [JsonIgnore]
        public List<BusinessEntityAddress> BusinessEntityAddresses { get; set; }

        public AddressType()
        {
            this.BusinessEntityAddresses = new List<BusinessEntityAddress>();
        }
    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class BusinessEntity
    {
        // Key Properties
        public int BusinessEntityID { get; set; }

        // Scalar Properties
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        [JsonIgnore]
        public List<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        [JsonIgnore]
        public List<BusinessEntityContact> BusinessEntityContacts { get; set; }
        [JsonIgnore]
        public List<Person> People { get; set; }

        public BusinessEntity()
        {
            this.BusinessEntityAddresses = new List<BusinessEntityAddress>();
            this.BusinessEntityContacts = new List<BusinessEntityContact>();
            this.People = new List<Person>();
        }
    }

    [GeneratedCode("Geco", "1.0.3.0")]
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
        [JsonIgnore]
        public Address Addresses { get; set; }
        [JsonIgnore]
        public AddressType AddressTypes { get; set; }
        [JsonIgnore]
        public BusinessEntity BusinessEntities { get; set; }

    }

    [GeneratedCode("Geco", "1.0.3.0")]
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
        [JsonIgnore]
        public BusinessEntity BusinessEntities { get; set; }
        [JsonIgnore]
        public ContactType ContactTypes { get; set; }
        [JsonIgnore]
        public Person People { get; set; }

    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class ContactType
    {
        // Key Properties
        public int ContactTypeID { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        [JsonIgnore]
        public List<BusinessEntityContact> BusinessEntityContacts { get; set; }

        public ContactType()
        {
            this.BusinessEntityContacts = new List<BusinessEntityContact>();
        }
    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class CountryRegion
    {
        // Key Properties
        public string CountryRegionCode { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        [JsonIgnore]
        public List<StateProvince> StateProvinces { get; set; }

        public CountryRegion()
        {
            this.StateProvinces = new List<StateProvince>();
        }
    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class EmailAddress
    {
        // Key Properties
        public int BusinessEntityID { get; set; }
        public int EmailAddressID { get; set; }

        // Scalar Properties
        public string EmailAddress1 { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        [JsonIgnore]
        public Person People { get; set; }

    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class Password
    {
        // Key Properties
        public int BusinessEntityID { get; set; }

        // Scalar Properties
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        [JsonIgnore]
        public Person People { get; set; }

    }

    [GeneratedCode("Geco", "1.0.3.0")]
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
        [JsonIgnore]
        public BusinessEntity BusinessEntities { get; set; }

        // Reverse navigation
        [JsonIgnore]
        public List<BusinessEntityContact> BusinessEntityContacts { get; set; }
        [JsonIgnore]
        public List<EmailAddress> EmailAddresses { get; set; }
        [JsonIgnore]
        public List<Password> Passwords { get; set; }
        [JsonIgnore]
        public List<PersonPhone> PersonPhones { get; set; }

        public Person()
        {
            this.BusinessEntityContacts = new List<BusinessEntityContact>();
            this.EmailAddresses = new List<EmailAddress>();
            this.Passwords = new List<Password>();
            this.PersonPhones = new List<PersonPhone>();
        }
    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class PersonJson
    {
        // Key Properties
        public int PersonID { get; set; }

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

    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class PersonTemporal
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
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class PersonPhone
    {
        // Key Properties
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }

        // Scalar Properties
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        [JsonIgnore]
        public Person People { get; set; }
        [JsonIgnore]
        public PhoneNumberType PhoneNumberTypes { get; set; }

    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class PhoneNumberType
    {
        // Key Properties
        public int PhoneNumberTypeID { get; set; }

        // Scalar Properties
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Reverse navigation
        [JsonIgnore]
        public List<PersonPhone> PersonPhones { get; set; }

        public PhoneNumberType()
        {
            this.PersonPhones = new List<PersonPhone>();
        }
    }

    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class StateProvince
    {
        // Key Properties
        public int StateProvinceID { get; set; }

        // Scalar Properties
        public string StateProvinceCode { get; set; }
        public string CountryRegionCode { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }
        public string Name { get; set; }
        public int TerritoryID { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Foreign keys
        [JsonIgnore]
        public CountryRegion CountryRegions { get; set; }

        // Reverse navigation
        [JsonIgnore]
        public List<Address> Addresses { get; set; }

        public StateProvince()
        {
            this.Addresses = new List<Address>();
        }
    }

}