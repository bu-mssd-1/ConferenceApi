USE ConferenceDB
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetUsers')
	DROP PROCEDURE [dbo].[GetUsers]
GO

/*
Retrieves all users from the database.
*/
CREATE PROCEDURE [dbo].[GetUsers]
AS

BEGIN
	SELECT	[UserId],[DevicePhoneNumber],[Pin],[DateCreated],[IsActive]
	FROM	[dbo].[Users]
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetUserById')
	DROP PROCEDURE [dbo].[GetUserById]
GO

/*
Retrieves a particular user from the database by a given UserId.
*/
CREATE PROCEDURE [dbo].[GetUserById]
(
	@UserId NVARCHAR(50)
)
AS

BEGIN
	SELECT	[UserId],[DevicePhoneNumber],[Pin],[DateCreated],[IsActive]
	FROM	[dbo].[Users] o
	WHERE	CONVERT(NVARCHAR(50), o.UserId) = @UserId
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='DoesUserExist')
	DROP PROCEDURE [dbo].[DoesUserExist]
GO

/*
Checkes if a user exists in the database

TEST: [DoesUserExist] '+14254490088'
*/
CREATE PROCEDURE [dbo].[DoesUserExist]
(
	@PhoneNumber NVARCHAR(50)
)
AS

BEGIN
	DECLARE @UserId NVARCHAR(50)
	SET @UserId = ''

	SELECT @UserId=UserId FROM [dbo].[Users] WHERE DevicePhoneNumber = @PhoneNumber

	SELECT @UserId as UserId
END

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetVirtualPhoneNumbers')
	DROP PROCEDURE [dbo].[GetVirtualPhoneNumbers]
GO

/*
Retrieves all virtualphonenumbers from the database.
*/
CREATE PROCEDURE [dbo].[GetVirtualPhoneNumbers]
AS

BEGIN
	SELECT	[VirtualPhoneNumberId],[UserId],[PhoneNumber],[DateCreated],[IsActive],[ProviderId]
	FROM	[dbo].[VirtualPhoneNumbers]
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetVirtualPhoneNumberById')
	DROP PROCEDURE [dbo].[GetVirtualPhoneNumberById]
GO

/*
Retrieves a particular virtualphonenumber from the database by a given VirtualPhoneNumberId.
*/
CREATE PROCEDURE [dbo].[GetVirtualPhoneNumberById]
(
	@VirtualPhoneNumberId NVARCHAR(50)
)
AS

BEGIN
	SELECT	[VirtualPhoneNumberId],[UserId],[PhoneNumber],[DateCreated],[IsActive],[ProviderId]
	FROM	[dbo].[VirtualPhoneNumbers] o
	WHERE	CONVERT(NVARCHAR(50), o.VirtualPhoneNumberId) = @VirtualPhoneNumberId
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetVirtualPhoneNumbersByUserId')
	DROP PROCEDURE [dbo].[GetVirtualPhoneNumbersByUserId]
GO

/*
Retrieves a list of virtualphonenumbers from the database by a given UserId.
*/
CREATE PROCEDURE [dbo].[GetVirtualPhoneNumbersByUserId]
(
	@UserId NVARCHAR(50)
)
AS

BEGIN
	SELECT	[VirtualPhoneNumberId],[UserId],[PhoneNumber],[DateCreated],[IsActive],[ProviderId]
	FROM	[dbo].[VirtualPhoneNumbers] o
	WHERE	CONVERT(NVARCHAR(50), o.UserId) = @UserId
	ORDER
	BY		o.DateCreated DESC
END
GO


IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetVirtualPhoneNumberByProviderId')
	DROP PROCEDURE [dbo].[GetVirtualPhoneNumberByProviderId]
GO
/*
Retrieves a particular virtualphonenumber from the database by a given ProviderId.
*/
CREATE PROCEDURE [dbo].[GetVirtualPhoneNumberByProviderId]
(
	@ProviderId NVARCHAR(50)
)
AS

