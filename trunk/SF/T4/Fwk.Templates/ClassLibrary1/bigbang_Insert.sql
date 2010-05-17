create procedure Campaings_i
as
    insert into Campaings
    (
    )
    values
    (
    )
create procedure ImportStatus_i
as
    insert into ImportStatus
    (
    )
    values
    (
    )
create procedure ParamCampaings_i
as
    insert into ParamCampaings
    (
    )
    values
    (
    )
create procedure RecordActionResult_i
as
    insert into RecordActionResult
    (
    )
    values
    (
    )
create procedure RecordAttributeValues_i
as
    insert into RecordAttributeValues
    (
    )
    values
    (
    )
create procedure Records_i
as
    insert into Records
    (
    )
    values
    (
    )
create procedure RecordsData_i
as
    insert into RecordsData
    (
    )
    values
    (
    )
create procedure RecordSetAttributes_i
as
    insert into RecordSetAttributes
    (
    )
    values
    (
    )
create procedure RecordSetByZoneGoal_i
as
    insert into RecordSetByZoneGoal
    (
    )
    values
    (
    )
create procedure RecordSets_i
as
    insert into RecordSets
    (
    )
    values
    (
    )
create procedure RecordsWorkLog_i
as
    insert into RecordsWorkLog
    (
    )
    values
    (
    )
create procedure UserRecordSetAssignementLog_NoUsar_i
as
    insert into UserRecordSetAssignementLog_NoUsar
    (
    )
    values
    (
    )
create procedure UserRecordSetAssignment_i
as
    insert into UserRecordSetAssignment
    (
    )
    values
    (
    )
create procedure aspnet_Applications_i
	@ApplicationName nvarchar,
	@LoweredApplicationName nvarchar,
	@ApplicationId uniqueidentifier,
	@Description nvarchar
as
    insert into aspnet_Applications
    (
		ApplicationName,
		LoweredApplicationName,
		ApplicationId,
		Description
    )
    values
    (
		@ApplicationName,
		@LoweredApplicationName,
		@ApplicationId,
		@Description
    )
create procedure aspnet_Membership_i
	@ApplicationId uniqueidentifier,
	@UserId uniqueidentifier,
	@Password nvarchar,
	@PasswordFormat int,
	@PasswordSalt nvarchar,
	@MobilePIN nvarchar,
	@Email nvarchar,
	@LoweredEmail nvarchar,
	@PasswordQuestion nvarchar,
	@PasswordAnswer nvarchar,
	@IsApproved bit,
	@IsLockedOut bit,
	@CreateDate datetime,
	@LastLoginDate datetime,
	@LastPasswordChangedDate datetime,
	@LastLockoutDate datetime,
	@FailedPasswordAttemptCount int,
	@FailedPasswordAttemptWindowStart datetime,
	@FailedPasswordAnswerAttemptCount int,
	@FailedPasswordAnswerAttemptWindowStart datetime,
	@Comment ntext
as
    insert into aspnet_Membership
    (
		ApplicationId,
		UserId,
		Password,
		PasswordFormat,
		PasswordSalt,
		MobilePIN,
		Email,
		LoweredEmail,
		PasswordQuestion,
		PasswordAnswer,
		IsApproved,
		IsLockedOut,
		CreateDate,
		LastLoginDate,
		LastPasswordChangedDate,
		LastLockoutDate,
		FailedPasswordAttemptCount,
		FailedPasswordAttemptWindowStart,
		FailedPasswordAnswerAttemptCount,
		FailedPasswordAnswerAttemptWindowStart,
		Comment
    )
    values
    (
		@ApplicationId,
		@UserId,
		@Password,
		@PasswordFormat,
		@PasswordSalt,
		@MobilePIN,
		@Email,
		@LoweredEmail,
		@PasswordQuestion,
		@PasswordAnswer,
		@IsApproved,
		@IsLockedOut,
		@CreateDate,
		@LastLoginDate,
		@LastPasswordChangedDate,
		@LastLockoutDate,
		@FailedPasswordAttemptCount,
		@FailedPasswordAttemptWindowStart,
		@FailedPasswordAnswerAttemptCount,
		@FailedPasswordAnswerAttemptWindowStart,
		@Comment
    )
