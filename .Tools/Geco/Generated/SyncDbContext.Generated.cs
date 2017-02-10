// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Mira.Web.DataAccess.Sync;
using Newtonsoft.Json;

namespace Mira.Web.DataAccess.SyncContext
{
    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SyncDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MiraDb"].ConnectionString, opt =>
            {
                //opt.EnableRetryOnFailure();
            });

            optionsBuilder.ConfigureWarnings(w =>
            {
                w.Ignore(RelationalEventId.AmbientTransactionWarning);
                w.Ignore(RelationalEventId.QueryClientEvaluationWarning);
            });
        }

        public virtual DbSet<_RefactorLog> _RefactorLogs { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AssignedPatient> AssignedPatients { get; set; }
        public virtual DbSet<AssignedPatientsTombstone> AssignedPatientsTombstones { get; set; }
        public virtual DbSet<AssignedUser> AssignedUsers { get; set; }
        public virtual DbSet<AssignedUsersTombstone> AssignedUsersTombstones { get; set; }
        public virtual DbSet<AuditEntry> AuditEntries { get; set; }
        public virtual DbSet<AuditEntriesTombstone> AuditEntriesTombstones { get; set; }
        public virtual DbSet<AuditEntryType> AuditEntryTypes { get; set; }
        public virtual DbSet<AuditEntryTypesTombstone> AuditEntryTypesTombstones { get; set; }
        public virtual DbSet<AuditEntryTypesTranslation> AuditEntryTypesTranslations { get; set; }
        public virtual DbSet<AuditEntryTypesTranslationsTombstone> AuditEntryTypesTranslationsTombstones { get; set; }
        public virtual DbSet<CogniGame> CogniGames { get; set; }
        public virtual DbSet<CogniGameSettingsValue> CogniGameSettingsValues { get; set; }
        public virtual DbSet<CogniGameSettingsValuesTombstone> CogniGameSettingsValuesTombstones { get; set; }
        public virtual DbSet<CogniGamesTombstone> CogniGamesTombstones { get; set; }
        public virtual DbSet<Difficulty> Difficulties { get; set; }
        public virtual DbSet<DifficultiesTombstone> DifficultiesTombstones { get; set; }
        public virtual DbSet<DifficultiesTranslation> DifficultiesTranslations { get; set; }
        public virtual DbSet<DifficultiesTranslationsTombstone> DifficultiesTranslationsTombstones { get; set; }
        public virtual DbSet<ExerGame> ExerGames { get; set; }
        public virtual DbSet<ExerGameSettingsValue> ExerGameSettingsValues { get; set; }
        public virtual DbSet<ExerGameSettingsValuesTombstone> ExerGameSettingsValuesTombstones { get; set; }
        public virtual DbSet<ExerGameTombstone> ExerGameTombstones { get; set; }
        public virtual DbSet<GameMovement> GameMovements { get; set; }
        public virtual DbSet<GameMovementsTombstone> GameMovementsTombstones { get; set; }
        public virtual DbSet<GameMovementType> GameMovementTypes { get; set; }
        public virtual DbSet<GameMovementTypesTombstone> GameMovementTypesTombstones { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameSettingsDescriptor> GameSettingsDescriptors { get; set; }
        public virtual DbSet<GameSettingsDescriptorsTombstone> GameSettingsDescriptorsTombstones { get; set; }
        public virtual DbSet<GamesSetting> GamesSettings { get; set; }
        public virtual DbSet<GamesSettingsTombstone> GamesSettingsTombstones { get; set; }
        public virtual DbSet<GameStatisticsType> GameStatisticsTypes { get; set; }
        public virtual DbSet<GameStatisticsTypesTombstone> GameStatisticsTypesTombstones { get; set; }
        public virtual DbSet<GamesTombstone> GamesTombstones { get; set; }
        public virtual DbSet<GamesTranslation> GamesTranslations { get; set; }
        public virtual DbSet<GamesTranslationsTombstone> GamesTranslationsTombstones { get; set; }
        public virtual DbSet<GameVersion> GameVersions { get; set; }
        public virtual DbSet<GameVersionsTombstone> GameVersionsTombstones { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<GendersTombstone> GendersTombstones { get; set; }
        public virtual DbSet<GendersTranslation> GendersTranslations { get; set; }
        public virtual DbSet<GendersTranslationsTombstone> GendersTranslationsTombstones { get; set; }
        public virtual DbSet<Joint> Joints { get; set; }
        public virtual DbSet<JointsAcceptedStatistic> JointsAcceptedStatistics { get; set; }
        public virtual DbSet<JointsAcceptedStatisticsTombstone> JointsAcceptedStatisticsTombstones { get; set; }
        public virtual DbSet<JointsTombstone> JointsTombstones { get; set; }
        public virtual DbSet<JointsTranslation> JointsTranslations { get; set; }
        public virtual DbSet<JointsTranslationsTombstone> JointsTranslationsTombstones { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguagesTombstone> LanguagesTombstones { get; set; }
        public virtual DbSet<LogEntry> LogEntries { get; set; }
        public virtual DbSet<LogEntriesTombstone> LogEntriesTombstones { get; set; }
        public virtual DbSet<LogEntryType> LogEntryTypes { get; set; }
        public virtual DbSet<LogEntryTypesTombstone> LogEntryTypesTombstones { get; set; }
        public virtual DbSet<LogEntryTypesTranslation> LogEntryTypesTranslations { get; set; }
        public virtual DbSet<LogEntryTypesTranslationsTombstone> LogEntryTypesTranslationsTombstones { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }
        public virtual DbSet<MovementsAcceptedStatistic> MovementsAcceptedStatistics { get; set; }
        public virtual DbSet<MovementsAcceptedStatisticsTombstone> MovementsAcceptedStatisticsTombstones { get; set; }
        public virtual DbSet<MovementsJoint> MovementsJoints { get; set; }
        public virtual DbSet<MovementsJointsTombstone> MovementsJointsTombstones { get; set; }
        public virtual DbSet<MovementsSide> MovementsSides { get; set; }
        public virtual DbSet<MovementsSidesTombstone> MovementsSidesTombstones { get; set; }
        public virtual DbSet<MovementsTombstone> MovementsTombstones { get; set; }
        public virtual DbSet<MovementsTranslation> MovementsTranslations { get; set; }
        public virtual DbSet<MovementsTranslationsTombstone> MovementsTranslationsTombstones { get; set; }
        public virtual DbSet<MovementType> MovementTypes { get; set; }
        public virtual DbSet<MovementTypesTombstone> MovementTypesTombstones { get; set; }
        public virtual DbSet<MovementTypesTranslation> MovementTypesTranslations { get; set; }
        public virtual DbSet<MovementTypesTranslationsTombstone> MovementTypesTranslationsTombstones { get; set; }
        public virtual DbSet<PatientField> PatientFields { get; set; }
        public virtual DbSet<PatientFieldsTombstone> PatientFieldsTombstones { get; set; }
        public virtual DbSet<PatientFieldValue> PatientFieldValues { get; set; }
        public virtual DbSet<PatientFieldValuesTombstone> PatientFieldValuesTombstones { get; set; }
        public virtual DbSet<PatientImage> PatientImages { get; set; }
        public virtual DbSet<PatientImagesTombstone> PatientImagesTombstones { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientsJoint> PatientsJoints { get; set; }
        public virtual DbSet<PatientsJointsTombstone> PatientsJointsTombstones { get; set; }
        public virtual DbSet<PatientsTombstone> PatientsTombstones { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionsTombstone> PermissionsTombstones { get; set; }
        public virtual DbSet<PermissionsTranslation> PermissionsTranslations { get; set; }
        public virtual DbSet<PermissionsTranslationsTombstone> PermissionsTranslationsTombstones { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual DbSet<QuestionAnswersTombstone> QuestionAnswersTombstones { get; set; }
        public virtual DbSet<QuestionDisplayType> QuestionDisplayTypes { get; set; }
        public virtual DbSet<QuestionDisplayTypesTombstone> QuestionDisplayTypesTombstones { get; set; }
        public virtual DbSet<QuestionDisplayTypesTranslation> QuestionDisplayTypesTranslations { get; set; }
        public virtual DbSet<QuestionDisplayTypesTranslationsTombstone> QuestionDisplayTypesTranslationsTombstones { get; set; }
        public virtual DbSet<QuestionnaireQuestion> QuestionnaireQuestions { get; set; }
        public virtual DbSet<QuestionnaireQuestionsTombstone> QuestionnaireQuestionsTombstones { get; set; }
        public virtual DbSet<Questionnaire> Questionnaires { get; set; }
        public virtual DbSet<QuestionnairesTombstone> QuestionnairesTombstones { get; set; }
        public virtual DbSet<QuestionnairesTranslation> QuestionnairesTranslations { get; set; }
        public virtual DbSet<QuestionnairesTranslationsTombstone> QuestionnairesTranslationsTombstones { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionsTombstone> QuestionsTombstones { get; set; }
        public virtual DbSet<QuestionsTranslation> QuestionsTranslations { get; set; }
        public virtual DbSet<QuestionsTranslationsTombstone> QuestionsTranslationsTombstones { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<QuestionTypesTombstone> QuestionTypesTombstones { get; set; }
        public virtual DbSet<QuestionTypesTranslation> QuestionTypesTranslations { get; set; }
        public virtual DbSet<QuestionTypesTranslationsTombstone> QuestionTypesTranslationsTombstones { get; set; }
        public virtual DbSet<RangeOfMotion> RangeOfMotions { get; set; }
        public virtual DbSet<RangeOfMotionTombstone> RangeOfMotionTombstones { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<RolePermissionsTombstone> RolePermissionsTombstones { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleSetting> RoleSettings { get; set; }
        public virtual DbSet<RoleSettingsTombstone> RoleSettingsTombstones { get; set; }
        public virtual DbSet<RolesTombstone> RolesTombstones { get; set; }
        public virtual DbSet<RolesTranslation> RolesTranslations { get; set; }
        public virtual DbSet<RolesTranslationsTombstone> RolesTranslationsTombstones { get; set; }
        public virtual DbSet<RomMovement> RomMovements { get; set; }
        public virtual DbSet<RomMovementsTombstone> RomMovementsTombstones { get; set; }
        public virtual DbSet<SavedSchedule> SavedSchedules { get; set; }
        public virtual DbSet<SavedSchedulesTombstone> SavedSchedulesTombstones { get; set; }
        public virtual DbSet<ScheduleItem> ScheduleItems { get; set; }
        public virtual DbSet<ScheduleItemsTombstone> ScheduleItemsTombstones { get; set; }
        public virtual DbSet<ScheduleItemType> ScheduleItemTypes { get; set; }
        public virtual DbSet<ScheduleItemTypesTombstone> ScheduleItemTypesTombstones { get; set; }
        public virtual DbSet<ScheduleItemTypesTranslation> ScheduleItemTypesTranslations { get; set; }
        public virtual DbSet<ScheduleItemTypesTranslationsTombstone> ScheduleItemTypesTranslationsTombstones { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<SchedulesTombstone> SchedulesTombstones { get; set; }
        public virtual DbSet<SensorMovement> SensorMovements { get; set; }
        public virtual DbSet<SensorMovementsTombstone> SensorMovementsTombstones { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<SensorsTombstone> SensorsTombstones { get; set; }
        public virtual DbSet<SensorsTranslation> SensorsTranslations { get; set; }
        public virtual DbSet<SensorsTranslationsTombstone> SensorsTranslationsTombstones { get; set; }
        public virtual DbSet<SessionImage> SessionImages { get; set; }
        public virtual DbSet<SessionImagesTombstone> SessionImagesTombstones { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionsTombstone> SessionsTombstones { get; set; }
        public virtual DbSet<SettingDescriptorCategory> SettingDescriptorCategories { get; set; }
        public virtual DbSet<SettingDescriptorCategoriesTombstone> SettingDescriptorCategoriesTombstones { get; set; }
        public virtual DbSet<SettingDescriptorCategoriesTranslation> SettingDescriptorCategoriesTranslations { get; set; }
        public virtual DbSet<SettingDescriptorCategoriesTranslationsTombstone> SettingDescriptorCategoriesTranslationsTombstones { get; set; }
        public virtual DbSet<SettingDescriptor> SettingDescriptors { get; set; }
        public virtual DbSet<SettingDescriptorsTombstone> SettingDescriptorsTombstones { get; set; }
        public virtual DbSet<SettingDescriptorsTranslation> SettingDescriptorsTranslations { get; set; }
        public virtual DbSet<SettingDescriptorsTranslationsTombstone> SettingDescriptorsTranslationsTombstones { get; set; }
        public virtual DbSet<SettingValue> SettingValues { get; set; }
        public virtual DbSet<SettingValuesTombstone> SettingValuesTombstones { get; set; }
        public virtual DbSet<SettingValuesTranslation> SettingValuesTranslations { get; set; }
        public virtual DbSet<SettingValuesTranslationsTombstone> SettingValuesTranslationsTombstones { get; set; }
        public virtual DbSet<Side> Sides { get; set; }
        public virtual DbSet<SidesTombstone> SidesTombstones { get; set; }
        public virtual DbSet<SidesTranslation> SidesTranslations { get; set; }
        public virtual DbSet<SidesTranslationsTombstone> SidesTranslationsTombstones { get; set; }
        public virtual DbSet<StatisticsAggregationType> StatisticsAggregationTypes { get; set; }
        public virtual DbSet<StatisticsAggregationTypesTombstone> StatisticsAggregationTypesTombstones { get; set; }
        public virtual DbSet<StatisticsAggregationTypesTranslation> StatisticsAggregationTypesTranslations { get; set; }
        public virtual DbSet<StatisticsAggregationTypesTranslationsTombstone> StatisticsAggregationTypesTranslationsTombstones { get; set; }
        public virtual DbSet<StatisticsCategory> StatisticsCategories { get; set; }
        public virtual DbSet<StatisticsCategoriesTombstone> StatisticsCategoriesTombstones { get; set; }
        public virtual DbSet<StatisticsCategoriesTranslation> StatisticsCategoriesTranslations { get; set; }
        public virtual DbSet<StatisticsCategoriesTranslationsTombstone> StatisticsCategoriesTranslationsTombstones { get; set; }
        public virtual DbSet<StatisticsType> StatisticsTypes { get; set; }
        public virtual DbSet<StatisticsTypesTombstone> StatisticsTypesTombstones { get; set; }
        public virtual DbSet<StatisticsTypesTranslation> StatisticsTypesTranslations { get; set; }
        public virtual DbSet<StatisticsTypesTranslationsTombstone> StatisticsTypesTranslationsTombstones { get; set; }
        public virtual DbSet<StatisticsUnit> StatisticsUnits { get; set; }
        public virtual DbSet<StatisticsUnitsTombstone> StatisticsUnitsTombstones { get; set; }
        public virtual DbSet<StatisticsUnitsTranslation> StatisticsUnitsTranslations { get; set; }
        public virtual DbSet<StatisticsUnitsTranslationsTombstone> StatisticsUnitsTranslationsTombstones { get; set; }
        public virtual DbSet<StatisticsValue> StatisticsValues { get; set; }
        public virtual DbSet<StatisticsValuesTombstone> StatisticsValuesTombstones { get; set; }
        public virtual DbSet<SyncChange> SyncChanges { get; set; }
        public virtual DbSet<SyncDirection> SyncDirections { get; set; }
        public virtual DbSet<SyncState> SyncStates { get; set; }
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<TenantGameVersion> TenantGameVersions { get; set; }
        public virtual DbSet<TenantQuestionnaire> TenantQuestionnaires { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<TenantType> TenantTypes { get; set; }
        public virtual DbSet<Tutorial> Tutorials { get; set; }
        public virtual DbSet<TutorialSource> TutorialSources { get; set; }
        public virtual DbSet<TutorialSourceTombstone> TutorialSourceTombstones { get; set; }
        public virtual DbSet<TutorialSourceTranslation> TutorialSourceTranslations { get; set; }
        public virtual DbSet<TutorialSourceTranslationsTombstone> TutorialSourceTranslationsTombstones { get; set; }
        public virtual DbSet<TutorialsTombstone> TutorialsTombstones { get; set; }
        public virtual DbSet<TutorialsTranslation> TutorialsTranslations { get; set; }
        public virtual DbSet<TutorialsTranslationsTombstone> TutorialsTranslationsTombstones { get; set; }
        public virtual DbSet<UpdateType> UpdateTypes { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserRolesTombstone> UserRolesTombstones { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersTombstone> UsersTombstones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<_RefactorLog>(entity =>
            {
                entity.ToTable("__RefactorLog", "dbo");
                entity.HasKey(e => e.OperationKey);

                entity.Property(e => e.OperationKey)
                    .HasColumnName("OperationKey")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

            });
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.ToTable("AspNetRoles", "Security");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(256)")
                    .IsRequired()
                    .HasMaxLength(512);

            });
            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.ToTable("AspNetUserClaims", "Security");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ClaimType)
                    .HasColumnName("ClaimType")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.ClaimValue)
                    .HasColumnName("ClaimValue")
                    .HasColumnType("nvarchar(MAX)");

                entity.HasOne(e => e.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Security.AspNetUserClaims_Security.AspNetUsers_UserId");

            });
            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.ToTable("AspNetUserLogins", "Security");
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.Property(e => e.LoginProvider)
                    .HasColumnName("LoginProvider")
                    .HasColumnType("nvarchar(128)")
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ProviderKey)
                    .HasColumnName("ProviderKey")
                    .HasColumnType("nvarchar(128)")
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(e => e.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Security.AspNetUserLogins_Security.AspNetUsers_UserId");

            });
            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.ToTable("AspNetUserRoles", "Security");
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(e => e.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Security.AspNetUserRoles_Security.AspNetUsers_UserId");

                entity.HasOne(e => e.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(p => p.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Security.AspNetUserRoles_Security.AspNetRoles_RoleId");

            });
            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.ToTable("AspNetUsers", "Security");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(512);

                entity.Property(e => e.EmailConfirmed)
                    .HasColumnName("EmailConfirmed")
                    .HasColumnType("bit");

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("PasswordHash")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.SecurityStamp)
                    .HasColumnName("SecurityStamp")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.PhoneNumberConfirmed)
                    .HasColumnName("PhoneNumberConfirmed")
                    .HasColumnType("bit");

                entity.Property(e => e.TwoFactorEnabled)
                    .HasColumnName("TwoFactorEnabled")
                    .HasColumnType("bit");

                entity.Property(e => e.LockoutEndDateUtc)
                    .HasColumnName("LockoutEndDateUtc")
                    .HasColumnType("datetime");

                entity.Property(e => e.LockoutEnabled)
                    .HasColumnName("LockoutEnabled")
                    .HasColumnType("bit");

                entity.Property(e => e.AccessFailedCount)
                    .HasColumnName("AccessFailedCount")
                    .HasColumnType("int");

                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasColumnType("nvarchar(256)")
                    .IsRequired()
                    .HasMaxLength(512);

            });
            modelBuilder.Entity<AssignedPatient>(entity =>
            {
                entity.ToTable("AssignedPatients", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.AssignedPatients)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssignedPatients_Tenants");

                entity.HasOne(e => e.TargetUser)
                    .WithMany(p => p.AssignedPatients)
                    .HasForeignKey(p => p.TargetUserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssignedPatients_Users");

                entity.HasOne(e => e.Assigned)
                    .WithMany(p => p.AssignedPatients)
                    .HasForeignKey(p => p.AssignedID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssignedPatients_Patients");

            });
            modelBuilder.Entity<AssignedPatientsTombstone>(entity =>
            {
                entity.ToTable("AssignedPatientsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<AssignedUser>(entity =>
            {
                entity.ToTable("AssignedUsers", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.AssignedUsers)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssignedUsers_Tenants");

                entity.HasOne(e => e.TargetUser)
                    .WithMany(p => p.AssignedUsersTargetUser)
                    .HasForeignKey(p => p.TargetUserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssignedUsers_Users");

                entity.HasOne(e => e.Assigned)
                    .WithMany(p => p.AssignedUsersAssigned)
                    .HasForeignKey(p => p.AssignedID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AssignedUsers_Users1");

            });
            modelBuilder.Entity<AssignedUsersTombstone>(entity =>
            {
                entity.ToTable("AssignedUsersTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<AuditEntry>(entity =>
            {
                entity.ToTable("AuditEntries", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(512);

                entity.Property(e => e.AuditDate)
                    .HasColumnName("AuditDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.AuditMessage)
                    .HasColumnName("AuditMessage")
                    .HasColumnType("nvarchar(MAX)")
                    .IsRequired();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.AuditEntries)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AuditEntries_Tenants");

                entity.HasOne(e => e.AuditEntryType)
                    .WithMany(p => p.AuditEntries)
                    .HasForeignKey(p => p.AuditEntryTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AuditEntries_AuditEntryTypes");

            });
            modelBuilder.Entity<AuditEntriesTombstone>(entity =>
            {
                entity.ToTable("AuditEntriesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<AuditEntryType>(entity =>
            {
                entity.ToTable("AuditEntryTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<AuditEntryTypesTombstone>(entity =>
            {
                entity.ToTable("AuditEntryTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<AuditEntryTypesTranslation>(entity =>
            {
                entity.ToTable("AuditEntryTypesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.AuditEntryTypesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AuditEntryTypesTranslations_Languages");

                entity.HasOne(e => e.AuditEntryType)
                    .WithMany(p => p.AuditEntryTypesTranslations)
                    .HasForeignKey(p => p.AuditEntryTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AuditEntryTypesTranslations_AuditEntryTypes");

            });
            modelBuilder.Entity<AuditEntryTypesTranslationsTombstone>(entity =>
            {
                entity.ToTable("AuditEntryTypesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<CogniGame>(entity =>
            {
                entity.ToTable("CogniGames", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.CogniGames)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CognitiveGames_Tenants");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.CogniGames)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CognitiveGames_Games");

            });
            modelBuilder.Entity<CogniGameSettingsValue>(entity =>
            {
                entity.ToTable("CogniGameSettingsValues", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.CogniGameSettingsValues)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CogniGameSettingsValues_Tenants");

                entity.HasOne(e => e.CognitiveGame)
                    .WithMany(p => p.CogniGameSettingsValues)
                    .HasForeignKey(p => p.CognitiveGameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CogniGameSettingsValues_CognitiveGames");

                entity.HasOne(e => e.SettingValue)
                    .WithMany(p => p.CogniGameSettingsValues)
                    .HasForeignKey(p => p.SettingValueID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CogniGameSettingsValues_SettingValues");

            });
            modelBuilder.Entity<CogniGameSettingsValuesTombstone>(entity =>
            {
                entity.ToTable("CogniGameSettingsValuesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<CogniGamesTombstone>(entity =>
            {
                entity.ToTable("CogniGamesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Difficulty>(entity =>
            {
                entity.ToTable("Difficulties", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<DifficultiesTombstone>(entity =>
            {
                entity.ToTable("DifficultiesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<DifficultiesTranslation>(entity =>
            {
                entity.ToTable("DifficultiesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.DifficultiesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DifficultiesTranslations_Languages");

                entity.HasOne(e => e.Difficulty)
                    .WithMany(p => p.DifficultiesTranslations)
                    .HasForeignKey(p => p.DifficultyID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DifficultiesTranslations_Difficulties");

            });
            modelBuilder.Entity<DifficultiesTranslationsTombstone>(entity =>
            {
                entity.ToTable("DifficultiesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<ExerGame>(entity =>
            {
                entity.ToTable("ExerGame", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.ExerGames)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExerGame_Tenants");

                entity.HasOne(e => e.Movement)
                    .WithMany(p => p.ExerGames)
                    .HasForeignKey(p => p.MovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExerGame_Movements");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.ExerGames)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExerGame_Games");

                entity.HasOne(e => e.Side)
                    .WithMany(p => p.ExerGames)
                    .HasForeignKey(p => p.SideID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExerGame_Sides");

            });
            modelBuilder.Entity<ExerGameSettingsValue>(entity =>
            {
                entity.ToTable("ExerGameSettingsValues", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.ExerGameSettingsValues)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExerGameSettingsValues_Tenants");

                entity.HasOne(e => e.ExerGame)
                    .WithMany(p => p.ExerGameSettingsValues)
                    .HasForeignKey(p => p.ExerGameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExerGameSettingValues_ExerGame");

                entity.HasOne(e => e.SettingValue)
                    .WithMany(p => p.ExerGameSettingsValues)
                    .HasForeignKey(p => p.SettingValueID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ExerGameSettingValues_SettingValues");

            });
            modelBuilder.Entity<ExerGameSettingsValuesTombstone>(entity =>
            {
                entity.ToTable("ExerGameSettingsValuesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<ExerGameTombstone>(entity =>
            {
                entity.ToTable("ExerGameTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<GameMovement>(entity =>
            {
                entity.ToTable("GameMovements", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.GameMovements)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameMovements_Games");

                entity.HasOne(e => e.Movement)
                    .WithMany(p => p.GameMovements)
                    .HasForeignKey(p => p.MovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameMovements_Movements");

            });
            modelBuilder.Entity<GameMovementsTombstone>(entity =>
            {
                entity.ToTable("GameMovementsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<GameMovementType>(entity =>
            {
                entity.ToTable("GameMovementTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.GameMovementTypes)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameMovementTypes_Games");

                entity.HasOne(e => e.MovementType)
                    .WithMany(p => p.GameMovementTypes)
                    .HasForeignKey(p => p.MovementTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameMovementTypes_MovementTypes");

            });
            modelBuilder.Entity<GameMovementTypesTombstone>(entity =>
            {
                entity.ToTable("GameMovementTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Games", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(1000);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(2000)")
                    .HasMaxLength(4000);

                entity.Property(e => e.Identifier)
                    .HasColumnName("Identifier")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(200);

                entity.Property(e => e.IsCognitive)
                    .HasColumnName("IsCognitive")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsFeatured)
                    .HasColumnName("IsFeatured")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Version)
                    .HasColumnName("Version")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BetaOnly)
                    .HasColumnName("BetaOnly")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<GameSettingsDescriptor>(entity =>
            {
                entity.ToTable("GameSettingsDescriptors", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.GameSettingsDescriptors)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameSettingsDescriptors_Games");

                entity.HasOne(e => e.SettingDescriptor)
                    .WithMany(p => p.GameSettingsDescriptors)
                    .HasForeignKey(p => p.SettingDescriptorID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameSettingsDescriptors_SettingDescriptors");

            });
            modelBuilder.Entity<GameSettingsDescriptorsTombstone>(entity =>
            {
                entity.ToTable("GameSettingsDescriptorsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<GamesSetting>(entity =>
            {
                entity.ToTable("GamesSettings", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumericValue)
                    .HasColumnName("NumericValue")
                    .HasColumnType("int");

                entity.Property(e => e.TextValue)
                    .HasColumnName("TextValue")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.GamesSettings)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GamesSettings_Tenants");

                entity.HasOne(e => e.ExerGame)
                    .WithMany(p => p.GamesSettings)
                    .HasForeignKey(p => p.ExerGameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GamesSettings_ExerGame");

            });
            modelBuilder.Entity<GamesSettingsTombstone>(entity =>
            {
                entity.ToTable("GamesSettingsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<GameStatisticsType>(entity =>
            {
                entity.ToTable("GameStatisticsTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.GameStatisticsTypes)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameStatisticsTypes_Games");

                entity.HasOne(e => e.StatisticType)
                    .WithMany(p => p.GameStatisticsTypes)
                    .HasForeignKey(p => p.StatisticTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameStatisticsTypes_StatisticsTypes");

            });
            modelBuilder.Entity<GameStatisticsTypesTombstone>(entity =>
            {
                entity.ToTable("GameStatisticsTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<GamesTombstone>(entity =>
            {
                entity.ToTable("GamesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<GamesTranslation>(entity =>
            {
                entity.ToTable("GamesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(1000);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(2000)")
                    .HasMaxLength(4000);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.GamesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GamesTranslations_Languages");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.GamesTranslations)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GamesTranslations_Games");

            });
            modelBuilder.Entity<GamesTranslationsTombstone>(entity =>
            {
                entity.ToTable("GamesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<GameVersion>(entity =>
            {
                entity.ToTable("GameVersions", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Version)
                    .HasColumnName("Version")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.VersionName)
                    .HasColumnName("VersionName")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.VersionIdentifier)
                    .HasColumnName("VersionIdentifier")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ActiveDate)
                    .HasColumnName("ActiveDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.IsFeatured)
                    .HasColumnName("IsFeatured")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BetaOnly)
                    .HasColumnName("BetaOnly")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.GameVersions)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GameVersions_Games");

            });
            modelBuilder.Entity<GameVersionsTombstone>(entity =>
            {
                entity.ToTable("GameVersionsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Genders", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(40)")
                    .HasMaxLength(80);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<GendersTombstone>(entity =>
            {
                entity.ToTable("GendersTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<GendersTranslation>(entity =>
            {
                entity.ToTable("GendersTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.GendersTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GendersTranslations_Languages");

                entity.HasOne(e => e.Gender)
                    .WithMany(p => p.GendersTranslations)
                    .HasForeignKey(p => p.GenderID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GendersTranslations_Genders");

            });
            modelBuilder.Entity<GendersTranslationsTombstone>(entity =>
            {
                entity.ToTable("GendersTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Joint>(entity =>
            {
                entity.ToTable("Joints", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<JointsAcceptedStatistic>(entity =>
            {
                entity.ToTable("JointsAcceptedStatistics", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Joint)
                    .WithMany(p => p.JointsAcceptedStatistics)
                    .HasForeignKey(p => p.JointID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_JointsAcceptedStatistics_Joints");

                entity.HasOne(e => e.StatisticType)
                    .WithMany(p => p.JointsAcceptedStatistics)
                    .HasForeignKey(p => p.StatisticTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_JointsAcceptedStatistics_StatisticsTypes");

            });
            modelBuilder.Entity<JointsAcceptedStatisticsTombstone>(entity =>
            {
                entity.ToTable("JointsAcceptedStatisticsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<JointsTombstone>(entity =>
            {
                entity.ToTable("JointsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<JointsTranslation>(entity =>
            {
                entity.ToTable("JointsTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.JointsTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_JointsTranslations_Languages");

                entity.HasOne(e => e.Joint)
                    .WithMany(p => p.JointsTranslations)
                    .HasForeignKey(p => p.JointID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_JointsTranslations_Joints");

            });
            modelBuilder.Entity<JointsTranslationsTombstone>(entity =>
            {
                entity.ToTable("JointsTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Languages", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.IsoCode)
                    .HasColumnName("IsoCode")
                    .HasColumnType("nvarchar(20)")
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CountryFlag)
                    .HasColumnName("CountryFlag")
                    .HasColumnType("nvarchar(255)")
                    .HasDefaultValueSql("''")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.BetaOnly)
                    .HasColumnName("BetaOnly")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<LanguagesTombstone>(entity =>
            {
                entity.ToTable("LanguagesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<LogEntry>(entity =>
            {
                entity.ToTable("LogEntries", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LogEntryTypeID)
                    .HasColumnName("LogEntryTypeID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Message)
                    .HasColumnName("Message")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.Date)
                    .HasColumnName("Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Source)
                    .HasColumnName("Source")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(256);

                entity.Property(e => e.AppVersion)
                    .HasColumnName("AppVersion")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(256);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<LogEntriesTombstone>(entity =>
            {
                entity.ToTable("LogEntriesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<LogEntryType>(entity =>
            {
                entity.ToTable("LogEntryTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<LogEntryTypesTombstone>(entity =>
            {
                entity.ToTable("LogEntryTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<LogEntryTypesTranslation>(entity =>
            {
                entity.ToTable("LogEntryTypesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.LogEntryTypesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LogEntryTypesTranslations_Languages");

                entity.HasOne(e => e.LogEntryType)
                    .WithMany(p => p.LogEntryTypesTranslations)
                    .HasForeignKey(p => p.LogEntryTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LogEntryTypesTranslations_LogEntryTypes");

            });
            modelBuilder.Entity<LogEntryTypesTranslationsTombstone>(entity =>
            {
                entity.ToTable("LogEntryTypesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Movement>(entity =>
            {
                entity.ToTable("Movements", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(1000);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IsFeatured)
                    .HasColumnName("IsFeatured")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BetaOnly)
                    .HasColumnName("BetaOnly")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.MovementType)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(p => p.MovementTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Movements_MovementTypes");

            });
            modelBuilder.Entity<MovementsAcceptedStatistic>(entity =>
            {
                entity.ToTable("MovementsAcceptedStatistics", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Movement)
                    .WithMany(p => p.MovementsAcceptedStatistics)
                    .HasForeignKey(p => p.MovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsAcceptedStatistics_Movements");

                entity.HasOne(e => e.StatisticsType)
                    .WithMany(p => p.MovementsAcceptedStatistics)
                    .HasForeignKey(p => p.StatisticsTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsAcceptedStatistics_StatisticsTypes");

            });
            modelBuilder.Entity<MovementsAcceptedStatisticsTombstone>(entity =>
            {
                entity.ToTable("MovementsAcceptedStatisticsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<MovementsJoint>(entity =>
            {
                entity.ToTable("MovementsJoints", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Movement)
                    .WithMany(p => p.MovementsJoints)
                    .HasForeignKey(p => p.MovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsJoints_Movements");

                entity.HasOne(e => e.Joint)
                    .WithMany(p => p.MovementsJoints)
                    .HasForeignKey(p => p.JointID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsJoints_Joints");

                entity.HasOne(e => e.Side)
                    .WithMany(p => p.MovementsJoints)
                    .HasForeignKey(p => p.SideID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsJoints_Sides");

            });
            modelBuilder.Entity<MovementsJointsTombstone>(entity =>
            {
                entity.ToTable("MovementsJointsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<MovementsSide>(entity =>
            {
                entity.ToTable("MovementsSides", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Movement)
                    .WithMany(p => p.MovementsSides)
                    .HasForeignKey(p => p.MovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsSides_Movements");

                entity.HasOne(e => e.Side)
                    .WithMany(p => p.MovementsSides)
                    .HasForeignKey(p => p.SideID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsSides_Sides");

            });
            modelBuilder.Entity<MovementsSidesTombstone>(entity =>
            {
                entity.ToTable("MovementsSidesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<MovementsTombstone>(entity =>
            {
                entity.ToTable("MovementsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<MovementsTranslation>(entity =>
            {
                entity.ToTable("MovementsTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(1000);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.MovementsTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsTranslations_Languages");

                entity.HasOne(e => e.Movement)
                    .WithMany(p => p.MovementsTranslations)
                    .HasForeignKey(p => p.MovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementsTranslations_Movements");

            });
            modelBuilder.Entity<MovementsTranslationsTombstone>(entity =>
            {
                entity.ToTable("MovementsTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<MovementType>(entity =>
            {
                entity.ToTable("MovementTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<MovementTypesTombstone>(entity =>
            {
                entity.ToTable("MovementTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<MovementTypesTranslation>(entity =>
            {
                entity.ToTable("MovementTypesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.MovementTypesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementTypesTranslations_Languages");

                entity.HasOne(e => e.MovementType)
                    .WithMany(p => p.MovementTypesTranslations)
                    .HasForeignKey(p => p.MovementTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MovementTypesTranslations_MovementTypes");

            });
            modelBuilder.Entity<MovementTypesTranslationsTombstone>(entity =>
            {
                entity.ToTable("MovementTypesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<PatientField>(entity =>
            {
                entity.ToTable("PatientFields", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Position)
                    .HasColumnName("Position")
                    .HasColumnType("int");

                entity.Property(e => e.IsVisible)
                    .HasColumnName("IsVisible")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsRequired)
                    .HasColumnName("IsRequired")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.PatientFields)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientFields_Tenants");

            });
            modelBuilder.Entity<PatientFieldsTombstone>(entity =>
            {
                entity.ToTable("PatientFieldsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<PatientFieldValue>(entity =>
            {
                entity.ToTable("PatientFieldValues", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Value)
                    .HasColumnName("Value")
                    .HasColumnType("nvarchar(2000)")
                    .HasMaxLength(4000);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.PatientFieldValues)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientFieldValues_Tenants");

                entity.HasOne(e => e.PatientField)
                    .WithMany(p => p.PatientFieldValues)
                    .HasForeignKey(p => p.PatientFieldID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientFieldValues_PatientFields");

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.PatientFieldValues)
                    .HasForeignKey(p => p.PatientID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientFieldValues_Patients");

            });
            modelBuilder.Entity<PatientFieldValuesTombstone>(entity =>
            {
                entity.ToTable("PatientFieldValuesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<PatientImage>(entity =>
            {
                entity.ToTable("PatientImages", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TenantID)
                    .HasColumnName("TenantID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Image)
                    .HasColumnName("Image")
                    .HasColumnType("varbinary(MAX)");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<PatientImagesTombstone>(entity =>
            {
                entity.ToTable("PatientImagesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("DateOfBirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(1000);

                entity.Property(e => e.DateIntroducing)
                    .HasColumnName("DateIntroducing")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateRecovering)
                    .HasColumnName("DateRecovering")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsTemporary)
                    .HasColumnName("isTemporary")
                    .HasColumnType("bit");

                entity.Property(e => e.Diagnosis)
                    .HasColumnName("Diagnosis")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(100);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("IsDeleted")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreatedByUserID)
                    .HasColumnName("CreatedByUserID")
                    .HasColumnType("int");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Patients_Tenants");

                entity.HasOne(e => e.Gender)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(p => p.GenderID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Patients_Genders");

                entity.HasOne(e => e.InjuredSide)
                    .WithMany(p => p.PatientsInjuredSide)
                    .HasForeignKey(p => p.InjuredSideID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Patients_Sides");

                entity.HasOne(e => e.InteractionHand)
                    .WithMany(p => p.PatientsInteractionHand)
                    .HasForeignKey(p => p.InteractionHandID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Patients_Sides1");

                entity.HasOne(e => e.PatientImage)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(p => p.PatientImageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Patients_PatientImages");

            });
            modelBuilder.Entity<PatientsJoint>(entity =>
            {
                entity.ToTable("PatientsJoints", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.PatientsJoints)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientsJoints_Tenants");

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.PatientsJoints)
                    .HasForeignKey(p => p.PatientID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientsJoints_Patients");

                entity.HasOne(e => e.Joint)
                    .WithMany(p => p.PatientsJoints)
                    .HasForeignKey(p => p.JointID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PatientsJoints_Joints");

            });
            modelBuilder.Entity<PatientsJointsTombstone>(entity =>
            {
                entity.ToTable("PatientsJointsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<PatientsTombstone>(entity =>
            {
                entity.ToTable("PatientsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permissions", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(256)")
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(256)")
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<PermissionsTombstone>(entity =>
            {
                entity.ToTable("PermissionsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<PermissionsTranslation>(entity =>
            {
                entity.ToTable("PermissionsTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(256)")
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.PermissionsTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PermissionsTranslations_Languages");

                entity.HasOne(e => e.Permission)
                    .WithMany(p => p.PermissionsTranslations)
                    .HasForeignKey(p => p.PermissionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PermissionsTranslations_Permissions");

            });
            modelBuilder.Entity<PermissionsTranslationsTombstone>(entity =>
            {
                entity.ToTable("PermissionsTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.ToTable("QuestionAnswers", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Value)
                    .HasColumnName("Value")
                    .HasColumnType("float");

                entity.Property(e => e.Text)
                    .HasColumnName("Text")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.Date)
                    .HasColumnName("Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionAnswers_Tenants");

                entity.HasOne(e => e.Question)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(p => p.QuestionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionAnswers_Questions");

                entity.HasOne(e => e.Session)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(p => p.SessionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionAnswers_Sessions");

                entity.HasOne(e => e.ScheduleItem)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(p => p.ScheduleItemID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionAnswers_ScheduleItems");

            });
            modelBuilder.Entity<QuestionAnswersTombstone>(entity =>
            {
                entity.ToTable("QuestionAnswersTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<QuestionDisplayType>(entity =>
            {
                entity.ToTable("QuestionDisplayTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(200)")
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.QuestionType)
                    .WithMany(p => p.QuestionDisplayTypes)
                    .HasForeignKey(p => p.QuestionTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionDisplayTypes_QuestionTypes");

            });
            modelBuilder.Entity<QuestionDisplayTypesTombstone>(entity =>
            {
                entity.ToTable("QuestionDisplayTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<QuestionDisplayTypesTranslation>(entity =>
            {
                entity.ToTable("QuestionDisplayTypesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.QuestionDisplayTypesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionDisplayTypesTranslations_Languages");

                entity.HasOne(e => e.QuestionDisplayType)
                    .WithMany(p => p.QuestionDisplayTypesTranslations)
                    .HasForeignKey(p => p.QuestionDisplayTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionDisplayTypesTranslations_QuestionDisplayTypes");

            });
            modelBuilder.Entity<QuestionDisplayTypesTranslationsTombstone>(entity =>
            {
                entity.ToTable("QuestionDisplayTypesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<QuestionnaireQuestion>(entity =>
            {
                entity.ToTable("QuestionnaireQuestions", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Position)
                    .HasColumnName("Position")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.RestrictedTenant)
                    .WithMany(p => p.QuestionnaireQuestions)
                    .HasForeignKey(p => p.RestrictedTenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionnaireQuestions_Tenants");

                entity.HasOne(e => e.Questionnaire)
                    .WithMany(p => p.QuestionnaireQuestions)
                    .HasForeignKey(p => p.QuestionnaireID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionnaireQuestions_Questionnaires");

                entity.HasOne(e => e.Question)
                    .WithMany(p => p.QuestionnaireQuestions)
                    .HasForeignKey(p => p.QuestionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionnaireQuestions_Questions");

            });
            modelBuilder.Entity<QuestionnaireQuestionsTombstone>(entity =>
            {
                entity.ToTable("QuestionnaireQuestionsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Questionnaire>(entity =>
            {
                entity.ToTable("Questionnaires", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsSystem)
                    .HasColumnName("IsSystem")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsByDefaultEnabled)
                    .HasColumnName("IsByDefaultEnabled")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.RestrictedTenant)
                    .WithMany(p => p.Questionnaires)
                    .HasForeignKey(p => p.RestrictedTenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Questionnaires_Tenants");

            });
            modelBuilder.Entity<QuestionnairesTombstone>(entity =>
            {
                entity.ToTable("QuestionnairesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<QuestionnairesTranslation>(entity =>
            {
                entity.ToTable("QuestionnairesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.QuestionnairesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionnairesTranslations_Languages");

                entity.HasOne(e => e.Questionnaire)
                    .WithMany(p => p.QuestionnairesTranslations)
                    .HasForeignKey(p => p.QuestionnaireID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionnairesTranslations_Questionnaires");

            });
            modelBuilder.Entity<QuestionnairesTranslationsTombstone>(entity =>
            {
                entity.ToTable("QuestionnairesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Questions", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Text)
                    .HasColumnName("Text")
                    .HasColumnType("nvarchar(MAX)")
                    .IsRequired();

                entity.Property(e => e.IsSystem)
                    .HasColumnName("IsSystem")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsUserSelectable)
                    .HasColumnName("IsUserSelectable")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.RestrictedTenant)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(p => p.RestrictedTenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Questions_Tenants");

                entity.HasOne(e => e.QuestionDisplayType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(p => p.QuestionDisplayTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Questions_QuestionDisplayTypes");

            });
            modelBuilder.Entity<QuestionsTombstone>(entity =>
            {
                entity.ToTable("QuestionsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<QuestionsTranslation>(entity =>
            {
                entity.ToTable("QuestionsTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Text)
                    .HasColumnName("Text")
                    .HasColumnType("nvarchar(MAX)")
                    .IsRequired();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.QuestionsTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionsTranslations_Languages");

                entity.HasOne(e => e.Question)
                    .WithMany(p => p.QuestionsTranslations)
                    .HasForeignKey(p => p.QuestionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionsTranslations_Questions");

            });
            modelBuilder.Entity<QuestionsTranslationsTombstone>(entity =>
            {
                entity.ToTable("QuestionsTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.ToTable("QuestionTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<QuestionTypesTombstone>(entity =>
            {
                entity.ToTable("QuestionTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<QuestionTypesTranslation>(entity =>
            {
                entity.ToTable("QuestionTypesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.QuestionTypesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionTypesTranslations_Languages");

                entity.HasOne(e => e.QuestionType)
                    .WithMany(p => p.QuestionTypesTranslations)
                    .HasForeignKey(p => p.QuestionTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_QuestionTypesTranslations_QuestionTypes");

            });
            modelBuilder.Entity<QuestionTypesTranslationsTombstone>(entity =>
            {
                entity.ToTable("QuestionTypesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<RangeOfMotion>(entity =>
            {
                entity.ToTable("RangeOfMotion", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.RangeOfMotions)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RangeOfMotion_Tenants");

            });
            modelBuilder.Entity<RangeOfMotionTombstone>(entity =>
            {
                entity.ToTable("RangeOfMotionTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("RolePermissions", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(p => p.RoleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolePermissions_Roles");

                entity.HasOne(e => e.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(p => p.PermissionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolePermissions_Permissions");

            });
            modelBuilder.Entity<RolePermissionsTombstone>(entity =>
            {
                entity.ToTable("RolePermissionsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<RoleSetting>(entity =>
            {
                entity.ToTable("RoleSettings", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TokenLifetimeSeconds)
                    .HasColumnName("TokenLifetimeSeconds")
                    .HasColumnType("int")
                    .HasDefaultValueSql("86400");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.RoleSettings)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RoleSettings_Tenants");

                entity.HasOne(e => e.Role)
                    .WithMany(p => p.RoleSettings)
                    .HasForeignKey(p => p.RoleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RoleSettings_Roles");

            });
            modelBuilder.Entity<RoleSettingsTombstone>(entity =>
            {
                entity.ToTable("RoleSettingsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<RolesTombstone>(entity =>
            {
                entity.ToTable("RolesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<RolesTranslation>(entity =>
            {
                entity.ToTable("RolesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.RolesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolesTranslations_Languages");

                entity.HasOne(e => e.Role)
                    .WithMany(p => p.RolesTranslations)
                    .HasForeignKey(p => p.RoleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolesTranslations_Roles");

            });
            modelBuilder.Entity<RolesTranslationsTombstone>(entity =>
            {
                entity.ToTable("RolesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<RomMovement>(entity =>
            {
                entity.ToTable("RomMovements", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.RomMovements)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RomMovements_Tenants");

                entity.HasOne(e => e.RangeOfMotion)
                    .WithMany(p => p.RomMovements)
                    .HasForeignKey(p => p.RangeOfMotionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RomMovements_RangeOfMotion");

                entity.HasOne(e => e.Movement)
                    .WithMany(p => p.RomMovements)
                    .HasForeignKey(p => p.MovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RomMovements_Movements");

                entity.HasOne(e => e.Side)
                    .WithMany(p => p.RomMovements)
                    .HasForeignKey(p => p.SideID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RomMovements_Sides");

            });
            modelBuilder.Entity<RomMovementsTombstone>(entity =>
            {
                entity.ToTable("RomMovementsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SavedSchedule>(entity =>
            {
                entity.ToTable("SavedSchedules", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(500)")
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("AddedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.SavedSchedules)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SavedSchedules_Tenants");

                entity.HasOne(e => e.Schedule)
                    .WithMany(p => p.SavedSchedules)
                    .HasForeignKey(p => p.ScheduleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SavedSchedules_Schedules");

                entity.HasOne(e => e.Difficulty)
                    .WithMany(p => p.SavedSchedules)
                    .HasForeignKey(p => p.DifficultyID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SavedSchedules_Difficulties");

            });
            modelBuilder.Entity<SavedSchedulesTombstone>(entity =>
            {
                entity.ToTable("SavedSchedulesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<ScheduleItem>(entity =>
            {
                entity.ToTable("ScheduleItems", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Order)
                    .HasColumnName("Order")
                    .HasColumnType("int");

                entity.Property(e => e.Duration)
                    .HasColumnName("Duration")
                    .HasColumnType("int")
                    .HasDefaultValueSql("300");

                entity.Property(e => e.PauseAfter)
                    .HasColumnName("PauseAfter")
                    .HasColumnType("int")
                    .HasDefaultValueSql("60");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItems_Tenants");

                entity.HasOne(e => e.Schedule)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(p => p.ScheduleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItems_Schedules");

                entity.HasOne(e => e.ScheduleItemType)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(p => p.ScheduleItemTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItems_ScheduleItemTypes");

                entity.HasOne(e => e.ExerGame)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(p => p.ExerGameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItems_ExerGame");

                entity.HasOne(e => e.RangeOfMotion)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(p => p.RangeOfMotionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItems_RangeOfMotions");

                entity.HasOne(e => e.CognitiveGame)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(p => p.CognitiveGameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItems_CognitiveGames");

                entity.HasOne(e => e.Questionnaire)
                    .WithMany(p => p.ScheduleItems)
                    .HasForeignKey(p => p.QuestionnaireID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItems_Questionnaires");

            });
            modelBuilder.Entity<ScheduleItemsTombstone>(entity =>
            {
                entity.ToTable("ScheduleItemsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<ScheduleItemType>(entity =>
            {
                entity.ToTable("ScheduleItemTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<ScheduleItemTypesTombstone>(entity =>
            {
                entity.ToTable("ScheduleItemTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<ScheduleItemTypesTranslation>(entity =>
            {
                entity.ToTable("ScheduleItemTypesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.ScheduleItemTypesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItemTypesTranslations_Languages");

                entity.HasOne(e => e.ScheduleItemType)
                    .WithMany(p => p.ScheduleItemTypesTranslations)
                    .HasForeignKey(p => p.ScheduleItemTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ScheduleItemTypesTranslations_ScheduleItemTypes");

            });
            modelBuilder.Entity<ScheduleItemTypesTranslationsTombstone>(entity =>
            {
                entity.ToTable("ScheduleItemTypesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedules", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Pause)
                    .HasColumnName("Pause")
                    .HasColumnType("int");

                entity.Property(e => e.HasCalibration)
                    .HasColumnName("HasCalibration")
                    .HasColumnType("bit");

                entity.Property(e => e.HasTutorial)
                    .HasColumnName("HasTutorial")
                    .HasColumnType("bit");

                entity.Property(e => e.HasGameTutorial)
                    .HasColumnName("HasGameTutorial")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Schedules_Tenants");

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(p => p.PatientID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Schedules_Patients");

            });
            modelBuilder.Entity<SchedulesTombstone>(entity =>
            {
                entity.ToTable("SchedulesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SensorMovement>(entity =>
            {
                entity.ToTable("SensorMovements", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Sensor)
                    .WithMany(p => p.SensorMovements)
                    .HasForeignKey(p => p.SensorID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SensorMovements_Sensors");

                entity.HasOne(e => e.Movement)
                    .WithMany(p => p.SensorMovements)
                    .HasForeignKey(p => p.MovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SensorMovements_Movements");

            });
            modelBuilder.Entity<SensorMovementsTombstone>(entity =>
            {
                entity.ToTable("SensorMovementsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.ToTable("Sensors", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(32)")
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(512)")
                    .HasMaxLength(1024);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<SensorsTombstone>(entity =>
            {
                entity.ToTable("SensorsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SensorsTranslation>(entity =>
            {
                entity.ToTable("SensorsTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(512)")
                    .HasMaxLength(1024);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.SensorsTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SensorsTranslations_Languages");

                entity.HasOne(e => e.Sensor)
                    .WithMany(p => p.SensorsTranslations)
                    .HasForeignKey(p => p.SensorID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SensorsTranslations_Sensors");

            });
            modelBuilder.Entity<SensorsTranslationsTombstone>(entity =>
            {
                entity.ToTable("SensorsTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SessionImage>(entity =>
            {
                entity.ToTable("SessionImages", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TenantID)
                    .HasColumnName("TenantID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.CaptureImage)
                    .HasColumnName("CaptureImage")
                    .HasColumnType("varbinary(MAX)");

                entity.Property(e => e.CaptureDate)
                    .HasColumnName("CaptureDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExternalUri)
                    .HasColumnName("ExternalUri")
                    .HasColumnType("nvarchar(2100)")
                    .HasMaxLength(4200);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Session)
                    .WithMany(p => p.SessionImages)
                    .HasForeignKey(p => p.SessionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SessionImages_Sessions");

                entity.HasOne(e => e.ScheduleItem)
                    .WithMany(p => p.SessionImages)
                    .HasForeignKey(p => p.ScheduleItemID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SessionImages_ScheduleItems");

            });
            modelBuilder.Entity<SessionImagesTombstone>(entity =>
            {
                entity.ToTable("SessionImagesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Sessions", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PlayedAtHome)
                    .HasColumnName("PlayedAtHome")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LoggedInUserId)
                    .HasColumnName("LoggedInUserId")
                    .HasColumnType("int");

                entity.Property(e => e.Date)
                    .HasColumnName("Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("IsDeleted")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sessions_Tenants");

                entity.HasOne(e => e.Schedule)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(p => p.ScheduleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sessions_Schedules");

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(p => p.PatientID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sessions_Patients");

                entity.HasOne(e => e.Sensor)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(p => p.SensorID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sessions_Sensors");

            });
            modelBuilder.Entity<SessionsTombstone>(entity =>
            {
                entity.ToTable("SessionsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SettingDescriptorCategory>(entity =>
            {
                entity.ToTable("SettingDescriptorCategories", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .HasMaxLength(510);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(2000)")
                    .HasMaxLength(4000);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<SettingDescriptorCategoriesTombstone>(entity =>
            {
                entity.ToTable("SettingDescriptorCategoriesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SettingDescriptorCategoriesTranslation>(entity =>
            {
                entity.ToTable("SettingDescriptorCategoriesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .HasMaxLength(510);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(2000)")
                    .HasMaxLength(4000);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.SettingDescriptorCategoriesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SettingDescriptorCategoriesTranslations_Languages");

                entity.HasOne(e => e.SettingDescriptorCategory)
                    .WithMany(p => p.SettingDescriptorCategoriesTranslations)
                    .HasForeignKey(p => p.SettingDescriptorCategoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SettingDescriptorCategoriesTranslations_SettingDescriptorCategories");

            });
            modelBuilder.Entity<SettingDescriptorCategoriesTranslationsTombstone>(entity =>
            {
                entity.ToTable("SettingDescriptorCategoriesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SettingDescriptor>(entity =>
            {
                entity.ToTable("SettingDescriptors", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DefaultValueID)
                    .HasColumnName("DefaultValueID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(500)")
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(2000)")
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.TechnicalName)
                    .HasColumnName("TechnicalName")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.SettingDescriptorCategory)
                    .WithMany(p => p.SettingDescriptors)
                    .HasForeignKey(p => p.SettingDescriptorCategoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SettingDescriptors_SettingDescriptorsCategories");

            });
            modelBuilder.Entity<SettingDescriptorsTombstone>(entity =>
            {
                entity.ToTable("SettingDescriptorsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SettingDescriptorsTranslation>(entity =>
            {
                entity.ToTable("SettingDescriptorsTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(500)")
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(2000)")
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.SettingDescriptorsTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SettingDescriptorsTranslations_Languages");

                entity.HasOne(e => e.SettingDescriptor)
                    .WithMany(p => p.SettingDescriptorsTranslations)
                    .HasForeignKey(p => p.SettingDescriptorID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SettingDescriptorsTranslations_SettingDescriptors");

            });
            modelBuilder.Entity<SettingDescriptorsTranslationsTombstone>(entity =>
            {
                entity.ToTable("SettingDescriptorsTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SettingValue>(entity =>
            {
                entity.ToTable("SettingValues", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TextValue)
                    .HasColumnName("TextValue")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.IntValue)
                    .HasColumnName("IntValue")
                    .HasColumnType("int");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.SettingDescriptor)
                    .WithMany(p => p.SettingValues)
                    .HasForeignKey(p => p.SettingDescriptorID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SettingValues_SettingsDescriptors");

            });
            modelBuilder.Entity<SettingValuesTombstone>(entity =>
            {
                entity.ToTable("SettingValuesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SettingValuesTranslation>(entity =>
            {
                entity.ToTable("SettingValuesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.TextValue)
                    .HasColumnName("TextValue")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.SettingValuesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SettingValuesTranslations_Languages");

                entity.HasOne(e => e.SettingValue)
                    .WithMany(p => p.SettingValuesTranslations)
                    .HasForeignKey(p => p.SettingValueID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SettingValuesTranslations_SettingValues");

            });
            modelBuilder.Entity<SettingValuesTranslationsTombstone>(entity =>
            {
                entity.ToTable("SettingValuesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<Side>(entity =>
            {
                entity.ToTable("Sides", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<SidesTombstone>(entity =>
            {
                entity.ToTable("SidesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SidesTranslation>(entity =>
            {
                entity.ToTable("SidesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.SidesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SidesTranslations_Languages");

                entity.HasOne(e => e.Side)
                    .WithMany(p => p.SidesTranslations)
                    .HasForeignKey(p => p.SideID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SidesTranslations_Sides");

            });
            modelBuilder.Entity<SidesTranslationsTombstone>(entity =>
            {
                entity.ToTable("SidesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsAggregationType>(entity =>
            {
                entity.ToTable("StatisticsAggregationTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<StatisticsAggregationTypesTombstone>(entity =>
            {
                entity.ToTable("StatisticsAggregationTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsAggregationTypesTranslation>(entity =>
            {
                entity.ToTable("StatisticsAggregationTypesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.StatisticsAggregationTypesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsAggregationTypesTranslations_Languages");

                entity.HasOne(e => e.StatisticsAggregationType)
                    .WithMany(p => p.StatisticsAggregationTypesTranslations)
                    .HasForeignKey(p => p.StatisticsAggregationTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsAggregationTypesTranslations_StatisticsAggregationTypes");

            });
            modelBuilder.Entity<StatisticsAggregationTypesTranslationsTombstone>(entity =>
            {
                entity.ToTable("StatisticsAggregationTypesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsCategory>(entity =>
            {
                entity.ToTable("StatisticsCategories", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<StatisticsCategoriesTombstone>(entity =>
            {
                entity.ToTable("StatisticsCategoriesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsCategoriesTranslation>(entity =>
            {
                entity.ToTable("StatisticsCategoriesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.StatisticsCategoriesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsCategoriesTranslations_Languages");

                entity.HasOne(e => e.StatisticsCategory)
                    .WithMany(p => p.StatisticsCategoriesTranslations)
                    .HasForeignKey(p => p.StatisticsCategoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsCategoriesTranslations_StatisticsCategories");

            });
            modelBuilder.Entity<StatisticsCategoriesTranslationsTombstone>(entity =>
            {
                entity.ToTable("StatisticsCategoriesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsType>(entity =>
            {
                entity.ToTable("StatisticsTypes", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Unit)
                    .HasColumnName("Unit")
                    .HasColumnType("nvarchar(20)")
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(60)")
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.StatisticsCategory)
                    .WithMany(p => p.StatisticsTypes)
                    .HasForeignKey(p => p.StatisticsCategoryID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsTypes_StatisticsCategories");

                entity.HasOne(e => e.StatisticsAggregationType)
                    .WithMany(p => p.StatisticsTypes)
                    .HasForeignKey(p => p.StatisticsAggregationTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsTypes_StatisticsAggregationTypes");

                entity.HasOne(e => e.StatisticsUnit)
                    .WithMany(p => p.StatisticsTypes)
                    .HasForeignKey(p => p.StatisticsUnitID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsTypes_StatisticsUnits");

            });
            modelBuilder.Entity<StatisticsTypesTombstone>(entity =>
            {
                entity.ToTable("StatisticsTypesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsTypesTranslation>(entity =>
            {
                entity.ToTable("StatisticsTypesTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Unit)
                    .HasColumnName("Unit")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.StatisticsTypesTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsTypesTranslations_Languages");

                entity.HasOne(e => e.StatisticsType)
                    .WithMany(p => p.StatisticsTypesTranslations)
                    .HasForeignKey(p => p.StatisticsTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsTypesTranslations_StatisticsTypes");

            });
            modelBuilder.Entity<StatisticsTypesTranslationsTombstone>(entity =>
            {
                entity.ToTable("StatisticsTypesTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsUnit>(entity =>
            {
                entity.ToTable("StatisticsUnits", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.DataUnit)
                    .HasColumnName("DataUnit")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DisplayUnitShort)
                    .HasColumnName("DisplayUnitShort")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DisplayUnitLongSingular)
                    .HasColumnName("DisplayUnitLongSingular")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DisplayUnitLongPlural)
                    .HasColumnName("DisplayUnitLongPlural")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DisplayUnitConversionFactor)
                    .HasColumnName("DisplayUnitConversionFactor")
                    .HasColumnType("real");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<StatisticsUnitsTombstone>(entity =>
            {
                entity.ToTable("StatisticsUnitsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsUnitsTranslation>(entity =>
            {
                entity.ToTable("StatisticsUnitsTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.DataUnit)
                    .HasColumnName("DataUnit")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DisplayUnitShort)
                    .HasColumnName("DisplayUnitShort")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DisplayUnitLongSingular)
                    .HasColumnName("DisplayUnitLongSingular")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DisplayUnitLongPlural)
                    .HasColumnName("DisplayUnitLongPlural")
                    .HasColumnType("nvarchar(250)")
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.StatisticsUnitsTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsUnitsTranslations_Languages");

                entity.HasOne(e => e.StatisticsUnit)
                    .WithMany(p => p.StatisticsUnitsTranslations)
                    .HasForeignKey(p => p.StatisticsUnitID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsUnitsTranslations_StatisticsUnits");

            });
            modelBuilder.Entity<StatisticsUnitsTranslationsTombstone>(entity =>
            {
                entity.ToTable("StatisticsUnitsTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<StatisticsValue>(entity =>
            {
                entity.ToTable("StatisticsValues", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Timestamp)
                    .HasColumnName("Timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasColumnName("Value")
                    .HasColumnType("float");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.StatisticsValues)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsValues_Tenants");

                entity.HasOne(e => e.Session)
                    .WithMany(p => p.StatisticsValues)
                    .HasForeignKey(p => p.SessionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsValues_Sessions1");

                entity.HasOne(e => e.ScheduleItem)
                    .WithMany(p => p.StatisticsValues)
                    .HasForeignKey(p => p.ScheduleItemID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsValues_ScheduleItems1");

                entity.HasOne(e => e.StatisticType)
                    .WithMany(p => p.StatisticsValues)
                    .HasForeignKey(p => p.StatisticTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsValues_StatisticsTypes");

                entity.HasOne(e => e.Joint)
                    .WithMany(p => p.StatisticsValues)
                    .HasForeignKey(p => p.JointID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsValues_Joints");

                entity.HasOne(e => e.RomMovement)
                    .WithMany(p => p.StatisticsValues)
                    .HasForeignKey(p => p.RomMovementID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_StatisticsValues_RomMovements");

            });
            modelBuilder.Entity<StatisticsValuesTombstone>(entity =>
            {
                entity.ToTable("StatisticsValuesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<SyncChange>(entity =>
            {
                entity.ToTable("SyncChanges", "Audit");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ChangeSet)
                    .HasColumnName("ChangeSet")
                    .HasColumnType("nvarchar(MAX)")
                    .IsRequired();

                entity.Property(e => e.Error)
                    .HasColumnName("Error")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.TenantId)
                    .HasColumnName("TenantId")
                    .HasColumnType("int");

                entity.Property(e => e.SyncAnchor)
                    .HasColumnName("SyncAnchor")
                    .HasColumnType("datetime");

                entity.Property(e => e.Info)
                    .HasColumnName("Info")
                    .HasColumnType("nvarchar(MAX)");

                entity.Property(e => e.Date)
                    .HasColumnName("Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.HasOne(e => e.SyncState)
                    .WithMany(p => p.SyncChanges)
                    .HasForeignKey(p => p.SyncStateID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sync_SyncStatus");

                entity.HasOne(e => e.SyncDirection)
                    .WithMany(p => p.SyncChanges)
                    .HasForeignKey(p => p.SyncDirectionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sync_SyncDirection");

            });
            modelBuilder.Entity<SyncDirection>(entity =>
            {
                entity.ToTable("SyncDirection", "Audit");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

            });
            modelBuilder.Entity<SyncState>(entity =>
            {
                entity.ToTable("SyncStates", "Audit");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

            });
            modelBuilder.Entity<Sysdiagram>(entity =>
            {
                entity.ToTable("sysdiagrams", "dbo");
                entity.HasKey(e => e.diagram_id);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("sysname");

                entity.Property(e => e.PrincipalId)
                    .HasColumnName("principal_id")
                    .HasColumnType("int");

                entity.Property(e => e.DiagramId)
                    .HasColumnName("diagram_id")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int");

                entity.Property(e => e.Definition)
                    .HasColumnName("definition")
                    .HasColumnType("varbinary(MAX)");

            });
            modelBuilder.Entity<TenantGameVersion>(entity =>
            {
                entity.ToTable("TenantGameVersions", "Tenant");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Enabled)
                    .HasColumnName("Enabled")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.TenantGameVersions)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TenantGameVersions_Tenants");

                entity.HasOne(e => e.Game)
                    .WithMany(p => p.TenantGameVersions)
                    .HasForeignKey(p => p.GameID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TenantGameVersions_Games");

                entity.HasOne(e => e.GameVersion)
                    .WithMany(p => p.TenantGameVersions)
                    .HasForeignKey(p => p.GameVersionID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TenantGameVersions_GameVersions");

            });
            modelBuilder.Entity<TenantQuestionnaire>(entity =>
            {
                entity.ToTable("TenantQuestionnaires", "Tenant");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Enabled)
                    .HasColumnName("Enabled")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.TenantQuestionnaires)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TenantQuestionnaires_Tenants");

                entity.HasOne(e => e.Questionnaire)
                    .WithMany(p => p.TenantQuestionnaires)
                    .HasForeignKey(p => p.QuestionnaireID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TenantQuestionnaires_Questionnaires");

            });
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenants", "Tenant");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LicenceExpireDate)
                    .HasColumnName("LicenceExpireDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IsActive")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsDemo)
                    .HasColumnName("IsDemo")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TakeSchedulePictures)
                    .HasColumnName("TakeSchedulePictures")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CreatedBy")
                    .HasColumnType("nvarchar(255)")
                    .HasMaxLength(510);

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.HasOne(e => e.TenantType)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(p => p.TenantTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tenants_TenantType");

                entity.HasOne(e => e.UpdateType)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(p => p.UpdateTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tenants_UpdateType");

            });
            modelBuilder.Entity<TenantType>(entity =>
            {
                entity.ToTable("TenantType", "Tenant");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

            });
            modelBuilder.Entity<Tutorial>(entity =>
            {
                entity.ToTable("Tutorials", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(2048)")
                    .IsRequired()
                    .HasMaxLength(4096);

                entity.Property(e => e.Order)
                    .HasColumnName("Order")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ForPatient)
                    .HasColumnName("ForPatient")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SourceUri)
                    .HasColumnName("SourceUri")
                    .HasColumnType("nvarchar(MAX)")
                    .IsRequired()
                    .HasMaxLength(8000);

                entity.Property(e => e.Thumb)
                    .HasColumnName("Thumb")
                    .HasColumnType("varbinary(MAX)");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.TutorialSource)
                    .WithMany(p => p.Tutorials)
                    .HasForeignKey(p => p.TutorialSourceID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tutorials_TutorialSource");

            });
            modelBuilder.Entity<TutorialSource>(entity =>
            {
                entity.ToTable("TutorialSource", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(80)")
                    .IsRequired()
                    .HasMaxLength(160);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

            });
            modelBuilder.Entity<TutorialSourceTombstone>(entity =>
            {
                entity.ToTable("TutorialSourceTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<TutorialSourceTranslation>(entity =>
            {
                entity.ToTable("TutorialSourceTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.TutorialSourceTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TutorialSourceTranslations_Languages");

                entity.HasOne(e => e.TutorialSource)
                    .WithMany(p => p.TutorialSourceTranslations)
                    .HasForeignKey(p => p.TutorialSourceID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TutorialSourceTranslations_TutorialSource");

            });
            modelBuilder.Entity<TutorialSourceTranslationsTombstone>(entity =>
            {
                entity.ToTable("TutorialSourceTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<TutorialsTombstone>(entity =>
            {
                entity.ToTable("TutorialsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<TutorialsTranslation>(entity =>
            {
                entity.ToTable("TutorialsTranslations", "Lang");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Synthetic)
                    .HasColumnName("Synthetic")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(2048)")
                    .IsRequired()
                    .HasMaxLength(4096);

                entity.Property(e => e.SourceUri)
                    .HasColumnName("SourceUri")
                    .HasColumnType("nvarchar(MAX)")
                    .IsRequired()
                    .HasMaxLength(8000);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Language)
                    .WithMany(p => p.TutorialsTranslations)
                    .HasForeignKey(p => p.LanguageID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TutorialsTranslations_Languages");

                entity.HasOne(e => e.Tutorial)
                    .WithMany(p => p.TutorialsTranslations)
                    .HasForeignKey(p => p.TutorialID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TutorialsTranslations_Tutorials");

            });
            modelBuilder.Entity<TutorialsTranslationsTombstone>(entity =>
            {
                entity.ToTable("TutorialsTranslationsTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<UpdateType>(entity =>
            {
                entity.ToTable("UpdateType", "Tenant");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.TechName)
                    .HasColumnName("TechName")
                    .HasColumnType("nvarchar(255)")
                    .IsRequired()
                    .HasMaxLength(510);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("nvarchar(1024)")
                    .HasMaxLength(2048);

            });
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRoles_Tenants");

                entity.HasOne(e => e.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(p => p.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRoles_Users");

                entity.HasOne(e => e.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(p => p.RoleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRoles_Roles");

            });
            modelBuilder.Entity<UserRolesTombstone>(entity =>
            {
                entity.ToTable("UserRolesTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "dbo");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("nvarchar(50)")
                    .HasMaxLength(100);

                entity.Property(e => e.EMail)
                    .HasColumnName("EMail")
                    .HasColumnType("nvarchar(512)")
                    .HasMaxLength(1024);

                entity.Property(e => e.IsEmailConfirmed)
                    .HasColumnName("IsEmailConfirmed")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreatedByUserID)
                    .HasColumnName("CreatedByUserID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddedDate)
                    .HasColumnName("AddedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasColumnName("UserName")
                    .HasColumnType("nvarchar(256)")
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("IsDeleted")
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("newsequentialid()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastEditDate)
                    .HasColumnName("LastEditDate")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.Tenant)
                    .WithMany(p => p.Users)
                    .HasForeignKey(p => p.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Users_Tenants");

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Users)
                    .HasForeignKey(p => p.PatientID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Users_Patients");

            });
            modelBuilder.Entity<UsersTombstone>(entity =>
            {
                entity.ToTable("UsersTombstone", "Tomb");
                entity.HasKey(e => e.RowGuid);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGuid")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeletionDate)
                    .HasColumnName("DeletionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

            });
        }
    }
}