BEGIN
	SELECT	[VirtualPhoneNumberId],[UserId],[PhoneNumber],[DateCreated],[IsActive],[ProviderId]
	FROM	[dbo].[VirtualPhoneNumbers] o
	WHERE	CONVERT(NVARCHAR(50), o.ProviderId) = @ProviderId
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetConferences')
	DROP PROCEDURE [dbo].[GetConferences]
GO

/*
Retrieves all conferences from the database.
*/
CREATE PROCEDURE [dbo].[GetConferences]
AS

BEGIN
	SELECT	[ConferenceId],[UserId],[ConferenceName],[ConferencePassCode],[ConferencePhoneNumber],[WelcomeMessage],[Participants],[Cost],[DateCreated],[Status],[ProviderId]
	FROM	[dbo].[Conferences]
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetConferenceById')
	DROP PROCEDURE [dbo].[GetConferenceById]
GO

/*
Retrieves a particular conference from the database by a given ConferenceId.
*/
CREATE PROCEDURE [dbo].[GetConferenceById]
(
	@ConferenceId NVARCHAR(50)
)
AS

BEGIN
	SELECT	[ConferenceId],[UserId],[ConferenceName],[ConferencePassCode],[ConferencePhoneNumber],[WelcomeMessage],[Participants],[Cost],[DateCreated],[Status],[ProviderId]
	FROM	[dbo].[Conferences] o
	WHERE	CONVERT(NVARCHAR(50), o.ConferenceId) = @ConferenceId
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetConferencesByUserId')
	DROP PROCEDURE [dbo].[GetConferencesByUserId]
GO

/*
Retrieves a list of conferences from the database by a given UserId.
*/
CREATE PROCEDURE [dbo].[GetConferencesByUserId]
(
	@UserId NVARCHAR(50)
)
AS

BEGIN
	SELECT	[ConferenceId],[UserId],[ConferenceName],[ConferencePassCode],[ConferencePhoneNumber],[WelcomeMessage],[Participants],[Cost],[DateCreated],[Status],[ProviderId]
	FROM	[dbo].[Conferences] o
	WHERE	CONVERT(NVARCHAR(50), o.UserId) = @UserId
	ORDER
	BY		o.DateCreated DESC
END
GO


IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetConferenceByProviderId')
	DROP PROCEDURE [dbo].[GetConferenceByProviderId]
GO
/*
Retrieves a particular conference from the database by a given ProviderId.
*/
CREATE PROCEDURE [dbo].[GetConferenceByProviderId]
(
	@ProviderId NVARCHAR(50)
)
AS

BEGIN
	SELECT	[ConferenceId],[UserId],[ConferenceName],[ConferencePassCode],[ConferencePhoneNumber],[WelcomeMessage],[Participants],[Cost],[DateCreated],[Status],[ProviderId]
	FROM	[dbo].[Conferences] o
	WHERE	CONVERT(NVARCHAR(50), o.ProviderId) = @ProviderId
END
GO


IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetMessageQueues')
	DROP PROCEDURE [dbo].[GetMessageQueues]
GO

/*
Inserts a user record into the users table.
*/
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='InsertUser')
	DROP PROCEDURE [dbo].[InsertUser]
GO

CREATE PROCEDURE [dbo].[InsertUser]
(
	@UserId UNIQUEIDENTIFIER, @DevicePhoneNumber NVARCHAR(50), @Pin NVARCHAR(50), @DateCreated DATETIME, @IsActive BIT
)
AS

BEGIN
	
	INSERT	
	INTO	[dbo].[Users] ([UserId], [DevicePhoneNumber], [Pin], [DateCreated], [IsActive])
	VALUES	(@UserId, @DevicePhoneNumber, @Pin, @DateCreated, @IsActive)
	
	EXEC [dbo].[GetUserById] @UserId

END
GO


/*
Inserts a virtualphonenumber record into the virtualphonenumbers table.
*/
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='InsertVirtualPhoneNumber')
	DROP PROCEDURE [dbo].[InsertVirtualPhoneNumber]
GO