create procedure aspnet_Paths_i
	@ApplicationId uniqueidentifier,
	@PathId uniqueidentifier,
	@Path nvarchar,
	@LoweredPath nvarchar
as
    insert into aspnet_Paths
    (
		ApplicationId,
		PathId,
		Path,
		LoweredPath
    )
    values
    (
		@ApplicationId,
		@PathId,
		@Path,
		@LoweredPath
    )
create procedure aspnet_PersonalizationAllUsers_i
	@PathId uniqueidentifier,
	@PageSettings image,
	@LastUpdatedDate datetime
as
    insert into aspnet_PersonalizationAllUsers
    (
		PathId,
		PageSettings,
		LastUpdatedDate
    )
    values
    (
		@PathId,
		@PageSettings,
		@LastUpdatedDate
    )
create procedure aspnet_PersonalizationPerUser_i
	@Id uniqueidentifier,
	@PathId uniqueidentifier,
	@UserId uniqueidentifier,
	@PageSettings image,
	@LastUpdatedDate datetime
as
    insert into aspnet_PersonalizationPerUser
    (
		Id,
		PathId,
		UserId,
		PageSettings,
		LastUpdatedDate
    )
    values
    (
		@Id,
		@PathId,
		@UserId,
		@PageSettings,
		@LastUpdatedDate
    )
create procedure aspnet_Profile_i
	@UserId uniqueidentifier,
	@PropertyNames ntext,
	@PropertyValuesString ntext,
	@PropertyValuesBinary image,
	@LastUpdatedDate datetime
as
    insert into aspnet_Profile
    (
		UserId,
		PropertyNames,
		PropertyValuesString,
		PropertyValuesBinary,
		LastUpdatedDate
    )
    values
    (
		@UserId,
		@PropertyNames,
		@PropertyValuesString,
		@PropertyValuesBinary,
		@LastUpdatedDate
    )
create procedure aspnet_Roles_i
	@ApplicationId uniqueidentifier,
	@RoleId uniqueidentifier,
	@RoleName nvarchar,
	@LoweredRoleName nvarchar,
	@Description nvarchar,
	@CategoryId int
as
    insert into aspnet_Roles
    (
		ApplicationId,
		RoleId,
		RoleName,
		LoweredRoleName,
		Description,
		CategoryId
    )
    values
    (
		@ApplicationId,
		@RoleId,
		@RoleName,
		@LoweredRoleName,
		@Description,
		@CategoryId
    )
create procedure aspnet_Rules_i
	@name nchar,
	@expression nvarchar,
	@ApplicationId uniqueidentifier
as
    insert into aspnet_Rules
    (
		name,
		expression,
		ApplicationId
    )
    values
    (
		@name,
		@expression,
		@ApplicationId
    )
create procedure aspnet_RulesCategory_i
	@CategoryId int,
	@ParentCategoryId int,
	@Name nvarchar,
	@ApplicationId uniqueidentifier
as
    insert into aspnet_RulesCategory
    (
		CategoryId,
		ParentCategoryId,
		Name,
		ApplicationId
    )
    values
    (
		@CategoryId,
		@ParentCategoryId,
		@Name,
		@ApplicationId
    )
create procedure aspnet_RulesInCategory_i
	@CategoryId int,
	@RuleName nchar,
	@ApplicationId uniqueidentifier
as
    insert into aspnet_RulesInCategory
    (
		CategoryId,
		RuleName,
		ApplicationId
    )
    values
    (
		@CategoryId,
		@RuleName,
		@ApplicationId
    )
