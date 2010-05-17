--User moviedo
create procedure Campaings_d
as
    delete from Campaings
    where
--User moviedo
create procedure ImportStatus_d
as
    delete from ImportStatus
    where
--User moviedo
create procedure ParamCampaings_d
as
    delete from ParamCampaings
    where
--User moviedo
create procedure RecordActionResult_d
as
    delete from RecordActionResult
    where
--User moviedo
create procedure RecordAttributeValues_d
as
    delete from RecordAttributeValues
    where
--User moviedo
create procedure Records_d
as
    delete from Records
    where
--User moviedo
create procedure RecordsData_d
as
    delete from RecordsData
    where
--User moviedo
create procedure RecordSetAttributes_d
as
    delete from RecordSetAttributes
    where
--User moviedo
create procedure RecordSetByZoneGoal_d
as
    delete from RecordSetByZoneGoal
    where
--User moviedo
create procedure RecordSets_d
as
    delete from RecordSets
    where
--User moviedo
create procedure RecordsWorkLog_d
as
    delete from RecordsWorkLog
    where
--User moviedo
create procedure UserRecordSetAssignementLog_NoUsar_d
as
    delete from UserRecordSetAssignementLog_NoUsar
    where
--User moviedo
create procedure UserRecordSetAssignment_d
as
    delete from UserRecordSetAssignment
    where
--User moviedo
create procedure aspnet_Applications_d
	@ApplicationId uniqueidentifier
as
    delete from aspnet_Applications
    where
		ApplicationId = @ApplicationId
--User moviedo
create procedure aspnet_Membership_d
	@UserId uniqueidentifier
as
    delete from aspnet_Membership
    where
		UserId = @UserId
--User moviedo
create procedure aspnet_Paths_d
	@PathId uniqueidentifier
as
    delete from aspnet_Paths
    where
		PathId = @PathId
--User moviedo
create procedure aspnet_PersonalizationAllUsers_d
	@PathId uniqueidentifier
as
    delete from aspnet_PersonalizationAllUsers
    where
		PathId = @PathId
--User moviedo
create procedure aspnet_PersonalizationPerUser_d
	@Id uniqueidentifier
as
    delete from aspnet_PersonalizationPerUser
    where
		Id = @Id
--User moviedo
create procedure aspnet_Profile_d
	@UserId uniqueidentifier
as
    delete from aspnet_Profile
    where
		UserId = @UserId
--User moviedo
create procedure aspnet_Roles_d
	@RoleId uniqueidentifier
as
    delete from aspnet_Roles
    where
		RoleId = @RoleId
--User moviedo
create procedure aspnet_Rules_d
as
    delete from aspnet_Rules
    where
--User moviedo
create procedure aspnet_RulesCategory_d
	@CategoryId int
as
    delete from aspnet_RulesCategory
    where
		CategoryId = @CategoryId
--User moviedo
create procedure aspnet_RulesInCategory_d
as
    delete from aspnet_RulesInCategory
    where
--User moviedo
create procedure aspnet_SchemaVersions_d
	@Feature nvarchar
	@CompatibleSchemaVersion nvarchar
as
    delete from aspnet_SchemaVersions
    where
		Feature = @Feature
		CompatibleSchemaVersion = @CompatibleSchemaVersion
--User moviedo
create procedure aspnet_Users_d
	@UserId uniqueidentifier
as
    delete from aspnet_Users
    where
		UserId = @UserId
--User moviedo
create procedure aspnet_UsersInRoles_d
	@UserId uniqueidentifier
	@RoleId uniqueidentifier
as
    delete from aspnet_UsersInRoles
    where
		UserId = @UserId
		RoleId = @RoleId
--User moviedo
create procedure aspnet_WebEvent_Events_d
	@EventId char
as
    delete from aspnet_WebEvent_Events
    where
		EventId = @EventId
--User moviedo
create procedure sysdiagrams_d
	@diagram_id int
as
    delete from sysdiagrams
    where
		diagram_id = @diagram_id
--User moviedo
create procedure Users_d
as
    delete from Users
    where
--User moviedo
create procedure ItemQuestion_d
as
    delete from ItemQuestion
    where
--User moviedo
create procedure ItemQuestionResult_d
as
    delete from ItemQuestionResult
    where
--User moviedo
create procedure ParentCondition_d
as
    delete from ParentCondition
    where
--User moviedo
create procedure PredeterminateValue_d
as
    delete from PredeterminateValue
    where
--User moviedo
create procedure QuestionResult_d
as
    delete from QuestionResult
    where
--User moviedo
create procedure Questions_d
as
    delete from Questions
    where
--User moviedo
create procedure Survey_d
as
    delete from Survey
    where
--User moviedo
create procedure SurveyResult_d
as
    delete from SurveyResult
    where