CREATE PROCEDURE [dbo].[InsertVirtualPhoneNumber]
(
	@VirtualPhoneNumberId UNIQUEIDENTIFIER, @UserId UNIQUEIDENTIFIER, @PhoneNumber NVARCHAR(50), @DateCreated DATETIME, @IsActive BIT, @ProviderId NVARCHAR(100)
)
AS

BEGIN
	
	INSERT	
	INTO	[dbo].[VirtualPhoneNumbers] ([VirtualPhoneNumberId], [UserId], [PhoneNumber], [DateCreated], [IsActive], [ProviderId])
	VALUES	(@VirtualPhoneNumberId, @UserId, @PhoneNumber, @DateCreated, @IsActive, @ProviderId)
	
	EXEC [dbo].[GetVirtualPhoneNumberById] @VirtualPhoneNumberId

END
GO

/*
Inserts a conference record into the conferences table.
*/
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='InsertConference')
	DROP PROCEDURE [dbo].[InsertConference]
GO

CREATE PROCEDURE [dbo].[InsertConference]
(
	@ConferenceId UNIQUEIDENTIFIER, @UserId UNIQUEIDENTIFIER, @ConferenceName NVARCHAR(50), @ConferencePassCode NVARCHAR(50), 
	@ConferencePhoneNumber NVARCHAR(50), @WelcomeMessage NVARCHAR(50), @Participants NVARCHAR(MAX), @Cost DECIMAL(10,2), 
	@DateCreated DATETIME, @Status NVARCHAR(50), @ProviderId NVARCHAR(100)
)
AS

BEGIN
	
	INSERT	
	INTO	[dbo].[Conferences] ([ConferenceId], [UserId], [ConferenceName], [ConferencePassCode], [ConferencePhoneNumber], 
			[WelcomeMessage], [Participants], [Cost], [DateCreated], [Status], [ProviderId])
	VALUES	(@ConferenceId, @UserId, @ConferenceName, @ConferencePassCode, @ConferencePhoneNumber, 
			@WelcomeMessage, @Participants, @Cost, @DateCreated, @Status, @ProviderId)
	
	EXEC [dbo].[GetConferenceById] @ConferenceId

END
GO


/*
Updates a user record in the users table.
*/
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='UpdateUser')
	DROP PROCEDURE [dbo].[UpdateUser]
GO

CREATE PROCEDURE [dbo].[UpdateUser]
(
	@UserId UNIQUEIDENTIFIER, @DevicePhoneNumber NVARCHAR(50), @Pin NVARCHAR(50), @DateCreated DATETIME, @IsActive BIT
)
AS

BEGIN
	
	UPDATE	[dbo].[Users]
	SET		[DevicePhoneNumber] = @DevicePhoneNumber, [Pin] = @Pin, [DateCreated] = @DateCreated, [IsActive] = @IsActive
	WHERE	UserId = @UserId
	
	EXEC [dbo].[GetUserById] @UserId
END
GO

/*
Updates a virtualphonenumber record in the virtualphonenumbers table.
*/
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='UpdateVirtualPhoneNumber')
	DROP PROCEDURE [dbo].[UpdateVirtualPhoneNumber]
GO

CREATE PROCEDURE [dbo].[UpdateVirtualPhoneNumber]
(
	@VirtualPhoneNumberId UNIQUEIDENTIFIER, @UserId UNIQUEIDENTIFIER, @PhoneNumber NVARCHAR(50), @DateCreated DATETIME, @IsActive BIT, @ProviderId NVARCHAR(100)
)
AS

BEGIN
	
	UPDATE	[dbo].[VirtualPhoneNumbers]
	SET		[UserId] = @UserId, [PhoneNumber] = @PhoneNumber, [DateCreated] = @DateCreated, [IsActive] = @IsActive, [ProviderId] = @ProviderId
	WHERE	VirtualPhoneNumberId = @VirtualPhoneNumberId
	
	EXEC [dbo].[GetVirtualPhoneNumberById] @VirtualPhoneNumberId
END
GO

/*
Updates a conference record in the conferences table.
*/
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='UpdateConference')
	DROP PROCEDURE [dbo].[UpdateConference]
GO

