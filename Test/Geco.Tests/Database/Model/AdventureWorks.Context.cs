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
                //opt.EnableRetryOnFailure();
            });

            optionsBuilder.ConfigureWarnings(w =>
            {
                w.Ignore(RelationalEventId.AmbientTransactionWarning);
                w.Ignore(RelationalEventId.QueryClientEvaluationWarning);
            });
        }

        public virtual DbSet<Address> Addresses => this.Set<Address>();
        public virtual DbSet<AddressType> AddressTypes => this.Set<AddressType>();
        public virtual DbSet<AWBuildVersion> AWBuildVersions => this.Set<AWBuildVersion>();
        public virtual DbSet<BillOfMaterial> BillOfMaterials => this.Set<BillOfMaterial>();
        public virtual DbSet<BusinessEntity> BusinessEntities => this.Set<BusinessEntity>();
        public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses => this.Set<BusinessEntityAddress>();
        public virtual DbSet<BusinessEntityContact> BusinessEntityContacts => this.Set<BusinessEntityContact>();
        public virtual DbSet<ContactType> ContactTypes => this.Set<ContactType>();
        public virtual DbSet<CountryRegion> CountryRegions => this.Set<CountryRegion>();
        public virtual DbSet<CountryRegionCurrency> CountryRegionCurrencies => this.Set<CountryRegionCurrency>();
        public virtual DbSet<CreditCard> CreditCards => this.Set<CreditCard>();
        public virtual DbSet<Culture> Cultures => this.Set<Culture>();
        public virtual DbSet<Currency> Currencies => this.Set<Currency>();
        public virtual DbSet<CurrencyRate> CurrencyRates => this.Set<CurrencyRate>();
        public virtual DbSet<Customer> Customers => this.Set<Customer>();
        public virtual DbSet<DatabaseLog> DatabaseLogs => this.Set<DatabaseLog>();
        public virtual DbSet<Department> Departments => this.Set<Department>();
        public virtual DbSet<EmailAddress> EmailAddresses => this.Set<EmailAddress>();
        public virtual DbSet<Employee> Employees => this.Set<Employee>();
        public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories => this.Set<EmployeeDepartmentHistory>();
        public virtual DbSet<EmployeePayHistory> EmployeePayHistories => this.Set<EmployeePayHistory>();
        public virtual DbSet<ErrorLog> ErrorLogs => this.Set<ErrorLog>();
        public virtual DbSet<Illustration> Illustrations => this.Set<Illustration>();
        public virtual DbSet<JobCandidate> JobCandidates => this.Set<JobCandidate>();
        public virtual DbSet<Location> Locations => this.Set<Location>();
        public virtual DbSet<Password> Passwords => this.Set<Password>();
        public virtual DbSet<Person> People => this.Set<Person>();
        public virtual DbSet<PersonCreditCard> PersonCreditCards => this.Set<PersonCreditCard>();
        public virtual DbSet<PersonPhone> PersonPhones => this.Set<PersonPhone>();
        public virtual DbSet<PhoneNumberType> PhoneNumberTypes => this.Set<PhoneNumberType>();
        public virtual DbSet<Product> Products => this.Set<Product>();
        public virtual DbSet<ProductCategory> ProductCategories => this.Set<ProductCategory>();
        public virtual DbSet<ProductCostHistory> ProductCostHistories => this.Set<ProductCostHistory>();
        public virtual DbSet<ProductDescription> ProductDescriptions => this.Set<ProductDescription>();
        public virtual DbSet<ProductDocument> ProductDocuments => this.Set<ProductDocument>();
        public virtual DbSet<ProductInventory> ProductInventories => this.Set<ProductInventory>();
        public virtual DbSet<ProductListPriceHistory> ProductListPriceHistories => this.Set<ProductListPriceHistory>();
        public virtual DbSet<ProductModel> ProductModels => this.Set<ProductModel>();
        public virtual DbSet<ProductModelIllustration> ProductModelIllustrations => this.Set<ProductModelIllustration>();
        public virtual DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures => this.Set<ProductModelProductDescriptionCulture>();
        public virtual DbSet<ProductPhoto> ProductPhotos => this.Set<ProductPhoto>();
        public virtual DbSet<ProductProductPhoto> ProductProductPhotos => this.Set<ProductProductPhoto>();
        public virtual DbSet<ProductReview> ProductReviews => this.Set<ProductReview>();
        public virtual DbSet<ProductSubcategory> ProductSubcategories => this.Set<ProductSubcategory>();
        public virtual DbSet<ProductVendor> ProductVendors => this.Set<ProductVendor>();
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails => this.Set<PurchaseOrderDetail>();
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders => this.Set<PurchaseOrderHeader>();
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails => this.Set<SalesOrderDetail>();
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders => this.Set<SalesOrderHeader>();
        public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons => this.Set<SalesOrderHeaderSalesReason>();
        public virtual DbSet<SalesPerson> SalesPeople => this.Set<SalesPerson>();
        public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories => this.Set<SalesPersonQuotaHistory>();
        public virtual DbSet<SalesReason> SalesReasons => this.Set<SalesReason>();
        public virtual DbSet<SalesTaxRate> SalesTaxRates => this.Set<SalesTaxRate>();
        public virtual DbSet<SalesTerritory> SalesTerritories => this.Set<SalesTerritory>();
        public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories => this.Set<SalesTerritoryHistory>();
        public virtual DbSet<ScrapReason> ScrapReasons => this.Set<ScrapReason>();
        public virtual DbSet<Shift> Shifts => this.Set<Shift>();
        public virtual DbSet<ShipMethod> ShipMethods => this.Set<ShipMethod>();
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems => this.Set<ShoppingCartItem>();
        public virtual DbSet<SpecialOffer> SpecialOffers => this.Set<SpecialOffer>();
        public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts => this.Set<SpecialOfferProduct>();
        public virtual DbSet<StateProvince> StateProvinces => this.Set<StateProvince>();
        public virtual DbSet<Store> Stores => this.Set<Store>();
        public virtual DbSet<TransactionHistory> TransactionHistories => this.Set<TransactionHistory>();
        public virtual DbSet<TransactionHistoryArchive> TransactionHistoryArchives => this.Set<TransactionHistoryArchive>();
        public virtual DbSet<UnitMeasure> UnitMeasures => this.Set<UnitMeasure>();
        public virtual DbSet<Vendor> Vendors => this.Set<Vendor>();
        public virtual DbSet<WorkOrder> WorkOrders => this.Set<WorkOrder>();
        public virtual DbSet<WorkOrderRouting> WorkOrderRoutings => this.Set<WorkOrderRouting>();

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

                entity.HasOne(e => e.StateProvince)
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
            modelBuilder.Entity<AWBuildVersion>(entity =>
            {
                entity.ToTable("AWBuildVersion", "dbo");
                entity.HasKey(e => e.SystemInformationID);

                entity.Property(e => e.SystemInformationID)
                    .HasColumnName("SystemInformationID")
                    .HasColumnType("tinyint")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DatabaseVersion)
                    .HasColumnName("Database Version")
                    .HasColumnType("nvarchar(25)")
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.VersionDate)
                    .HasColumnName("VersionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<BillOfMaterial>(entity =>
            {
                entity.ToTable("BillOfMaterials", "Production");
                entity.HasKey(e => e.BillOfMaterialsID);

                entity.Property(e => e.BillOfMaterialsID)
                    .HasColumnName("BillOfMaterialsID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BOMLevel)
                    .HasColumnName("BOMLevel")
                    .HasColumnType("smallint");

                entity.Property(e => e.PerAssemblyQty)
                    .HasColumnName("PerAssemblyQty")
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("1.00");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.ProductAssembly)
                    .WithMany(p => p.BillOfMaterialsProductAssembly)
                    .HasForeignKey(p => p.ProductAssemblyID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BillOfMaterials_Product_ProductAssemblyID");

                entity.HasOne(e => e.Component)
                    .WithMany(p => p.BillOfMaterialsComponent)
                    .HasForeignKey(p => p.ComponentID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BillOfMaterials_Product_ComponentID");

                entity.HasOne(e => e.UnitMeasure)
                    .WithMany(p => p.BillOfMaterials)
                    .HasForeignKey(p => p.UnitMeasureCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BillOfMaterials_UnitMeasure_UnitMeasureCode");

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

                entity.HasOne(e => e.Address)
                    .WithMany(p => p.BusinessEntityAddresses)
                    .HasForeignKey(p => p.AddressID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityAddress_Address_AddressID");

                entity.HasOne(e => e.AddressType)
                    .WithMany(p => p.BusinessEntityAddresses)
                    .HasForeignKey(p => p.AddressTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityAddress_AddressType_AddressTypeID");

                entity.HasOne(e => e.BusinessEntity)
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

                entity.HasOne(e => e.BusinessEntity)
                    .WithMany(p => p.BusinessEntityContacts)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityContact_BusinessEntity_BusinessEntityID");

                entity.HasOne(e => e.ContactType)
                    .WithMany(p => p.BusinessEntityContacts)
                    .HasForeignKey(p => p.ContactTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BusinessEntityContact_ContactType_ContactTypeID");

                entity.HasOne(e => e.Person)
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
            modelBuilder.Entity<CountryRegionCurrency>(entity =>
            {
                entity.ToTable("CountryRegionCurrency", "Sales");
                entity.HasKey(e => new { e.CountryRegionCode, e.CurrencyCode });

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.CountryRegion)
                    .WithMany(p => p.CountryRegionCurrencies)
                    .HasForeignKey(p => p.CountryRegionCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CountryRegionCurrency_CountryRegion_CountryRegionCode");

                entity.HasOne(e => e.Currency)
                    .WithMany(p => p.CountryRegionCurrencies)
                    .HasForeignKey(p => p.CurrencyCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CountryRegionCurrency_Currency_CurrencyCode");

            });
            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("CreditCard", "Sales");
                entity.HasKey(e => e.CreditCardID);

                entity.Property(e => e.CreditCardID)
                    .HasColumnName("CreditCardID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CardType)
                    .HasColumnName("CardType")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CardNumber)
                    .HasColumnName("CardNumber")
                    .HasColumnType("nvarchar(25)")
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ExpMonth)
                    .HasColumnName("ExpMonth")
                    .HasColumnType("tinyint");

                entity.Property(e => e.ExpYear)
                    .HasColumnName("ExpYear")
                    .HasColumnType("smallint");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("Culture", "Production");
                entity.HasKey(e => e.CultureID);

                entity.Property(e => e.CultureID)
                    .HasColumnName("CultureID")
                    .HasColumnType("nchar(6)")
                    .IsRequired()
                    .HasMaxLength(6);

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
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency", "Sales");
                entity.HasKey(e => e.CurrencyCode);

                entity.Property(e => e.CurrencyCode)
                    .HasColumnName("CurrencyCode")
                    .HasColumnType("nchar(3)")
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
            modelBuilder.Entity<CurrencyRate>(entity =>
            {
                entity.ToTable("CurrencyRate", "Sales");
                entity.HasKey(e => e.CurrencyRateID);

                entity.Property(e => e.CurrencyRateID)
                    .HasColumnName("CurrencyRateID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CurrencyRateDate)
                    .HasColumnName("CurrencyRateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.AverageRate)
                    .HasColumnName("AverageRate")
                    .HasColumnType("money");

                entity.Property(e => e.EndOfDayRate)
                    .HasColumnName("EndOfDayRate")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.CurrencyFromCurrencyCode)
                    .WithMany(p => p.CurrencyRatesFromCurrencyCode)
                    .HasForeignKey(p => p.FromCurrencyCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CurrencyRate_Currency_FromCurrencyCode");

                entity.HasOne(e => e.CurrencyToCurrencyCode)
                    .WithMany(p => p.CurrencyRatesToCurrencyCode)
                    .HasForeignKey(p => p.ToCurrencyCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CurrencyRate_Currency_ToCurrencyCode");

            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Sales");
                entity.HasKey(e => e.CustomerID);

                entity.Property(e => e.CustomerID)
                    .HasColumnName("CustomerID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("AccountNumber")
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

                entity.HasOne(e => e.SalesTerritory)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(p => p.TerritoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Customer_SalesTerritory_TerritoryID");

                entity.HasOne(e => e.Store)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(p => p.StoreID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Customer_Store_StoreID");

                entity.HasOne(e => e.Person)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(p => p.PersonID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Customer_Person_PersonID");

            });
            modelBuilder.Entity<DatabaseLog>(entity =>
            {
                entity.ToTable("DatabaseLog", "dbo");
                entity.HasKey(e => e.DatabaseLogID);

                entity.Property(e => e.DatabaseLogID)
                    .HasColumnName("DatabaseLogID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PostTime)
                    .HasColumnName("PostTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatabaseUser)
                    .HasColumnName("DatabaseUser")
                    .HasColumnType("nvarchar(128)")
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Event)
                    .HasColumnName("Event")
                    .HasColumnType("nvarchar(128)")
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Schema)
                    .HasColumnName("Schema")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                entity.Property(e => e.Object)
                    .HasColumnName("Object")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                entity.Property(e => e.TSQL)
                    .HasColumnName("TSQL")
                    .HasColumnType("nvarchar(MAX)")
                    .IsRequired();

                entity.Property(e => e.XmlEvent)
                    .HasColumnName("XmlEvent")
                    .HasColumnType("xml");

            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "HumanResources");
                entity.HasKey(e => e.DepartmentID);

                entity.Property(e => e.DepartmentID)
                    .HasColumnName("DepartmentID")
                    .HasColumnType("smallint")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GroupName)
                    .HasColumnName("GroupName")
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

                entity.HasOne(e => e.Person)
                    .WithMany(p => p.EmailAddresses)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EmailAddress_Person_BusinessEntityID");

            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "HumanResources");
                entity.HasKey(e => e.BusinessEntityID);

                entity.Property(e => e.BusinessEntityID)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int");

                entity.Property(e => e.NationalIDNumber)
                    .HasColumnName("NationalIDNumber")
                    .HasColumnType("nvarchar(15)")
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.LoginID)
                    .HasColumnName("LoginID")
                    .HasColumnType("nvarchar(256)")
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.OrganizationLevel)
                    .HasColumnName("OrganizationLevel")
                    .HasColumnType("smallint");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("JobTitle")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("BirthDate")
                    .HasColumnType("date");

                entity.Property(e => e.MaritalStatus)
                    .HasColumnName("MaritalStatus")
                    .HasColumnType("nchar(1)")
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Gender)
                    .HasColumnName("Gender")
                    .HasColumnType("nchar(1)")
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.HireDate)
                    .HasColumnName("HireDate")
                    .HasColumnType("date");

                entity.Property(e => e.SalariedFlag)
                    .HasColumnName("SalariedFlag")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.VacationHours)
                    .HasColumnName("VacationHours")
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SickLeaveHours)
                    .HasColumnName("SickLeaveHours")
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CurrentFlag)
                    .HasColumnName("CurrentFlag")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Person)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Employee_Person_BusinessEntityID");

            });
            modelBuilder.Entity<EmployeeDepartmentHistory>(entity =>
            {
                entity.ToTable("EmployeeDepartmentHistory", "HumanResources");
                entity.HasKey(e => new { e.BusinessEntityID, e.DepartmentID, e.ShiftID, e.StartDate });

                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("date");

                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Shift)
                    .WithMany(p => p.EmployeeDepartmentHistories)
                    .HasForeignKey(p => p.ShiftID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EmployeeDepartmentHistory_Shift_ShiftID");

                entity.HasOne(e => e.Department)
                    .WithMany(p => p.EmployeeDepartmentHistories)
                    .HasForeignKey(p => p.DepartmentID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EmployeeDepartmentHistory_Department_DepartmentID");

                entity.HasOne(e => e.Employee)
                    .WithMany(p => p.EmployeeDepartmentHistories)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EmployeeDepartmentHistory_Employee_BusinessEntityID");

            });
            modelBuilder.Entity<EmployeePayHistory>(entity =>
            {
                entity.ToTable("EmployeePayHistory", "HumanResources");
                entity.HasKey(e => new { e.BusinessEntityID, e.RateChangeDate });

                entity.Property(e => e.RateChangeDate)
                    .HasColumnName("RateChangeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rate)
                    .HasColumnName("Rate")
                    .HasColumnType("money");

                entity.Property(e => e.PayFrequency)
                    .HasColumnName("PayFrequency")
                    .HasColumnType("tinyint");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Employee)
                    .WithMany(p => p.EmployeePayHistories)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EmployeePayHistory_Employee_BusinessEntityID");

            });
            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("ErrorLog", "dbo");
                entity.HasKey(e => e.ErrorLogID);

                entity.Property(e => e.ErrorLogID)
                    .HasColumnName("ErrorLogID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ErrorTime)
                    .HasColumnName("ErrorTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasColumnType("nvarchar(128)")
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ErrorNumber)
                    .HasColumnName("ErrorNumber")
                    .HasColumnType("int");

                entity.Property(e => e.ErrorSeverity)
                    .HasColumnName("ErrorSeverity")
                    .HasColumnType("int");

                entity.Property(e => e.ErrorState)
                    .HasColumnName("ErrorState")
                    .HasColumnType("int");

                entity.Property(e => e.ErrorProcedure)
                    .HasColumnName("ErrorProcedure")
                    .HasColumnType("nvarchar(126)")
                    .HasMaxLength(126);

                entity.Property(e => e.ErrorLine)
                    .HasColumnName("ErrorLine")
                    .HasColumnType("int");

                entity.Property(e => e.ErrorMessage)
                    .HasColumnName("ErrorMessage")
                    .HasColumnType("nvarchar(4000)")
                    .IsRequired()
                    .HasMaxLength(4000);

            });
            modelBuilder.Entity<Illustration>(entity =>
            {
                entity.ToTable("Illustration", "Production");
                entity.HasKey(e => e.IllustrationID);

                entity.Property(e => e.IllustrationID)
                    .HasColumnName("IllustrationID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Diagram)
                    .HasColumnName("Diagram")
                    .HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<JobCandidate>(entity =>
            {
                entity.ToTable("JobCandidate", "HumanResources");
                entity.HasKey(e => e.JobCandidateID);

                entity.Property(e => e.JobCandidateID)
                    .HasColumnName("JobCandidateID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Resume)
                    .HasColumnName("Resume")
                    .HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Employee)
                    .WithMany(p => p.JobCandidates)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_JobCandidate_Employee_BusinessEntityID");

            });
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "Production");
                entity.HasKey(e => e.LocationID);

                entity.Property(e => e.LocationID)
                    .HasColumnName("LocationID")
                    .HasColumnType("smallint")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CostRate)
                    .HasColumnName("CostRate")
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.Availability)
                    .HasColumnName("Availability")
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

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

                entity.HasOne(e => e.Person)
                    .WithMany(p => p.Passwords)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Password_Person_BusinessEntityID");

            });
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Person");
                entity.HasKey(e => e.BusinessEntityID);

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

                entity.HasOne(e => e.BusinessEntity)
                    .WithMany(p => p.People)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Person_BusinessEntity_BusinessEntityID");

            });
            modelBuilder.Entity<PersonCreditCard>(entity =>
            {
                entity.ToTable("PersonCreditCard", "Sales");
                entity.HasKey(e => new { e.BusinessEntityID, e.CreditCardID });

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.CreditCard)
                    .WithMany(p => p.PersonCreditCards)
                    .HasForeignKey(p => p.CreditCardID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PersonCreditCard_CreditCard_CreditCardID");

                entity.HasOne(e => e.Person)
                    .WithMany(p => p.PersonCreditCards)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PersonCreditCard_Person_BusinessEntityID");

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

                entity.HasOne(e => e.PhoneNumberType)
                    .WithMany(p => p.PersonPhones)
                    .HasForeignKey(p => p.PhoneNumberTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID");

                entity.HasOne(e => e.Person)
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
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Production");
                entity.HasKey(e => e.ProductID);

                entity.Property(e => e.ProductID)
                    .HasColumnName("ProductID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductNumber)
                    .HasColumnName("ProductNumber")
                    .HasColumnType("nvarchar(25)")
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.MakeFlag)
                    .HasColumnName("MakeFlag")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FinishedGoodsFlag)
                    .HasColumnName("FinishedGoodsFlag")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Color)
                    .HasColumnName("Color")
                    .HasColumnType("nvarchar(15)")
                    .HasMaxLength(15);

                entity.Property(e => e.SafetyStockLevel)
                    .HasColumnName("SafetyStockLevel")
                    .HasColumnType("smallint");

                entity.Property(e => e.ReorderPoint)
                    .HasColumnName("ReorderPoint")
                    .HasColumnType("smallint");

                entity.Property(e => e.StandardCost)
                    .HasColumnName("StandardCost")
                    .HasColumnType("money");

                entity.Property(e => e.ListPrice)
                    .HasColumnName("ListPrice")
                    .HasColumnType("money");

                entity.Property(e => e.Size)
                    .HasColumnName("Size")
                    .HasColumnType("nvarchar(5)")
                    .HasMaxLength(5);

                entity.Property(e => e.Weight)
                    .HasColumnName("Weight")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.DaysToManufacture)
                    .HasColumnName("DaysToManufacture")
                    .HasColumnType("int");

                entity.Property(e => e.ProductLine)
                    .HasColumnName("ProductLine")
                    .HasColumnType("nchar(2)")
                    .HasMaxLength(2);

                entity.Property(e => e.Class)
                    .HasColumnName("Class")
                    .HasColumnType("nchar(2)")
                    .HasMaxLength(2);

                entity.Property(e => e.Style)
                    .HasColumnName("Style")
                    .HasColumnType("nchar(2)")
                    .HasMaxLength(2);

                entity.Property(e => e.SellStartDate)
                    .HasColumnName("SellStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SellEndDate)
                    .HasColumnName("SellEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DiscontinuedDate)
                    .HasColumnName("DiscontinuedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.ProductModel)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.ProductModelID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Product_ProductModel_ProductModelID");

                entity.HasOne(e => e.ProductSubcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.ProductSubcategoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Product_ProductSubcategory_ProductSubcategoryID");

                entity.HasOne(e => e.UnitMeasureSizeUnitMeasureCode)
                    .WithMany(p => p.ProductsSizeUnitMeasureCode)
                    .HasForeignKey(p => p.SizeUnitMeasureCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Product_UnitMeasure_SizeUnitMeasureCode");

                entity.HasOne(e => e.UnitMeasureWeightUnitMeasureCode)
                    .WithMany(p => p.ProductsWeightUnitMeasureCode)
                    .HasForeignKey(p => p.WeightUnitMeasureCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Product_UnitMeasure_WeightUnitMeasureCode");

            });
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory", "Production");
                entity.HasKey(e => e.ProductCategoryID);

                entity.Property(e => e.ProductCategoryID)
                    .HasColumnName("ProductCategoryID")
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
            modelBuilder.Entity<ProductCostHistory>(entity =>
            {
                entity.ToTable("ProductCostHistory", "Production");
                entity.HasKey(e => new { e.ProductID, e.StartDate });

                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StandardCost)
                    .HasColumnName("StandardCost")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductCostHistories)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductCostHistory_Product_ProductID");

            });
            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.ToTable("ProductDescription", "Production");
                entity.HasKey(e => e.ProductDescriptionID);

                entity.Property(e => e.ProductDescriptionID)
                    .HasColumnName("ProductDescriptionID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(400)")
                    .IsRequired()
                    .HasMaxLength(400);

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
            modelBuilder.Entity<ProductDocument>(entity =>
            {
                entity.ToTable("ProductDocument", "Production");
                entity.HasKey(e => e.ProductID);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductDocuments)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductDocument_Product_ProductID");

            });
            modelBuilder.Entity<ProductInventory>(entity =>
            {
                entity.ToTable("ProductInventory", "Production");
                entity.HasKey(e => new { e.ProductID, e.LocationID });

                entity.Property(e => e.Shelf)
                    .HasColumnName("Shelf")
                    .HasColumnType("nvarchar(10)")
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Bin)
                    .HasColumnName("Bin")
                    .HasColumnType("tinyint");

                entity.Property(e => e.Quantity)
                    .HasColumnName("Quantity")
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductInventories)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductInventory_Product_ProductID");

                entity.HasOne(e => e.Location)
                    .WithMany(p => p.ProductInventories)
                    .HasForeignKey(p => p.LocationID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductInventory_Location_LocationID");

            });
            modelBuilder.Entity<ProductListPriceHistory>(entity =>
            {
                entity.ToTable("ProductListPriceHistory", "Production");
                entity.HasKey(e => new { e.ProductID, e.StartDate });

                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ListPrice)
                    .HasColumnName("ListPrice")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductListPriceHistories)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductListPriceHistory_Product_ProductID");

            });
            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("ProductModel", "Production");
                entity.HasKey(e => e.ProductModelID);

                entity.Property(e => e.ProductModelID)
                    .HasColumnName("ProductModelID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CatalogDescription)
                    .HasColumnName("CatalogDescription")
                    .HasColumnType("xml");

                entity.Property(e => e.Instructions)
                    .HasColumnName("Instructions")
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

            });
            modelBuilder.Entity<ProductModelIllustration>(entity =>
            {
                entity.ToTable("ProductModelIllustration", "Production");
                entity.HasKey(e => new { e.ProductModelID, e.IllustrationID });

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.ProductModel)
                    .WithMany(p => p.ProductModelIllustrations)
                    .HasForeignKey(p => p.ProductModelID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductModelIllustration_ProductModel_ProductModelID");

                entity.HasOne(e => e.Illustration)
                    .WithMany(p => p.ProductModelIllustrations)
                    .HasForeignKey(p => p.IllustrationID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductModelIllustration_Illustration_IllustrationID");

            });
            modelBuilder.Entity<ProductModelProductDescriptionCulture>(entity =>
            {
                entity.ToTable("ProductModelProductDescriptionCulture", "Production");
                entity.HasKey(e => new { e.ProductModelID, e.ProductDescriptionID, e.CultureID });

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.ProductDescription)
                    .WithMany(p => p.ProductModelProductDescriptionCultures)
                    .HasForeignKey(p => p.ProductDescriptionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID");

                entity.HasOne(e => e.ProductModel)
                    .WithMany(p => p.ProductModelProductDescriptionCultures)
                    .HasForeignKey(p => p.ProductModelID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID");

                entity.HasOne(e => e.Culture)
                    .WithMany(p => p.ProductModelProductDescriptionCultures)
                    .HasForeignKey(p => p.CultureID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductModelProductDescriptionCulture_Culture_CultureID");

            });
            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.ToTable("ProductPhoto", "Production");
                entity.HasKey(e => e.ProductPhotoID);

                entity.Property(e => e.ProductPhotoID)
                    .HasColumnName("ProductPhotoID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ThumbNailPhoto)
                    .HasColumnName("ThumbNailPhoto")
                    .HasColumnType("varbinary(MAX)");

                entity.Property(e => e.ThumbnailPhotoFileName)
                    .HasColumnName("ThumbnailPhotoFileName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.LargePhoto)
                    .HasColumnName("LargePhoto")
                    .HasColumnType("varbinary(MAX)");

                entity.Property(e => e.LargePhotoFileName)
                    .HasColumnName("LargePhotoFileName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<ProductProductPhoto>(entity =>
            {
                entity.ToTable("ProductProductPhoto", "Production");
                entity.HasKey(e => new { e.ProductID, e.ProductPhotoID });

                entity.Property(e => e.Primary)
                    .HasColumnName("Primary")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductProductPhotos)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductProductPhoto_Product_ProductID");

                entity.HasOne(e => e.ProductPhoto)
                    .WithMany(p => p.ProductProductPhotos)
                    .HasForeignKey(p => p.ProductPhotoID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductProductPhoto_ProductPhoto_ProductPhotoID");

            });
            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.ToTable("ProductReview", "Production");
                entity.HasKey(e => e.ProductReviewID);

                entity.Property(e => e.ProductReviewID)
                    .HasColumnName("ProductReviewID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReviewerName)
                    .HasColumnName("ReviewerName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReviewDate)
                    .HasColumnName("ReviewDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EmailAddress")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rating)
                    .HasColumnName("Rating")
                    .HasColumnType("int");

                entity.Property(e => e.Comments)
                    .HasColumnName("Comments")
                    .HasColumnType("nvarchar(3850)")
                    .HasMaxLength(3850);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductReview_Product_ProductID");

            });
            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("ProductSubcategory", "Production");
                entity.HasKey(e => e.ProductSubcategoryID);

                entity.Property(e => e.ProductSubcategoryID)
                    .HasColumnName("ProductSubcategoryID")
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

                entity.HasOne(e => e.ProductCategory)
                    .WithMany(p => p.ProductSubcategories)
                    .HasForeignKey(p => p.ProductCategoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductSubcategory_ProductCategory_ProductCategoryID");

            });
            modelBuilder.Entity<ProductVendor>(entity =>
            {
                entity.ToTable("ProductVendor", "Purchasing");
                entity.HasKey(e => new { e.ProductID, e.BusinessEntityID });

                entity.Property(e => e.AverageLeadTime)
                    .HasColumnName("AverageLeadTime")
                    .HasColumnType("int");

                entity.Property(e => e.StandardPrice)
                    .HasColumnName("StandardPrice")
                    .HasColumnType("money");

                entity.Property(e => e.LastReceiptCost)
                    .HasColumnName("LastReceiptCost")
                    .HasColumnType("money");

                entity.Property(e => e.LastReceiptDate)
                    .HasColumnName("LastReceiptDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MinOrderQty)
                    .HasColumnName("MinOrderQty")
                    .HasColumnType("int");

                entity.Property(e => e.MaxOrderQty)
                    .HasColumnName("MaxOrderQty")
                    .HasColumnType("int");

                entity.Property(e => e.OnOrderQty)
                    .HasColumnName("OnOrderQty")
                    .HasColumnType("int");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductVendors)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductVendor_Product_ProductID");

                entity.HasOne(e => e.UnitMeasure)
                    .WithMany(p => p.ProductVendors)
                    .HasForeignKey(p => p.UnitMeasureCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductVendor_UnitMeasure_UnitMeasureCode");

                entity.HasOne(e => e.Vendor)
                    .WithMany(p => p.ProductVendors)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductVendor_Vendor_BusinessEntityID");

            });
            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.ToTable("PurchaseOrderDetail", "Purchasing");
                entity.HasKey(e => new { e.PurchaseOrderID, e.PurchaseOrderDetailID });

                entity.Property(e => e.PurchaseOrderDetailID)
                    .HasColumnName("PurchaseOrderDetailID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DueDate)
                    .HasColumnName("DueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderQty)
                    .HasColumnName("OrderQty")
                    .HasColumnType("smallint");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("UnitPrice")
                    .HasColumnType("money");

                entity.Property(e => e.LineTotal)
                    .HasColumnName("LineTotal")
                    .HasColumnType("money");

                entity.Property(e => e.ReceivedQty)
                    .HasColumnName("ReceivedQty")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.RejectedQty)
                    .HasColumnName("RejectedQty")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.StockedQty)
                    .HasColumnName("StockedQty")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PurchaseOrderDetail_Product_ProductID");

                entity.HasOne(e => e.PurchaseOrderHeader)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(p => p.PurchaseOrderID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID");

            });
            modelBuilder.Entity<PurchaseOrderHeader>(entity =>
            {
                entity.ToTable("PurchaseOrderHeader", "Purchasing");
                entity.HasKey(e => e.PurchaseOrderID);

                entity.Property(e => e.PurchaseOrderID)
                    .HasColumnName("PurchaseOrderID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RevisionNumber)
                    .HasColumnName("RevisionNumber")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Status)
                    .HasColumnName("Status")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("OrderDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ShipDate)
                    .HasColumnName("ShipDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubTotal)
                    .HasColumnName("SubTotal")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.TaxAmt)
                    .HasColumnName("TaxAmt")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.Freight)
                    .HasColumnName("Freight")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.TotalDue)
                    .HasColumnName("TotalDue")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.ShipMethod)
                    .WithMany(p => p.PurchaseOrderHeaders)
                    .HasForeignKey(p => p.ShipMethodID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PurchaseOrderHeader_ShipMethod_ShipMethodID");

                entity.HasOne(e => e.Vendor)
                    .WithMany(p => p.PurchaseOrderHeaders)
                    .HasForeignKey(p => p.VendorID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PurchaseOrderHeader_Vendor_VendorID");

                entity.HasOne(e => e.Employee)
                    .WithMany(p => p.PurchaseOrderHeaders)
                    .HasForeignKey(p => p.EmployeeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PurchaseOrderHeader_Employee_EmployeeID");

            });
            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.ToTable("SalesOrderDetail", "Sales");
                entity.HasKey(e => new { e.SalesOrderID, e.SalesOrderDetailID });

                entity.Property(e => e.SalesOrderDetailID)
                    .HasColumnName("SalesOrderDetailID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CarrierTrackingNumber)
                    .HasColumnName("CarrierTrackingNumber")
                    .HasColumnType("nvarchar(25)")
                    .HasMaxLength(25);

                entity.Property(e => e.OrderQty)
                    .HasColumnName("OrderQty")
                    .HasColumnType("smallint");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("UnitPrice")
                    .HasColumnType("money");

                entity.Property(e => e.UnitPriceDiscount)
                    .HasColumnName("UnitPriceDiscount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.0");

                entity.Property(e => e.LineTotal)
                    .HasColumnName("LineTotal")
                    .HasColumnType("numeric(38, 6)");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.SpecialOfferProduct)
                    .WithMany(p => p.SalesOrderDetails)
                    .HasForeignKey(p => new {p.SpecialOfferID, p.ProductID})
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID");

                entity.HasOne(e => e.SalesOrderHeader)
                    .WithMany(p => p.SalesOrderDetails)
                    .HasForeignKey(p => p.SalesOrderID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID");

            });
            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.ToTable("SalesOrderHeader", "Sales");
                entity.HasKey(e => e.SalesOrderID);

                entity.Property(e => e.SalesOrderID)
                    .HasColumnName("SalesOrderID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RevisionNumber)
                    .HasColumnName("RevisionNumber")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("OrderDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DueDate)
                    .HasColumnName("DueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDate)
                    .HasColumnName("ShipDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("Status")
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.OnlineOrderFlag)
                    .HasColumnName("OnlineOrderFlag")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SalesOrderNumber)
                    .HasColumnName("SalesOrderNumber")
                    .HasColumnType("nvarchar(25)")
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.PurchaseOrderNumber)
                    .HasColumnName("PurchaseOrderNumber")
                    .HasColumnType("nvarchar(25)")
                    .HasMaxLength(25);

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("AccountNumber")
                    .HasColumnType("nvarchar(15)")
                    .HasMaxLength(15);

                entity.Property(e => e.CreditCardApprovalCode)
                    .HasColumnName("CreditCardApprovalCode")
                    .HasColumnType("varchar(15)")
                    .HasMaxLength(15);

                entity.Property(e => e.SubTotal)
                    .HasColumnName("SubTotal")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.TaxAmt)
                    .HasColumnName("TaxAmt")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.Freight)
                    .HasColumnName("Freight")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.TotalDue)
                    .HasColumnName("TotalDue")
                    .HasColumnType("money");

                entity.Property(e => e.Comment)
                    .HasColumnName("Comment")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.SalesTerritory)
                    .WithMany(p => p.SalesOrderHeaders)
                    .HasForeignKey(p => p.TerritoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeader_SalesTerritory_TerritoryID");

                entity.HasOne(e => e.ShipMethod)
                    .WithMany(p => p.SalesOrderHeaders)
                    .HasForeignKey(p => p.ShipMethodID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeader_ShipMethod_ShipMethodID");

                entity.HasOne(e => e.BillToAddress)
                    .WithMany(p => p.SalesOrderHeadersBillToAddress)
                    .HasForeignKey(p => p.BillToAddressID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeader_Address_BillToAddressID");

                entity.HasOne(e => e.ShipToAddress)
                    .WithMany(p => p.SalesOrderHeadersShipToAddress)
                    .HasForeignKey(p => p.ShipToAddressID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeader_Address_ShipToAddressID");

                entity.HasOne(e => e.CreditCard)
                    .WithMany(p => p.SalesOrderHeaders)
                    .HasForeignKey(p => p.CreditCardID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeader_CreditCard_CreditCardID");

                entity.HasOne(e => e.CurrencyRate)
                    .WithMany(p => p.SalesOrderHeaders)
                    .HasForeignKey(p => p.CurrencyRateID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeader_CurrencyRate_CurrencyRateID");

                entity.HasOne(e => e.Customer)
                    .WithMany(p => p.SalesOrderHeaders)
                    .HasForeignKey(p => p.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeader_Customer_CustomerID");

                entity.HasOne(e => e.SalesPerson)
                    .WithMany(p => p.SalesOrderHeaders)
                    .HasForeignKey(p => p.SalesPersonID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeader_SalesPerson_SalesPersonID");

            });
            modelBuilder.Entity<SalesOrderHeaderSalesReason>(entity =>
            {
                entity.ToTable("SalesOrderHeaderSalesReason", "Sales");
                entity.HasKey(e => new { e.SalesOrderID, e.SalesReasonID });

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.SalesOrderHeader)
                    .WithMany(p => p.SalesOrderHeaderSalesReasons)
                    .HasForeignKey(p => p.SalesOrderID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID");

                entity.HasOne(e => e.SalesReason)
                    .WithMany(p => p.SalesOrderHeaderSalesReasons)
                    .HasForeignKey(p => p.SalesReasonID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID");

            });
            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.ToTable("SalesPerson", "Sales");
                entity.HasKey(e => e.BusinessEntityID);

                entity.Property(e => e.SalesQuota)
                    .HasColumnName("SalesQuota")
                    .HasColumnType("money");

                entity.Property(e => e.Bonus)
                    .HasColumnName("Bonus")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.CommissionPct)
                    .HasColumnName("CommissionPct")
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.SalesYTD)
                    .HasColumnName("SalesYTD")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.SalesLastYear)
                    .HasColumnName("SalesLastYear")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.SalesTerritory)
                    .WithMany(p => p.SalesPeople)
                    .HasForeignKey(p => p.TerritoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesPerson_SalesTerritory_TerritoryID");

                entity.HasOne(e => e.Employee)
                    .WithMany(p => p.SalesPeople)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesPerson_Employee_BusinessEntityID");

            });
            modelBuilder.Entity<SalesPersonQuotaHistory>(entity =>
            {
                entity.ToTable("SalesPersonQuotaHistory", "Sales");
                entity.HasKey(e => new { e.BusinessEntityID, e.QuotaDate });

                entity.Property(e => e.QuotaDate)
                    .HasColumnName("QuotaDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SalesQuota)
                    .HasColumnName("SalesQuota")
                    .HasColumnType("money");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.SalesPerson)
                    .WithMany(p => p.SalesPersonQuotaHistories)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID");

            });
            modelBuilder.Entity<SalesReason>(entity =>
            {
                entity.ToTable("SalesReason", "Sales");
                entity.HasKey(e => e.SalesReasonID);

                entity.Property(e => e.SalesReasonID)
                    .HasColumnName("SalesReasonID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReasonType)
                    .HasColumnName("ReasonType")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<SalesTaxRate>(entity =>
            {
                entity.ToTable("SalesTaxRate", "Sales");
                entity.HasKey(e => e.SalesTaxRateID);

                entity.Property(e => e.SalesTaxRateID)
                    .HasColumnName("SalesTaxRateID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TaxType)
                    .HasColumnName("TaxType")
                    .HasColumnType("tinyint");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("TaxRate")
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("0.00");

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

                entity.HasOne(e => e.StateProvince)
                    .WithMany(p => p.SalesTaxRates)
                    .HasForeignKey(p => p.StateProvinceID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesTaxRate_StateProvince_StateProvinceID");

            });
            modelBuilder.Entity<SalesTerritory>(entity =>
            {
                entity.ToTable("SalesTerritory", "Sales");
                entity.HasKey(e => e.TerritoryID);

                entity.Property(e => e.TerritoryID)
                    .HasColumnName("TerritoryID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Group)
                    .HasColumnName("Group")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SalesYTD)
                    .HasColumnName("SalesYTD")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.SalesLastYear)
                    .HasColumnName("SalesLastYear")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.CostYTD)
                    .HasColumnName("CostYTD")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.CostLastYear)
                    .HasColumnName("CostLastYear")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.CountryRegion)
                    .WithMany(p => p.SalesTerritories)
                    .HasForeignKey(p => p.CountryRegionCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesTerritory_CountryRegion_CountryRegionCode");

            });
            modelBuilder.Entity<SalesTerritoryHistory>(entity =>
            {
                entity.ToTable("SalesTerritoryHistory", "Sales");
                entity.HasKey(e => new { e.BusinessEntityID, e.TerritoryID, e.StartDate });

                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.SalesTerritory)
                    .WithMany(p => p.SalesTerritoryHistories)
                    .HasForeignKey(p => p.TerritoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesTerritoryHistory_SalesTerritory_TerritoryID");

                entity.HasOne(e => e.SalesPerson)
                    .WithMany(p => p.SalesTerritoryHistories)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID");

            });
            modelBuilder.Entity<ScrapReason>(entity =>
            {
                entity.ToTable("ScrapReason", "Production");
                entity.HasKey(e => e.ScrapReasonID);

                entity.Property(e => e.ScrapReasonID)
                    .HasColumnName("ScrapReasonID")
                    .HasColumnType("smallint")
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
            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift", "HumanResources");
                entity.HasKey(e => e.ShiftID);

                entity.Property(e => e.ShiftID)
                    .HasColumnName("ShiftID")
                    .HasColumnType("tinyint")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartTime)
                    .HasColumnName("StartTime")
                    .HasColumnType("time");

                entity.Property(e => e.EndTime)
                    .HasColumnName("EndTime")
                    .HasColumnType("time");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<ShipMethod>(entity =>
            {
                entity.ToTable("ShipMethod", "Purchasing");
                entity.HasKey(e => e.ShipMethodID);

                entity.Property(e => e.ShipMethodID)
                    .HasColumnName("ShipMethodID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShipBase)
                    .HasColumnName("ShipBase")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.ShipRate)
                    .HasColumnName("ShipRate")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

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
            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.ToTable("ShoppingCartItem", "Sales");
                entity.HasKey(e => e.ShoppingCartItemID);

                entity.Property(e => e.ShoppingCartItemID)
                    .HasColumnName("ShoppingCartItemID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ShoppingCartID)
                    .HasColumnName("ShoppingCartID")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Quantity)
                    .HasColumnName("Quantity")
                    .HasColumnType("int")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DateCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ShoppingCartItems)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ShoppingCartItem_Product_ProductID");

            });
            modelBuilder.Entity<SpecialOffer>(entity =>
            {
                entity.ToTable("SpecialOffer", "Sales");
                entity.HasKey(e => e.SpecialOfferID);

                entity.Property(e => e.SpecialOfferID)
                    .HasColumnName("SpecialOfferID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DiscountPct)
                    .HasColumnName("DiscountPct")
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.Type)
                    .HasColumnName("Type")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Category)
                    .HasColumnName("Category")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MinQty)
                    .HasColumnName("MinQty")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MaxQty)
                    .HasColumnName("MaxQty")
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

            });
            modelBuilder.Entity<SpecialOfferProduct>(entity =>
            {
                entity.ToTable("SpecialOfferProduct", "Sales");
                entity.HasKey(e => new { e.SpecialOfferID, e.ProductID });

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.SpecialOfferProducts)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpecialOfferProduct_Product_ProductID");

                entity.HasOne(e => e.SpecialOffer)
                    .WithMany(p => p.SpecialOfferProducts)
                    .HasForeignKey(p => p.SpecialOfferID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID");

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

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.SalesTerritory)
                    .WithMany(p => p.StateProvinces)
                    .HasForeignKey(p => p.TerritoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StateProvince_SalesTerritory_TerritoryID");

                entity.HasOne(e => e.CountryRegion)
                    .WithMany(p => p.StateProvinces)
                    .HasForeignKey(p => p.CountryRegionCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StateProvince_CountryRegion_CountryRegionCode");

            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Sales");
                entity.HasKey(e => e.BusinessEntityID);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

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

                entity.HasOne(e => e.BusinessEntity)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Store_BusinessEntity_BusinessEntityID");

                entity.HasOne(e => e.SalesPerson)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(p => p.SalesPersonID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Store_SalesPerson_SalesPersonID");

            });
            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.ToTable("TransactionHistory", "Production");
                entity.HasKey(e => e.TransactionID);

                entity.Property(e => e.TransactionID)
                    .HasColumnName("TransactionID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReferenceOrderID)
                    .HasColumnName("ReferenceOrderID")
                    .HasColumnType("int");

                entity.Property(e => e.ReferenceOrderLineID)
                    .HasColumnName("ReferenceOrderLineID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("TransactionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("TransactionType")
                    .HasColumnType("nchar(1)")
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Quantity)
                    .HasColumnName("Quantity")
                    .HasColumnType("int");

                entity.Property(e => e.ActualCost)
                    .HasColumnName("ActualCost")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TransactionHistory_Product_ProductID");

            });
            modelBuilder.Entity<TransactionHistoryArchive>(entity =>
            {
                entity.ToTable("TransactionHistoryArchive", "Production");
                entity.HasKey(e => e.TransactionID);

                entity.Property(e => e.TransactionID)
                    .HasColumnName("TransactionID")
                    .HasColumnType("int");

                entity.Property(e => e.ProductID)
                    .HasColumnName("ProductID")
                    .HasColumnType("int");

                entity.Property(e => e.ReferenceOrderID)
                    .HasColumnName("ReferenceOrderID")
                    .HasColumnType("int");

                entity.Property(e => e.ReferenceOrderLineID)
                    .HasColumnName("ReferenceOrderLineID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("TransactionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("TransactionType")
                    .HasColumnType("nchar(1)")
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Quantity)
                    .HasColumnName("Quantity")
                    .HasColumnType("int");

                entity.Property(e => e.ActualCost)
                    .HasColumnName("ActualCost")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<UnitMeasure>(entity =>
            {
                entity.ToTable("UnitMeasure", "Production");
                entity.HasKey(e => e.UnitMeasureCode);

                entity.Property(e => e.UnitMeasureCode)
                    .HasColumnName("UnitMeasureCode")
                    .HasColumnType("nchar(3)")
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
            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor", "Purchasing");
                entity.HasKey(e => e.BusinessEntityID);

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("AccountNumber")
                    .HasColumnType("nvarchar(15)")
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreditRating)
                    .HasColumnName("CreditRating")
                    .HasColumnType("tinyint");

                entity.Property(e => e.PreferredVendorStatus)
                    .HasColumnName("PreferredVendorStatus")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ActiveFlag)
                    .HasColumnName("ActiveFlag")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.PurchasingWebServiceURL)
                    .HasColumnName("PurchasingWebServiceURL")
                    .HasColumnType("nvarchar(1024)")
                    .HasMaxLength(1024);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.BusinessEntity)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(p => p.BusinessEntityID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Vendor_BusinessEntity_BusinessEntityID");

            });
            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.ToTable("WorkOrder", "Production");
                entity.HasKey(e => e.WorkOrderID);

                entity.Property(e => e.WorkOrderID)
                    .HasColumnName("WorkOrderID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OrderQty)
                    .HasColumnName("OrderQty")
                    .HasColumnType("int");

                entity.Property(e => e.StockedQty)
                    .HasColumnName("StockedQty")
                    .HasColumnType("int");

                entity.Property(e => e.ScrappedQty)
                    .HasColumnName("ScrappedQty")
                    .HasColumnType("smallint");

                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDate)
                    .HasColumnName("DueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(p => p.ProductID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WorkOrder_Product_ProductID");

                entity.HasOne(e => e.ScrapReason)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(p => p.ScrapReasonID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WorkOrder_ScrapReason_ScrapReasonID");

            });
            modelBuilder.Entity<WorkOrderRouting>(entity =>
            {
                entity.ToTable("WorkOrderRouting", "Production");
                entity.HasKey(e => new { e.WorkOrderID, e.ProductID, e.OperationSequence });

                entity.Property(e => e.ProductID)
                    .HasColumnName("ProductID")
                    .HasColumnType("int");

                entity.Property(e => e.OperationSequence)
                    .HasColumnName("OperationSequence")
                    .HasColumnType("smallint");

                entity.Property(e => e.ScheduledStartDate)
                    .HasColumnName("ScheduledStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScheduledEndDate)
                    .HasColumnName("ScheduledEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActualStartDate)
                    .HasColumnName("ActualStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActualEndDate)
                    .HasColumnName("ActualEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActualResourceHrs)
                    .HasColumnName("ActualResourceHrs")
                    .HasColumnType("decimal(9, 4)");

                entity.Property(e => e.PlannedCost)
                    .HasColumnName("PlannedCost")
                    .HasColumnType("money");

                entity.Property(e => e.ActualCost)
                    .HasColumnName("ActualCost")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("ModifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.WorkOrder)
                    .WithMany(p => p.WorkOrderRoutings)
                    .HasForeignKey(p => p.WorkOrderID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WorkOrderRouting_WorkOrder_WorkOrderID");

                entity.HasOne(e => e.Location)
                    .WithMany(p => p.WorkOrderRoutings)
                    .HasForeignKey(p => p.LocationID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WorkOrderRouting_Location_LocationID");

            });
        }
    }
}