create procedure aspnet_SchemaVersions_i
	@Feature nvarchar,
	@CompatibleSchemaVersion nvarchar,
	@IsCurrentVersion bit
as
    insert into aspnet_SchemaVersions
    (
		Feature,
		CompatibleSchemaVersion,
		IsCurrentVersion
    )
    values
    (
		@Feature,
		@CompatibleSchemaVersion,
		@IsCurrentVersion
    )
create procedure aspnet_Users_i
	@ApplicationId uniqueidentifier,
	@UserId uniqueidentifier,
	@IntUserId int,
	@UserName nvarchar,
	@LoweredUserName nvarchar,
	@MobileAlias nvarchar,
	@IsAnonymous bit,
	@LastActivityDate datetime
as
    insert into aspnet_Users
    (
		ApplicationId,
		UserId,
		IntUserId,
		UserName,
		LoweredUserName,
		MobileAlias,
		IsAnonymous,
		LastActivityDate
    )
    values
    (
		@ApplicationId,
		@UserId,
		@IntUserId,
		@UserName,
		@LoweredUserName,
		@MobileAlias,
		@IsAnonymous,
		@LastActivityDate
    )
create procedure aspnet_UsersInRoles_i
	@UserId uniqueidentifier,
	@RoleId uniqueidentifier
as
    insert into aspnet_UsersInRoles
    (
		UserId,
		RoleId
    )
    values
    (
		@UserId,
		@RoleId
    )
create procedure aspnet_WebEvent_Events_i
	@EventId char,
	@EventTimeUtc datetime,
	@EventTime datetime,
	@EventType nvarchar,
	@EventSequence decimal,
	@EventOccurrence decimal,
	@EventCode int,
	@EventDetailCode int,
	@Message nvarchar,
	@ApplicationPath nvarchar,
	@ApplicationVirtualPath nvarchar,
	@MachineName nvarchar,
	@RequestUrl nvarchar,
	@ExceptionType nvarchar,
	@Details ntext
as
    insert into aspnet_WebEvent_Events
    (
		EventId,
		EventTimeUtc,
		EventTime,
		EventType,
		EventSequence,
		EventOccurrence,
		EventCode,
		EventDetailCode,
		Message,
		ApplicationPath,
		ApplicationVirtualPath,
		MachineName,
		RequestUrl,
		ExceptionType,
		Details
    )
    values
    (
		@EventId,
		@EventTimeUtc,
		@EventTime,
		@EventType,
		@EventSequence,
		@EventOccurrence,
		@EventCode,
		@EventDetailCode,
		@Message,
		@ApplicationPath,
		@ApplicationVirtualPath,
		@MachineName,
		@RequestUrl,
		@ExceptionType,
		@Details
    )
create procedure sysdiagrams_i
	@name sysname,
	@principal_id int,
	@diagram_id int,
	@version int,
	@definition varbinary
as
    insert into sysdiagrams
    (
		name,
		principal_id,
		diagram_id,
		version,
		definition
    )
    values
    (
		@name,
		@principal_id,
		@diagram_id,
		@version,
		@definition
    )
create procedure Users_i
as
    insert into Users
    (
    )
    values
    (
    )
create procedure ItemQuestion_i
as
    insert into ItemQuestion
    (
    )
    values
    (
    )
create procedure ItemQuestionResult_i
as
    insert into ItemQuestionResult
    (
    )
    values
    (
    )
create procedure ParentCondition_i
as
    insert into ParentCondition
    (
    )
    values
    (
    )
create procedure PredeterminateValue_i
as
    insert into PredeterminateValue
    (
    )
    values
    (
    )
create procedure QuestionResult_i
as
    insert into QuestionResult
    (
    )
    values
    (
    )
create procedure Questions_i
as
    insert into Questions
    (
    )
    values
    (
    )
create procedure Survey_i
as
    insert into Survey
    (
    )
    values
    (
    )
create procedure SurveyResult_i
as
    insert into SurveyResult
    (
    )
    values
    (
    )