CREATE PROCEDURE [dbo].[UpdateConference]
(
	@ConferenceId UNIQUEIDENTIFIER, @UserId UNIQUEIDENTIFIER, @ConferenceName NVARCHAR(50), @ConferencePassCode NVARCHAR(50), @ConferencePhoneNumber NVARCHAR(50), @WelcomeMessage NVARCHAR(50), @Participants NVARCHAR(MAX), @Cost DECIMAL(10,2), @DateCreated DATETIME, @Status NVARCHAR(50), @ProviderId NVARCHAR(100)
)
AS

BEGIN
	
	UPDATE	[dbo].[Conferences]
	SET		[UserId] = @UserId, [ConferenceName] = @ConferenceName, [ConferencePassCode] = @ConferencePassCode, [ConferencePhoneNumber] = @ConferencePhoneNumber, [WelcomeMessage] = @WelcomeMessage, [Participants] = @Participants, [Cost] = @Cost, [DateCreated] = @DateCreated, [Status] = @Status, [ProviderId] = @ProviderId
	WHERE	ConferenceId = @ConferenceId
	
	EXEC [dbo].[GetConferenceById] @ConferenceId
END
GO



IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='DeleteUser')
	DROP PROCEDURE [dbo].[DeleteUser]
GO

/*
Deletes a user record in the users table.
*/
CREATE PROCEDURE [dbo].[DeleteUser]
(
	@UserId UNIQUEIDENTIFIER
)
AS

BEGIN
	
	DELETE 
	FROM	[dbo].[Users]
	WHERE	UserId = @UserId
	
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='DeleteVirtualPhoneNumber')
	DROP PROCEDURE [dbo].[DeleteVirtualPhoneNumber]
GO

/*
Deletes a virtualphonenumber record in the virtualphonenumbers table.
*/
CREATE PROCEDURE [dbo].[DeleteVirtualPhoneNumber]
(
	@VirtualPhoneNumberId UNIQUEIDENTIFIER
)
AS

BEGIN
	
	DELETE 
	FROM	[dbo].[VirtualPhoneNumbers]
	WHERE	VirtualPhoneNumberId = @VirtualPhoneNumberId
	
END
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='DeleteConference')
	DROP PROCEDURE [dbo].[DeleteConference]
GO

/*
Deletes a conference record in the conferences table.
*/
CREATE PROCEDURE [dbo].[DeleteConference]
(
	@ConferenceId UNIQUEIDENTIFIER
)
AS

BEGIN
	
	DELETE 
	FROM	[dbo].[Conferences]
	WHERE	ConferenceId = @ConferenceId
	
END
GO

/*
Retrive a phone number record by its phone number
*/
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE='P' AND NAME='GetVirtualPhoneNumberByPhoneNumber')
	DROP PROCEDURE [dbo].[GetVirtualPhoneNumberByPhoneNumber]
GO

CREATE PROCEDURE [dbo].[GetVirtualPhoneNumberByPhoneNumber]
(
	@PhoneNumber NVARCHAR(50)
)
AS

BEGIN
	SELECT	[VirtualPhoneNumberId],[UserId],[PhoneNumber],[DateCreated],[IsActive],[ProviderId]
	FROM	[dbo].[VirtualPhoneNumbers] o
	WHERE	CONVERT(NVARCHAR(50), o.PhoneNumber) = @PhoneNumber
END

GO


/*
Retrieves a particular conference from the database by 
	a given PhoneNumber and PassCode.
*/
Create PROCEDURE [dbo].[GetConferenceByPhoneAndPassCode]
(
	@PhoneNumber NVARCHAR(50),
	@PassCode NVARCHAR(50)
)
AS

BEGIN
	SELECT	[ConferenceId],[UserId],[ConferenceName],[ConferencePhoneNumber],[ConferencePassCode],[WelcomeMessage],[Participants],[Cost],[DateCreated],[Status],[ProviderId]
	FROM	[dbo].[Conferences] o
	WHERE	o.ConferencePhoneNumber = @PhoneNumber AND o.ConferencePassCode = @PassCode
END

