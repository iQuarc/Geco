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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

namespace Mira.Web.DataAccess.SyncContext
{
    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class _RefactorLog
    {
        // Key Properties
        public Guid OperationKey {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AspNetRole
    {
        // Key Properties
        public int Id {get; set;}

        // Scalar Properties
        public string Description {get; set;}
        public string Name {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<AspNetUserRole> AspNetUserRoles {get; set;}

        public AspNetRole()
        {
            this.AspNetUserRoles = new List<AspNetUserRole>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AspNetUserClaim
    {
        // Key Properties
        public int Id {get; set;}

        // Scalar Properties
        public int UserId {get; set;}
        public string ClaimType {get; set;}
        public string ClaimValue {get; set;}

        // Foreign keys
        [JsonIgnore]
        public AspNetUser User {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AspNetUserLogin
    {
        // Key Properties
        public string LoginProvider {get; set;}
        public string ProviderKey {get; set;}
        public int UserId {get; set;}

        // Foreign keys
        [JsonIgnore]
        public AspNetUser User {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AspNetUserRole
    {
        // Key Properties
        public int UserId {get; set;}
        public int RoleId {get; set;}

        // Foreign keys
        [JsonIgnore]
        public AspNetRole Role {get; set;}
        [JsonIgnore]
        public AspNetUser User {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AspNetUser
    {
        // Key Properties
        public int Id {get; set;}

        // Scalar Properties
        public string Email {get; set;}
        public bool EmailConfirmed {get; set;}
        public string PasswordHash {get; set;}
        public string SecurityStamp {get; set;}
        public string PhoneNumber {get; set;}
        public bool PhoneNumberConfirmed {get; set;}
        public bool TwoFactorEnabled {get; set;}
        public DateTime? LockoutEndDateUtc {get; set;}
        public bool LockoutEnabled {get; set;}
        public int AccessFailedCount {get; set;}
        public string UserName {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<AspNetUserClaim> AspNetUserClaims {get; set;}
        [JsonIgnore]
        public List<AspNetUserLogin> AspNetUserLogins {get; set;}
        [JsonIgnore]
        public List<AspNetUserRole> AspNetUserRoles {get; set;}

        public AspNetUser()
        {
            this.AspNetUserClaims = new List<AspNetUserClaim>();
            this.AspNetUserLogins = new List<AspNetUserLogin>();
            this.AspNetUserRoles = new List<AspNetUserRole>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AssignedPatient
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int TargetUserID {get; set;}
        public int AssignedID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Patient Assigned {get; set;}
        [JsonIgnore]
        public User TargetUser {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AssignedPatientsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AssignedUser
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int TargetUserID {get; set;}
        public int AssignedID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public User Assigned {get; set;}
        [JsonIgnore]
        public User TargetUser {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AssignedUsersTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AuditEntry
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int AuditEntryTypeID {get; set;}
        public string UserName {get; set;}
        public DateTime AuditDate {get; set;}
        public string AuditMessage {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public AuditEntryType AuditEntryType {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AuditEntriesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AuditEntryType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<AuditEntry> AuditEntries {get; set;}
        [JsonIgnore]
        public List<AuditEntryTypesTranslation> AuditEntryTypesTranslations {get; set;}

        public AuditEntryType()
        {
            this.AuditEntries = new List<AuditEntry>();
            this.AuditEntryTypesTranslations = new List<AuditEntryTypesTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AuditEntryTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AuditEntryTypesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int AuditEntryTypeID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public AuditEntryType AuditEntryType {get; set;}
        [JsonIgnore]
        public Language Language {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class AuditEntryTypesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class CogniGame
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int GameID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<CogniGameSettingsValue> CogniGameSettingsValues {get; set;}
        [JsonIgnore]
        public List<ScheduleItem> ScheduleItems {get; set;}

        public CogniGame()
        {
            this.CogniGameSettingsValues = new List<CogniGameSettingsValue>();
            this.ScheduleItems = new List<ScheduleItem>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class CogniGameSettingsValue
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int CognitiveGameID {get; set;}
        public int SettingValueID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public CogniGame CognitiveGame {get; set;}
        [JsonIgnore]
        public SettingValue SettingValue {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class CogniGameSettingsValuesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class CogniGamesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Difficulty
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<DifficultiesTranslation> DifficultiesTranslations {get; set;}
        [JsonIgnore]
        public List<SavedSchedule> SavedSchedules {get; set;}

        public Difficulty()
        {
            this.DifficultiesTranslations = new List<DifficultiesTranslation>();
            this.SavedSchedules = new List<SavedSchedule>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class DifficultiesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class DifficultiesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int DifficultyID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Difficulty Difficulty {get; set;}
        [JsonIgnore]
        public Language Language {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class DifficultiesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ExerGame
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int MovementID {get; set;}
        public int GameID {get; set;}
        public int SideID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}
        [JsonIgnore]
        public Movement Movement {get; set;}
        [JsonIgnore]
        public Side Side {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<ExerGameSettingsValue> ExerGameSettingsValues {get; set;}
        [JsonIgnore]
        public List<GamesSetting> GamesSettings {get; set;}
        [JsonIgnore]
        public List<ScheduleItem> ScheduleItems {get; set;}

        public ExerGame()
        {
            this.ExerGameSettingsValues = new List<ExerGameSettingsValue>();
            this.GamesSettings = new List<GamesSetting>();
            this.ScheduleItems = new List<ScheduleItem>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ExerGameSettingsValue
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int ExerGameID {get; set;}
        public int SettingValueID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public ExerGame ExerGame {get; set;}
        [JsonIgnore]
        public SettingValue SettingValue {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ExerGameSettingsValuesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ExerGameTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameMovement
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int GameID {get; set;}
        public int MovementID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}
        [JsonIgnore]
        public Movement Movement {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameMovementsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameMovementType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int GameID {get; set;}
        public int MovementTypeID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}
        [JsonIgnore]
        public MovementType MovementType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameMovementTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Game
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string Description {get; set;}
        public string Identifier {get; set;}
        public string TechName {get; set;}
        public bool? IsCognitive {get; set;}
        public bool IsFeatured {get; set;}
        public string Version {get; set;}
        public Guid RowGuid {get; set;}
        public bool BetaOnly {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<CogniGame> CogniGames {get; set;}
        [JsonIgnore]
        public List<ExerGame> ExerGames {get; set;}
        [JsonIgnore]
        public List<GameMovement> GameMovements {get; set;}
        [JsonIgnore]
        public List<GameMovementType> GameMovementTypes {get; set;}
        [JsonIgnore]
        public List<GameSettingsDescriptor> GameSettingsDescriptors {get; set;}
        [JsonIgnore]
        public List<GameStatisticsType> GameStatisticsTypes {get; set;}
        [JsonIgnore]
        public List<GamesTranslation> GamesTranslations {get; set;}
        [JsonIgnore]
        public List<GameVersion> GameVersions {get; set;}
        [JsonIgnore]
        public List<TenantGameVersion> TenantGameVersions {get; set;}

        public Game()
        {
            this.CogniGames = new List<CogniGame>();
            this.ExerGames = new List<ExerGame>();
            this.GameMovements = new List<GameMovement>();
            this.GameMovementTypes = new List<GameMovementType>();
            this.GameSettingsDescriptors = new List<GameSettingsDescriptor>();
            this.GameStatisticsTypes = new List<GameStatisticsType>();
            this.GamesTranslations = new List<GamesTranslation>();
            this.GameVersions = new List<GameVersion>();
            this.TenantGameVersions = new List<TenantGameVersion>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameSettingsDescriptor
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int GameID {get; set;}
        public int? SettingDescriptorID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}
        [JsonIgnore]
        public SettingDescriptor SettingDescriptor {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameSettingsDescriptorsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GamesSetting
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int ExerGameID {get; set;}
        public string Name {get; set;}
        public int? NumericValue {get; set;}
        public string TextValue {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public ExerGame ExerGame {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GamesSettingsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameStatisticsType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int GameID {get; set;}
        public int StatisticTypeID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}
        [JsonIgnore]
        public StatisticsType StatisticType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameStatisticsTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GamesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GamesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int GameID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}
        [JsonIgnore]
        public Language Language {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GamesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameVersion
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int GameID {get; set;}
        public string Version {get; set;}
        public string VersionName {get; set;}
        public string VersionIdentifier {get; set;}
        public DateTime ActiveDate {get; set;}
        public bool IsFeatured {get; set;}
        public bool BetaOnly {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<TenantGameVersion> TenantGameVersions {get; set;}

        public GameVersion()
        {
            this.TenantGameVersions = new List<TenantGameVersion>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GameVersionsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Gender
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<GendersTranslation> GendersTranslations {get; set;}
        [JsonIgnore]
        public List<Patient> Patients {get; set;}

        public Gender()
        {
            this.GendersTranslations = new List<GendersTranslation>();
            this.Patients = new List<Patient>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GendersTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GendersTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int GenderID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Gender Gender {get; set;}
        [JsonIgnore]
        public Language Language {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class GendersTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Joint
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<JointsAcceptedStatistic> JointsAcceptedStatistics {get; set;}
        [JsonIgnore]
        public List<JointsTranslation> JointsTranslations {get; set;}
        [JsonIgnore]
        public List<MovementsJoint> MovementsJoints {get; set;}
        [JsonIgnore]
        public List<PatientsJoint> PatientsJoints {get; set;}
        [JsonIgnore]
        public List<StatisticsValue> StatisticsValues {get; set;}

        public Joint()
        {
            this.JointsAcceptedStatistics = new List<JointsAcceptedStatistic>();
            this.JointsTranslations = new List<JointsTranslation>();
            this.MovementsJoints = new List<MovementsJoint>();
            this.PatientsJoints = new List<PatientsJoint>();
            this.StatisticsValues = new List<StatisticsValue>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class JointsAcceptedStatistic
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int JointID {get; set;}
        public int StatisticTypeID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Joint Joint {get; set;}
        [JsonIgnore]
        public StatisticsType StatisticType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class JointsAcceptedStatisticsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class JointsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class JointsTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int JointID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Joint Joint {get; set;}
        [JsonIgnore]
        public Language Language {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class JointsTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Language
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string IsoCode {get; set;}
        public string Name {get; set;}
        public string CountryFlag {get; set;}
        public bool BetaOnly {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<AuditEntryTypesTranslation> AuditEntryTypesTranslations {get; set;}
        [JsonIgnore]
        public List<DifficultiesTranslation> DifficultiesTranslations {get; set;}
        [JsonIgnore]
        public List<GamesTranslation> GamesTranslations {get; set;}
        [JsonIgnore]
        public List<GendersTranslation> GendersTranslations {get; set;}
        [JsonIgnore]
        public List<JointsTranslation> JointsTranslations {get; set;}
        [JsonIgnore]
        public List<LogEntryTypesTranslation> LogEntryTypesTranslations {get; set;}
        [JsonIgnore]
        public List<MovementsTranslation> MovementsTranslations {get; set;}
        [JsonIgnore]
        public List<MovementTypesTranslation> MovementTypesTranslations {get; set;}
        [JsonIgnore]
        public List<PermissionsTranslation> PermissionsTranslations {get; set;}
        [JsonIgnore]
        public List<QuestionDisplayTypesTranslation> QuestionDisplayTypesTranslations {get; set;}
        [JsonIgnore]
        public List<QuestionnairesTranslation> QuestionnairesTranslations {get; set;}
        [JsonIgnore]
        public List<QuestionsTranslation> QuestionsTranslations {get; set;}
        [JsonIgnore]
        public List<QuestionTypesTranslation> QuestionTypesTranslations {get; set;}
        [JsonIgnore]
        public List<RolesTranslation> RolesTranslations {get; set;}
        [JsonIgnore]
        public List<ScheduleItemTypesTranslation> ScheduleItemTypesTranslations {get; set;}
        [JsonIgnore]
        public List<SensorsTranslation> SensorsTranslations {get; set;}
        [JsonIgnore]
        public List<SettingDescriptorCategoriesTranslation> SettingDescriptorCategoriesTranslations {get; set;}
        [JsonIgnore]
        public List<SettingDescriptorsTranslation> SettingDescriptorsTranslations {get; set;}
        [JsonIgnore]
        public List<SettingValuesTranslation> SettingValuesTranslations {get; set;}
        [JsonIgnore]
        public List<SidesTranslation> SidesTranslations {get; set;}
        [JsonIgnore]
        public List<StatisticsAggregationTypesTranslation> StatisticsAggregationTypesTranslations {get; set;}
        [JsonIgnore]
        public List<StatisticsCategoriesTranslation> StatisticsCategoriesTranslations {get; set;}
        [JsonIgnore]
        public List<StatisticsTypesTranslation> StatisticsTypesTranslations {get; set;}
        [JsonIgnore]
        public List<StatisticsUnitsTranslation> StatisticsUnitsTranslations {get; set;}
        [JsonIgnore]
        public List<TutorialSourceTranslation> TutorialSourceTranslations {get; set;}
        [JsonIgnore]
        public List<TutorialsTranslation> TutorialsTranslations {get; set;}

        public Language()
        {
            this.AuditEntryTypesTranslations = new List<AuditEntryTypesTranslation>();
            this.DifficultiesTranslations = new List<DifficultiesTranslation>();
            this.GamesTranslations = new List<GamesTranslation>();
            this.GendersTranslations = new List<GendersTranslation>();
            this.JointsTranslations = new List<JointsTranslation>();
            this.LogEntryTypesTranslations = new List<LogEntryTypesTranslation>();
            this.MovementsTranslations = new List<MovementsTranslation>();
            this.MovementTypesTranslations = new List<MovementTypesTranslation>();
            this.PermissionsTranslations = new List<PermissionsTranslation>();
            this.QuestionDisplayTypesTranslations = new List<QuestionDisplayTypesTranslation>();
            this.QuestionnairesTranslations = new List<QuestionnairesTranslation>();
            this.QuestionsTranslations = new List<QuestionsTranslation>();
            this.QuestionTypesTranslations = new List<QuestionTypesTranslation>();
            this.RolesTranslations = new List<RolesTranslation>();
            this.ScheduleItemTypesTranslations = new List<ScheduleItemTypesTranslation>();
            this.SensorsTranslations = new List<SensorsTranslation>();
            this.SettingDescriptorCategoriesTranslations = new List<SettingDescriptorCategoriesTranslation>();
            this.SettingDescriptorsTranslations = new List<SettingDescriptorsTranslation>();
            this.SettingValuesTranslations = new List<SettingValuesTranslation>();
            this.SidesTranslations = new List<SidesTranslation>();
            this.StatisticsAggregationTypesTranslations = new List<StatisticsAggregationTypesTranslation>();
            this.StatisticsCategoriesTranslations = new List<StatisticsCategoriesTranslation>();
            this.StatisticsTypesTranslations = new List<StatisticsTypesTranslation>();
            this.StatisticsUnitsTranslations = new List<StatisticsUnitsTranslation>();
            this.TutorialSourceTranslations = new List<TutorialSourceTranslation>();
            this.TutorialsTranslations = new List<TutorialsTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class LanguagesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class LogEntry
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LogEntryTypeID {get; set;}
        public string Message {get; set;}
        public DateTime? Date {get; set;}
        public string Source {get; set;}
        public string AppVersion {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class LogEntriesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class LogEntryType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<LogEntryTypesTranslation> LogEntryTypesTranslations {get; set;}

        public LogEntryType()
        {
            this.LogEntryTypesTranslations = new List<LogEntryTypesTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class LogEntryTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class LogEntryTypesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int LogEntryTypeID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public LogEntryType LogEntryType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class LogEntryTypesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Movement
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int MovementTypeID {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string TechName {get; set;}
        public bool IsFeatured {get; set;}
        public bool BetaOnly {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public MovementType MovementType {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<ExerGame> ExerGames {get; set;}
        [JsonIgnore]
        public List<GameMovement> GameMovements {get; set;}
        [JsonIgnore]
        public List<MovementsAcceptedStatistic> MovementsAcceptedStatistics {get; set;}
        [JsonIgnore]
        public List<MovementsJoint> MovementsJoints {get; set;}
        [JsonIgnore]
        public List<MovementsSide> MovementsSides {get; set;}
        [JsonIgnore]
        public List<MovementsTranslation> MovementsTranslations {get; set;}
        [JsonIgnore]
        public List<RomMovement> RomMovements {get; set;}
        [JsonIgnore]
        public List<SensorMovement> SensorMovements {get; set;}

        public Movement()
        {
            this.ExerGames = new List<ExerGame>();
            this.GameMovements = new List<GameMovement>();
            this.MovementsAcceptedStatistics = new List<MovementsAcceptedStatistic>();
            this.MovementsJoints = new List<MovementsJoint>();
            this.MovementsSides = new List<MovementsSide>();
            this.MovementsTranslations = new List<MovementsTranslation>();
            this.RomMovements = new List<RomMovement>();
            this.SensorMovements = new List<SensorMovement>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsAcceptedStatistic
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int MovementID {get; set;}
        public int StatisticsTypeID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Movement Movement {get; set;}
        [JsonIgnore]
        public StatisticsType StatisticsType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsAcceptedStatisticsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsJoint
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int MovementID {get; set;}
        public int JointID {get; set;}
        public int SideID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Joint Joint {get; set;}
        [JsonIgnore]
        public Movement Movement {get; set;}
        [JsonIgnore]
        public Side Side {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsJointsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsSide
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int MovementID {get; set;}
        public int SideID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Movement Movement {get; set;}
        [JsonIgnore]
        public Side Side {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsSidesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int MovementID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public Movement Movement {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementsTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<GameMovementType> GameMovementTypes {get; set;}
        [JsonIgnore]
        public List<Movement> Movements {get; set;}
        [JsonIgnore]
        public List<MovementTypesTranslation> MovementTypesTranslations {get; set;}

        public MovementType()
        {
            this.GameMovementTypes = new List<GameMovementType>();
            this.Movements = new List<Movement>();
            this.MovementTypesTranslations = new List<MovementTypesTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementTypesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int MovementTypeID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public MovementType MovementType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class MovementTypesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientField
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int Position {get; set;}
        public bool IsVisible {get; set;}
        public bool IsRequired {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<PatientFieldValue> PatientFieldValues {get; set;}

        public PatientField()
        {
            this.PatientFieldValues = new List<PatientFieldValue>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientFieldsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientFieldValue
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int PatientFieldID {get; set;}
        public int PatientID {get; set;}
        public string Value {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public PatientField PatientField {get; set;}
        [JsonIgnore]
        public Patient Patient {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientFieldValuesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientImage
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public Byte[]? Image {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<Patient> Patients {get; set;}

        public PatientImage()
        {
            this.Patients = new List<Patient>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientImagesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Patient
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int GenderID {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string Description {get; set;}
        public int? InjuredSideID {get; set;}
        public int InteractionHandID {get; set;}
        public DateTime DateIntroducing {get; set;}
        public DateTime? DateRecovering {get; set;}
        public bool IsTemporary {get; set;}
        public string Diagnosis {get; set;}
        public string Password {get; set;}
        public bool IsDeleted {get; set;}
        public int? PatientImageID {get; set;}
        public int? CreatedByUserID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Gender Gender {get; set;}
        [JsonIgnore]
        public Side InjuredSide {get; set;}
        [JsonIgnore]
        public Side InteractionHand {get; set;}
        [JsonIgnore]
        public PatientImage PatientImage {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<AssignedPatient> AssignedPatients {get; set;}
        [JsonIgnore]
        public List<PatientFieldValue> PatientFieldValues {get; set;}
        [JsonIgnore]
        public List<PatientsJoint> PatientsJoints {get; set;}
        [JsonIgnore]
        public List<Schedule> Schedules {get; set;}
        [JsonIgnore]
        public List<Session> Sessions {get; set;}
        [JsonIgnore]
        public List<User> Users {get; set;}

        public Patient()
        {
            this.AssignedPatients = new List<AssignedPatient>();
            this.PatientFieldValues = new List<PatientFieldValue>();
            this.PatientsJoints = new List<PatientsJoint>();
            this.Schedules = new List<Schedule>();
            this.Sessions = new List<Session>();
            this.Users = new List<User>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientsJoint
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int PatientID {get; set;}
        public int JointID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Joint Joint {get; set;}
        [JsonIgnore]
        public Patient Patient {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientsJointsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PatientsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Permission
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<PermissionsTranslation> PermissionsTranslations {get; set;}
        [JsonIgnore]
        public List<RolePermission> RolePermissions {get; set;}

        public Permission()
        {
            this.PermissionsTranslations = new List<PermissionsTranslation>();
            this.RolePermissions = new List<RolePermission>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PermissionsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PermissionsTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int PermissionID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public Permission Permission {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class PermissionsTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionAnswer
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int QuestionID {get; set;}
        public int SessionID {get; set;}
        public int ScheduleItemID {get; set;}
        public double? Value {get; set;}
        public string Text {get; set;}
        public DateTime Date {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Question Question {get; set;}
        [JsonIgnore]
        public ScheduleItem ScheduleItem {get; set;}
        [JsonIgnore]
        public Session Session {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionAnswersTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionDisplayType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int QuestionTypeID {get; set;}
        public string Name {get; set;}
        public string TechName {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public QuestionType QuestionType {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<QuestionDisplayTypesTranslation> QuestionDisplayTypesTranslations {get; set;}
        [JsonIgnore]
        public List<Question> Questions {get; set;}

        public QuestionDisplayType()
        {
            this.QuestionDisplayTypesTranslations = new List<QuestionDisplayTypesTranslation>();
            this.Questions = new List<Question>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionDisplayTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionDisplayTypesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int QuestionDisplayTypeID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public QuestionDisplayType QuestionDisplayType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionDisplayTypesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionnaireQuestion
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int? RestrictedTenantID {get; set;}
        public int QuestionnaireID {get; set;}
        public int QuestionID {get; set;}
        public int Position {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Question Question {get; set;}
        [JsonIgnore]
        public Questionnaire Questionnaire {get; set;}
        [JsonIgnore]
        public Tenant RestrictedTenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionnaireQuestionsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Questionnaire
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int? RestrictedTenantID {get; set;}
        public string Name {get; set;}
        public bool IsSystem {get; set;}
        public bool IsEnabled {get; set;}
        public bool IsByDefaultEnabled {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Tenant RestrictedTenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<QuestionnaireQuestion> QuestionnaireQuestions {get; set;}
        [JsonIgnore]
        public List<QuestionnairesTranslation> QuestionnairesTranslations {get; set;}
        [JsonIgnore]
        public List<ScheduleItem> ScheduleItems {get; set;}
        [JsonIgnore]
        public List<TenantQuestionnaire> TenantQuestionnaires {get; set;}

        public Questionnaire()
        {
            this.QuestionnaireQuestions = new List<QuestionnaireQuestion>();
            this.QuestionnairesTranslations = new List<QuestionnairesTranslation>();
            this.ScheduleItems = new List<ScheduleItem>();
            this.TenantQuestionnaires = new List<TenantQuestionnaire>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionnairesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionnairesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int QuestionnaireID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public Questionnaire Questionnaire {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionnairesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Question
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int? RestrictedTenantID {get; set;}
        public int QuestionDisplayTypeID {get; set;}
        public string Title {get; set;}
        public string Text {get; set;}
        public bool IsSystem {get; set;}
        public bool IsUserSelectable {get; set;}
        public bool IsEnabled {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public QuestionDisplayType QuestionDisplayType {get; set;}
        [JsonIgnore]
        public Tenant RestrictedTenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<QuestionAnswer> QuestionAnswers {get; set;}
        [JsonIgnore]
        public List<QuestionnaireQuestion> QuestionnaireQuestions {get; set;}
        [JsonIgnore]
        public List<QuestionsTranslation> QuestionsTranslations {get; set;}

        public Question()
        {
            this.QuestionAnswers = new List<QuestionAnswer>();
            this.QuestionnaireQuestions = new List<QuestionnaireQuestion>();
            this.QuestionsTranslations = new List<QuestionsTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionsTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int QuestionID {get; set;}
        public bool Synthetic {get; set;}
        public string Title {get; set;}
        public string Text {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public Question Question {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionsTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<QuestionDisplayType> QuestionDisplayTypes {get; set;}
        [JsonIgnore]
        public List<QuestionTypesTranslation> QuestionTypesTranslations {get; set;}

        public QuestionType()
        {
            this.QuestionDisplayTypes = new List<QuestionDisplayType>();
            this.QuestionTypesTranslations = new List<QuestionTypesTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionTypesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int QuestionTypeID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public QuestionType QuestionType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class QuestionTypesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RangeOfMotion
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<RomMovement> RomMovements {get; set;}
        [JsonIgnore]
        public List<ScheduleItem> ScheduleItems {get; set;}

        public RangeOfMotion()
        {
            this.RomMovements = new List<RomMovement>();
            this.ScheduleItems = new List<ScheduleItem>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RangeOfMotionTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RolePermission
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int RoleID {get; set;}
        public int PermissionID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Permission Permission {get; set;}
        [JsonIgnore]
        public Role Role {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RolePermissionsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Role
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<RolePermission> RolePermissions {get; set;}
        [JsonIgnore]
        public List<RoleSetting> RoleSettings {get; set;}
        [JsonIgnore]
        public List<RolesTranslation> RolesTranslations {get; set;}
        [JsonIgnore]
        public List<UserRole> UserRoles {get; set;}

        public Role()
        {
            this.RolePermissions = new List<RolePermission>();
            this.RoleSettings = new List<RoleSetting>();
            this.RolesTranslations = new List<RolesTranslation>();
            this.UserRoles = new List<UserRole>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RoleSetting
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int RoleID {get; set;}
        public int TokenLifetimeSeconds {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Role Role {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RoleSettingsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RolesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RolesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int RoleID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public Role Role {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RolesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RomMovement
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int RangeOfMotionID {get; set;}
        public int MovementID {get; set;}
        public int SideID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Movement Movement {get; set;}
        [JsonIgnore]
        public RangeOfMotion RangeOfMotion {get; set;}
        [JsonIgnore]
        public Side Side {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<StatisticsValue> StatisticsValues {get; set;}

        public RomMovement()
        {
            this.StatisticsValues = new List<StatisticsValue>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class RomMovementsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SavedSchedule
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int ScheduleID {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public DateTime AddedDate {get; set;}
        public int DifficultyID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Difficulty Difficulty {get; set;}
        [JsonIgnore]
        public Schedule Schedule {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SavedSchedulesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ScheduleItem
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int ScheduleID {get; set;}
        public int Order {get; set;}
        public int ScheduleItemTypeID {get; set;}
        public int? ExerGameID {get; set;}
        public int? RangeOfMotionID {get; set;}
        public int? CognitiveGameID {get; set;}
        public int? QuestionnaireID {get; set;}
        public int Duration {get; set;}
        public int PauseAfter {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public CogniGame CognitiveGame {get; set;}
        [JsonIgnore]
        public ExerGame ExerGame {get; set;}
        [JsonIgnore]
        public Questionnaire Questionnaire {get; set;}
        [JsonIgnore]
        public RangeOfMotion RangeOfMotion {get; set;}
        [JsonIgnore]
        public Schedule Schedule {get; set;}
        [JsonIgnore]
        public ScheduleItemType ScheduleItemType {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<QuestionAnswer> QuestionAnswers {get; set;}
        [JsonIgnore]
        public List<SessionImage> SessionImages {get; set;}
        [JsonIgnore]
        public List<StatisticsValue> StatisticsValues {get; set;}

        public ScheduleItem()
        {
            this.QuestionAnswers = new List<QuestionAnswer>();
            this.SessionImages = new List<SessionImage>();
            this.StatisticsValues = new List<StatisticsValue>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ScheduleItemsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ScheduleItemType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<ScheduleItem> ScheduleItems {get; set;}
        [JsonIgnore]
        public List<ScheduleItemTypesTranslation> ScheduleItemTypesTranslations {get; set;}

        public ScheduleItemType()
        {
            this.ScheduleItems = new List<ScheduleItem>();
            this.ScheduleItemTypesTranslations = new List<ScheduleItemTypesTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ScheduleItemTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ScheduleItemTypesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int ScheduleItemTypeID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public ScheduleItemType ScheduleItemType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class ScheduleItemTypesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Schedule
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int Pause {get; set;}
        public int? PatientID {get; set;}
        public bool HasCalibration {get; set;}
        public bool HasTutorial {get; set;}
        public bool HasGameTutorial {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Patient Patient {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<SavedSchedule> SavedSchedules {get; set;}
        [JsonIgnore]
        public List<ScheduleItem> ScheduleItems {get; set;}
        [JsonIgnore]
        public List<Session> Sessions {get; set;}

        public Schedule()
        {
            this.SavedSchedules = new List<SavedSchedule>();
            this.ScheduleItems = new List<ScheduleItem>();
            this.Sessions = new List<Session>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SchedulesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SensorMovement
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int SensorID {get; set;}
        public int MovementID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Movement Movement {get; set;}
        [JsonIgnore]
        public Sensor Sensor {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SensorMovementsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Sensor
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<SensorMovement> SensorMovements {get; set;}
        [JsonIgnore]
        public List<SensorsTranslation> SensorsTranslations {get; set;}
        [JsonIgnore]
        public List<Session> Sessions {get; set;}

        public Sensor()
        {
            this.SensorMovements = new List<SensorMovement>();
            this.SensorsTranslations = new List<SensorsTranslation>();
            this.Sessions = new List<Session>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SensorsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SensorsTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int SensorID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public Sensor Sensor {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SensorsTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SessionImage
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int SessionID {get; set;}
        public int ScheduleItemID {get; set;}
        public Byte[] CaptureImage {get; set;}
        public DateTime CaptureDate {get; set;}
        public string ExternalUri {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public ScheduleItem ScheduleItem {get; set;}
        [JsonIgnore]
        public Session Session {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SessionImagesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Session
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int ScheduleID {get; set;}
        public int PatientID {get; set;}
        public int? SensorID {get; set;}
        public bool PlayedAtHome {get; set;}
        public int? LoggedInUserId {get; set;}
        public DateTime Date {get; set;}
        public bool IsDeleted {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Patient Patient {get; set;}
        [JsonIgnore]
        public Schedule Schedule {get; set;}
        [JsonIgnore]
        public Sensor Sensor {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<QuestionAnswer> QuestionAnswers {get; set;}
        [JsonIgnore]
        public List<SessionImage> SessionImages {get; set;}
        [JsonIgnore]
        public List<StatisticsValue> StatisticsValues {get; set;}

        public Session()
        {
            this.QuestionAnswers = new List<QuestionAnswer>();
            this.SessionImages = new List<SessionImage>();
            this.StatisticsValues = new List<StatisticsValue>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SessionsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingDescriptorCategory
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<SettingDescriptorCategoriesTranslation> SettingDescriptorCategoriesTranslations {get; set;}
        [JsonIgnore]
        public List<SettingDescriptor> SettingDescriptors {get; set;}

        public SettingDescriptorCategory()
        {
            this.SettingDescriptorCategoriesTranslations = new List<SettingDescriptorCategoriesTranslation>();
            this.SettingDescriptors = new List<SettingDescriptor>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingDescriptorCategoriesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingDescriptorCategoriesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int SettingDescriptorCategoryID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public SettingDescriptorCategory SettingDescriptorCategory {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingDescriptorCategoriesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingDescriptor
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int? SettingDescriptorCategoryID {get; set;}
        public int? DefaultValueID {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string TechnicalName {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public SettingDescriptorCategory SettingDescriptorCategory {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<GameSettingsDescriptor> GameSettingsDescriptors {get; set;}
        [JsonIgnore]
        public List<SettingDescriptorsTranslation> SettingDescriptorsTranslations {get; set;}
        [JsonIgnore]
        public List<SettingValue> SettingValues {get; set;}

        public SettingDescriptor()
        {
            this.GameSettingsDescriptors = new List<GameSettingsDescriptor>();
            this.SettingDescriptorsTranslations = new List<SettingDescriptorsTranslation>();
            this.SettingValues = new List<SettingValue>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingDescriptorsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingDescriptorsTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int SettingDescriptorID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public SettingDescriptor SettingDescriptor {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingDescriptorsTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingValue
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int SettingDescriptorID {get; set;}
        public string TextValue {get; set;}
        public int IntValue {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public SettingDescriptor SettingDescriptor {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<CogniGameSettingsValue> CogniGameSettingsValues {get; set;}
        [JsonIgnore]
        public List<ExerGameSettingsValue> ExerGameSettingsValues {get; set;}
        [JsonIgnore]
        public List<SettingValuesTranslation> SettingValuesTranslations {get; set;}

        public SettingValue()
        {
            this.CogniGameSettingsValues = new List<CogniGameSettingsValue>();
            this.ExerGameSettingsValues = new List<ExerGameSettingsValue>();
            this.SettingValuesTranslations = new List<SettingValuesTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingValuesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingValuesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int SettingValueID {get; set;}
        public bool Synthetic {get; set;}
        public string TextValue {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public SettingValue SettingValue {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SettingValuesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Side
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<ExerGame> ExerGames {get; set;}
        [JsonIgnore]
        public List<MovementsJoint> MovementsJoints {get; set;}
        [JsonIgnore]
        public List<MovementsSide> MovementsSides {get; set;}
        [JsonIgnore]
        public List<Patient> PatientsInjuredSide {get; set;}
        [JsonIgnore]
        public List<Patient> PatientsInteractionHand {get; set;}
        [JsonIgnore]
        public List<RomMovement> RomMovements {get; set;}
        [JsonIgnore]
        public List<SidesTranslation> SidesTranslations {get; set;}

        public Side()
        {
            this.ExerGames = new List<ExerGame>();
            this.MovementsJoints = new List<MovementsJoint>();
            this.MovementsSides = new List<MovementsSide>();
            this.PatientsInjuredSide = new List<Patient>();
            this.PatientsInteractionHand = new List<Patient>();
            this.RomMovements = new List<RomMovement>();
            this.SidesTranslations = new List<SidesTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SidesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SidesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int SideID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public Side Side {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SidesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsAggregationType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string TechName {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<StatisticsAggregationTypesTranslation> StatisticsAggregationTypesTranslations {get; set;}
        [JsonIgnore]
        public List<StatisticsType> StatisticsTypes {get; set;}

        public StatisticsAggregationType()
        {
            this.StatisticsAggregationTypesTranslations = new List<StatisticsAggregationTypesTranslation>();
            this.StatisticsTypes = new List<StatisticsType>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsAggregationTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsAggregationTypesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int StatisticsAggregationTypeID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public StatisticsAggregationType StatisticsAggregationType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsAggregationTypesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsCategory
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string TechName {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<StatisticsCategoriesTranslation> StatisticsCategoriesTranslations {get; set;}
        [JsonIgnore]
        public List<StatisticsType> StatisticsTypes {get; set;}

        public StatisticsCategory()
        {
            this.StatisticsCategoriesTranslations = new List<StatisticsCategoriesTranslation>();
            this.StatisticsTypes = new List<StatisticsType>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsCategoriesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsCategoriesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int StatisticsCategoryID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public StatisticsCategory StatisticsCategory {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsCategoriesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int? StatisticsCategoryID {get; set;}
        public int? StatisticsAggregationTypeID {get; set;}
        public int? StatisticsUnitID {get; set;}
        public string TechName {get; set;}
        public string Name {get; set;}
        public string Unit {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public StatisticsAggregationType StatisticsAggregationType {get; set;}
        [JsonIgnore]
        public StatisticsCategory StatisticsCategory {get; set;}
        [JsonIgnore]
        public StatisticsUnit StatisticsUnit {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<GameStatisticsType> GameStatisticsTypes {get; set;}
        [JsonIgnore]
        public List<JointsAcceptedStatistic> JointsAcceptedStatistics {get; set;}
        [JsonIgnore]
        public List<MovementsAcceptedStatistic> MovementsAcceptedStatistics {get; set;}
        [JsonIgnore]
        public List<StatisticsTypesTranslation> StatisticsTypesTranslations {get; set;}
        [JsonIgnore]
        public List<StatisticsValue> StatisticsValues {get; set;}

        public StatisticsType()
        {
            this.GameStatisticsTypes = new List<GameStatisticsType>();
            this.JointsAcceptedStatistics = new List<JointsAcceptedStatistic>();
            this.MovementsAcceptedStatistics = new List<MovementsAcceptedStatistic>();
            this.StatisticsTypesTranslations = new List<StatisticsTypesTranslation>();
            this.StatisticsValues = new List<StatisticsValue>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsTypesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsTypesTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int StatisticsTypeID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public string Unit {get; set;}
        public string Description {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public StatisticsType StatisticsType {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsTypesTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsUnit
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string TechName {get; set;}
        public string Name {get; set;}
        public string DataUnit {get; set;}
        public string DisplayUnitShort {get; set;}
        public string DisplayUnitLongSingular {get; set;}
        public string DisplayUnitLongPlural {get; set;}
        public float DisplayUnitConversionFactor {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<StatisticsType> StatisticsTypes {get; set;}
        [JsonIgnore]
        public List<StatisticsUnitsTranslation> StatisticsUnitsTranslations {get; set;}

        public StatisticsUnit()
        {
            this.StatisticsTypes = new List<StatisticsType>();
            this.StatisticsUnitsTranslations = new List<StatisticsUnitsTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsUnitsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsUnitsTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int StatisticsUnitID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public string DataUnit {get; set;}
        public string DisplayUnitShort {get; set;}
        public string DisplayUnitLongSingular {get; set;}
        public string DisplayUnitLongPlural {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public StatisticsUnit StatisticsUnit {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsUnitsTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsValue
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int SessionID {get; set;}
        public int ScheduleItemID {get; set;}
        public int StatisticTypeID {get; set;}
        public DateTime Timestamp {get; set;}
        public double Value {get; set;}
        public int? JointID {get; set;}
        public int? RomMovementID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Joint Joint {get; set;}
        [JsonIgnore]
        public RomMovement RomMovement {get; set;}
        [JsonIgnore]
        public ScheduleItem ScheduleItem {get; set;}
        [JsonIgnore]
        public Session Session {get; set;}
        [JsonIgnore]
        public StatisticsType StatisticType {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class StatisticsValuesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SyncChange
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int SyncStateID {get; set;}
        public int SyncDirectionID {get; set;}
        public string ChangeSet {get; set;}
        public string Error {get; set;}
        public string UserName {get; set;}
        public int? TenantId {get; set;}
        public DateTime? SyncAnchor {get; set;}
        public string Info {get; set;}
        public DateTime? Date {get; set;}

        // Foreign keys
        [JsonIgnore]
        public SyncDirection SyncDirection {get; set;}
        [JsonIgnore]
        public SyncState SyncState {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SyncDirection
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<SyncChange> SyncChanges {get; set;}

        public SyncDirection()
        {
            this.SyncChanges = new List<SyncChange>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class SyncState
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<SyncChange> SyncChanges {get; set;}

        public SyncState()
        {
            this.SyncChanges = new List<SyncChange>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Sysdiagram
    {
        // Key Properties
        public int DiagramId {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public int PrincipalId {get; set;}
        public int? Version {get; set;}
        public Byte[]? Definition {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TenantGameVersion
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int GameID {get; set;}
        public int GameVersionID {get; set;}
        public bool Enabled {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Game Game {get; set;}
        [JsonIgnore]
        public GameVersion GameVersion {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TenantQuestionnaire
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int QuestionnaireID {get; set;}
        public bool Enabled {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Questionnaire Questionnaire {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Tenant
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int? TenantTypeID {get; set;}
        public int? UpdateTypeID {get; set;}
        public string Name {get; set;}
        public DateTime? LicenceExpireDate {get; set;}
        public bool IsActive {get; set;}
        public bool IsDemo {get; set;}
        public bool TakeSchedulePictures {get; set;}
        public string CreatedBy {get; set;}
        public DateTime CreationDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public TenantType TenantType {get; set;}
        [JsonIgnore]
        public UpdateType UpdateType {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<AssignedPatient> AssignedPatients {get; set;}
        [JsonIgnore]
        public List<AssignedUser> AssignedUsers {get; set;}
        [JsonIgnore]
        public List<AuditEntry> AuditEntries {get; set;}
        [JsonIgnore]
        public List<CogniGame> CogniGames {get; set;}
        [JsonIgnore]
        public List<CogniGameSettingsValue> CogniGameSettingsValues {get; set;}
        [JsonIgnore]
        public List<ExerGame> ExerGames {get; set;}
        [JsonIgnore]
        public List<ExerGameSettingsValue> ExerGameSettingsValues {get; set;}
        [JsonIgnore]
        public List<GamesSetting> GamesSettings {get; set;}
        [JsonIgnore]
        public List<PatientField> PatientFields {get; set;}
        [JsonIgnore]
        public List<PatientFieldValue> PatientFieldValues {get; set;}
        [JsonIgnore]
        public List<Patient> Patients {get; set;}
        [JsonIgnore]
        public List<PatientsJoint> PatientsJoints {get; set;}
        [JsonIgnore]
        public List<QuestionAnswer> QuestionAnswers {get; set;}
        [JsonIgnore]
        public List<QuestionnaireQuestion> QuestionnaireQuestions {get; set;}
        [JsonIgnore]
        public List<Questionnaire> Questionnaires {get; set;}
        [JsonIgnore]
        public List<Question> Questions {get; set;}
        [JsonIgnore]
        public List<RangeOfMotion> RangeOfMotions {get; set;}
        [JsonIgnore]
        public List<RoleSetting> RoleSettings {get; set;}
        [JsonIgnore]
        public List<RomMovement> RomMovements {get; set;}
        [JsonIgnore]
        public List<SavedSchedule> SavedSchedules {get; set;}
        [JsonIgnore]
        public List<ScheduleItem> ScheduleItems {get; set;}
        [JsonIgnore]
        public List<Schedule> Schedules {get; set;}
        [JsonIgnore]
        public List<Session> Sessions {get; set;}
        [JsonIgnore]
        public List<StatisticsValue> StatisticsValues {get; set;}
        [JsonIgnore]
        public List<TenantGameVersion> TenantGameVersions {get; set;}
        [JsonIgnore]
        public List<TenantQuestionnaire> TenantQuestionnaires {get; set;}
        [JsonIgnore]
        public List<UserRole> UserRoles {get; set;}
        [JsonIgnore]
        public List<User> Users {get; set;}

        public Tenant()
        {
            this.AssignedPatients = new List<AssignedPatient>();
            this.AssignedUsers = new List<AssignedUser>();
            this.AuditEntries = new List<AuditEntry>();
            this.CogniGames = new List<CogniGame>();
            this.CogniGameSettingsValues = new List<CogniGameSettingsValue>();
            this.ExerGames = new List<ExerGame>();
            this.ExerGameSettingsValues = new List<ExerGameSettingsValue>();
            this.GamesSettings = new List<GamesSetting>();
            this.PatientFields = new List<PatientField>();
            this.PatientFieldValues = new List<PatientFieldValue>();
            this.Patients = new List<Patient>();
            this.PatientsJoints = new List<PatientsJoint>();
            this.QuestionAnswers = new List<QuestionAnswer>();
            this.QuestionnaireQuestions = new List<QuestionnaireQuestion>();
            this.Questionnaires = new List<Questionnaire>();
            this.Questions = new List<Question>();
            this.RangeOfMotions = new List<RangeOfMotion>();
            this.RoleSettings = new List<RoleSetting>();
            this.RomMovements = new List<RomMovement>();
            this.SavedSchedules = new List<SavedSchedule>();
            this.ScheduleItems = new List<ScheduleItem>();
            this.Schedules = new List<Schedule>();
            this.Sessions = new List<Session>();
            this.StatisticsValues = new List<StatisticsValue>();
            this.TenantGameVersions = new List<TenantGameVersion>();
            this.TenantQuestionnaires = new List<TenantQuestionnaire>();
            this.UserRoles = new List<UserRole>();
            this.Users = new List<User>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TenantType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<Tenant> Tenants {get; set;}

        public TenantType()
        {
            this.Tenants = new List<Tenant>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class Tutorial
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string Description {get; set;}
        public int TutorialSourceID {get; set;}
        public int Order {get; set;}
        public bool ForPatient {get; set;}
        public string SourceUri {get; set;}
        public Byte[]? Thumb {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public TutorialSource TutorialSource {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<TutorialsTranslation> TutorialsTranslations {get; set;}

        public Tutorial()
        {
            this.TutorialsTranslations = new List<TutorialsTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TutorialSource
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<Tutorial> Tutorials {get; set;}
        [JsonIgnore]
        public List<TutorialSourceTranslation> TutorialSourceTranslations {get; set;}

        public TutorialSource()
        {
            this.Tutorials = new List<Tutorial>();
            this.TutorialSourceTranslations = new List<TutorialSourceTranslation>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TutorialSourceTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TutorialSourceTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int TutorialSourceID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public TutorialSource TutorialSource {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TutorialSourceTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TutorialsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TutorialsTranslation
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int LanguageID {get; set;}
        public int TutorialID {get; set;}
        public bool Synthetic {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string SourceUri {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Language Language {get; set;}
        [JsonIgnore]
        public Tutorial Tutorial {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class TutorialsTranslationsTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class UpdateType
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public string Name {get; set;}
        public string TechName {get; set;}
        public string Description {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<Tenant> Tenants {get; set;}

        public UpdateType()
        {
            this.Tenants = new List<Tenant>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class UserRole
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public int UserID {get; set;}
        public int RoleID {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Role Role {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}
        [JsonIgnore]
        public User User {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class UserRolesTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class User
    {
        // Key Properties
        public int ID {get; set;}

        // Scalar Properties
        public int TenantID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string EMail {get; set;}
        public bool IsEmailConfirmed {get; set;}
        public int? PatientID {get; set;}
        public int? CreatedByUserID {get; set;}
        public DateTime AddedDate {get; set;}
        public string UserName {get; set;}
        public bool IsDeleted {get; set;}
        public Guid RowGuid {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime? LastEditDate {get; set;}

        // Foreign keys
        [JsonIgnore]
        public Patient Patient {get; set;}
        [JsonIgnore]
        public Tenant Tenant {get; set;}

        // Reverse navigation
        [JsonIgnore]
        public List<AssignedPatient> AssignedPatients {get; set;}
        [JsonIgnore]
        public List<AssignedUser> AssignedUsersAssigned {get; set;}
        [JsonIgnore]
        public List<AssignedUser> AssignedUsersTargetUser {get; set;}
        [JsonIgnore]
        public List<UserRole> UserRoles {get; set;}

        public User()
        {
            this.AssignedPatients = new List<AssignedPatient>();
            this.AssignedUsersAssigned = new List<AssignedUser>();
            this.AssignedUsersTargetUser = new List<AssignedUser>();
            this.UserRoles = new List<UserRole>();
        }
    }

    [GeneratedCode("Geco Code Generator", "1.0.0.0")]
    public partial class UsersTombstone
    {
        // Key Properties
        public Guid RowGuid {get; set;}

        // Scalar Properties
        public DateTime DeletionDate {get; set;}

    }

}