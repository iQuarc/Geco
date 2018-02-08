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
    public partial class AdventureWorksContext : DbContext
    {
        public IConfigurationRoot Configuration {get;}

        public AdventureWorksContext(IConfigurationRoot configuration)
        {
            this.Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt =>
            {
                opt.EnableRetryOnFailure();
            });

            optionsBuilder.ConfigureWarnings(w =>
            {
                w.Ignore(RelationalEventId.AmbientTransactionWarning);
                w.Ignore(RelationalEventId.QueryClientEvaluationWarning);
            });
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
        public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public virtual DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<CountryRegion> CountryRegions { get; set; }
        public virtual DbSet<EmailAddress> EmailAddresses { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonJson> PersonJsons { get; set; }
        public virtual DbSet<PersonTemporal> PersonTemporals { get; set; }
        public virtual DbSet<PersonPhone> PersonPhones { get; set; }
        public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Person");
                entity.HasKey(e => e.AddressID);

                entity.Property(e => e.AddressID)
                    .HasColumnName("AddressID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("AddressLine1")
                    .HasColumnType("nvarchar(60)")
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("AddressLine2")
                    .HasColumnType("nvarchar(60)")
                    .HasMaxLength(60);

                entity.Property(e => e.City)
                    .HasColumnName("City")
                    .HasColumnType("nvarchar(30)")
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("PostalCode")
                    .HasColumnType("nvarchar(15)")
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.StateProvinces)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(p => p.StateProvinceID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Address_StateProvince_StateProvinceID");

            });
            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.ToTable("AddressType", "Person");
                entity.HasKey(e => e.AddressTypeID);

                entity.Property(e => e.AddressTypeID)
                    .HasColumnName("AddressTypeID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<BusinessEntity>(entity =>
            {
                entity.ToTable("BusinessEntity", "Person");
                entity.HasKey(e => e.BusinessEntityID);

                entity.Property(e => e.BusinessEntityID)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<BusinessEntityAddress>(entity =>
            {
                entity.ToTable("BusinessEntityAddress", "Person");
                entity.HasKey(e => new { e.BusinessEntityID, e.AddressID, e.AddressTypeID });

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Addresses)
                    .WithMany(p => p.BusinessEntityAddresses)
                    .HasForeignKey(p => p.AddressID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityAddress_Address_AddressID");

                entity.HasOne(e => e.AddressTypes)
                    .WithMany(p => p.BusinessEntityAddresses)
                    .HasForeignKey(p => p.AddressTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityAddress_AddressType_AddressTypeID");

                entity.HasOne(e => e.BusinessEntities)
                    .WithMany(p => p.BusinessEntityAddresses)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID");

            });
            modelBuilder.Entity<BusinessEntityContact>(entity =>
            {
                entity.ToTable("BusinessEntityContact", "Person");
                entity.HasKey(e => new { e.BusinessEntityID, e.PersonID, e.ContactTypeID });

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.BusinessEntities)
                    .WithMany(p => p.BusinessEntityContacts)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityContact_BusinessEntity_BusinessEntityID");

                entity.HasOne(e => e.ContactTypes)
                    .WithMany(p => p.BusinessEntityContacts)
                    .HasForeignKey(p => p.ContactTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityContact_ContactType_ContactTypeID");

                entity.HasOne(e => e.People)
                    .WithMany(p => p.BusinessEntityContacts)
                    .HasForeignKey(p => p.PersonID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityContact_Person_PersonID");

            });
            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.ToTable("ContactType", "Person");
                entity.HasKey(e => e.ContactTypeID);

                entity.Property(e => e.ContactTypeID)
                    .HasColumnName("ContactTypeID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<CountryRegion>(entity =>
            {
                entity.ToTable("CountryRegion", "Person");
                entity.HasKey(e => e.CountryRegionCode);

                entity.Property(e => e.CountryRegionCode)
                    .HasColumnName("CountryRegionCode")
                    .HasColumnType("nvarchar(3)")
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<EmailAddress>(entity =>
            {
                entity.ToTable("EmailAddress", "Person");
                entity.HasKey(e => new { e.BusinessEntityID, e.EmailAddressID });

                entity.Property(e => e.EmailAddressID)
                    .HasColumnName("EmailAddressID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmailAddress1)
                    .HasColumnName("EmailAddress")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.People)
                    .WithMany(p => p.EmailAddresses)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EmailAddress_Person_BusinessEntityID");

            });
            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("Password", "Person");
                entity.HasKey(e => e.BusinessEntityID);

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("PasswordHash")
                    .HasColumnType("varchar(128)")
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("PasswordSalt")
                    .HasColumnType("varchar(10)")
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.People)
                    .WithMany(p => p.Passwords)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Password_Person_BusinessEntityID");

            });
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Person");
                entity.HasKey(e => e.BusinessEntityID);

                entity.Property(e => e.BusinessEntityID)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int");

                entity.Property(e => e.PersonType)
                    .HasColumnName("PersonType")
                    .HasColumnType("nchar(2)")
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.NameStyle)
                    .HasColumnName("NameStyle")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .HasColumnType("nvarchar(8)")
                    .HasMaxLength(8);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MiddleName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Suffix)
                    .HasColumnName("Suffix")
                    .HasColumnType("nvarchar(10)")
                    .HasMaxLength(10);

                entity.Property(e => e.EmailPromotion)
                    .HasColumnName("EmailPromotion")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AdditionalContactInfo)
                    .HasColumnName("AdditionalContactInfo")
                    .HasColumnType("xml");

                entity.Property(e => e.Demographics)
                    .HasColumnName("Demographics")
                    .HasColumnType("xml");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.BusinessEntities)
                    .WithMany(p => p.People)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Person_BusinessEntity_BusinessEntityID");

            });
            modelBuilder.Entity<PersonJson>(entity =>
            {
                entity.ToTable("Person_json", "Person");
                entity.HasKey(e => e.PersonID);

                entity.Property(e => e.PersonID)
                    .HasColumnName("PersonID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonType)
                    .HasColumnName("PersonType")
                    .HasColumnType("nchar(2)")
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.NameStyle)
                    .HasColumnName("NameStyle")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .HasColumnType("nvarchar(8)")
                    .HasMaxLength(8);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MiddleName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Suffix)
                    .HasColumnName("Suffix")
                    .HasColumnType("nvarchar(10)")
                    .HasMaxLength(10);

                entity.Property(e => e.EmailPromotion)
                    .HasColumnName("EmailPromotion")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AdditionalContactInfo)
                    .HasColumnName("AdditionalContactInfo")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.Demographics)
                    .HasColumnName("Demographics")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<PersonTemporal>(entity =>
            {
                entity.ToTable("Person_Temporal", "Person");
                entity.HasKey(e => e.BusinessEntityID);

                entity.Property(e => e.BusinessEntityID)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int");

                entity.Property(e => e.PersonType)
                    .HasColumnName("PersonType")
                    .HasColumnType("nchar(2)")
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.NameStyle)
                    .HasColumnName("NameStyle")
                    .HasColumnType("bit");

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .HasColumnType("nvarchar(8)")
                    .HasMaxLength(8);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MiddleName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Suffix)
                    .HasColumnName("Suffix")
                    .HasColumnType("nvarchar(10)")
                    .HasMaxLength(10);

                entity.Property(e => e.EmailPromotion)
                    .HasColumnName("EmailPromotion")
                    .HasColumnType("int");

                entity.Property(e => e.ValidFrom)
                    .HasColumnName("ValidFrom")
                    .HasColumnType("datetime2");

                entity.Property(e => e.ValidTo)
                    .HasColumnName("ValidTo")
                    .HasColumnType("datetime2");

            });
            modelBuilder.Entity<PersonPhone>(entity =>
            {
                entity.ToTable("PersonPhone", "Person");
                entity.HasKey(e => new { e.BusinessEntityID, e.PhoneNumber, e.PhoneNumberTypeID });

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .HasColumnType("nvarchar(25)")
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.PhoneNumberTypes)
                    .WithMany(p => p.PersonPhones)
                    .HasForeignKey(p => p.PhoneNumberTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID");

                entity.HasOne(e => e.People)
                    .WithMany(p => p.PersonPhones)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PersonPhone_Person_BusinessEntityID");

            });
            modelBuilder.Entity<PhoneNumberType>(entity =>
            {
                entity.ToTable("PhoneNumberType", "Person");
                entity.HasKey(e => e.PhoneNumberTypeID);

                entity.Property(e => e.PhoneNumberTypeID)
                    .HasColumnName("PhoneNumberTypeID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<StateProvince>(entity =>
            {
                entity.ToTable("StateProvince", "Person");
                entity.HasKey(e => e.StateProvinceID);

                entity.Property(e => e.StateProvinceID)
                    .HasColumnName("StateProvinceID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StateProvinceCode)
                    .HasColumnName("StateProvinceCode")
                    .HasColumnType("nchar(3)")
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.IsOnlyStateProvinceFlag)
                    .HasColumnName("IsOnlyStateProvinceFlag")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TerritoryID)
                    .HasColumnName("TerritoryID")
                    .HasColumnType("int");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.CountryRegions)
                    .WithMany(p => p.StateProvinces)
                    .HasForeignKey(p => p.CountryRegionCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StateProvince_CountryRegion_CountryRegionCode");

            });
        }
    }
}