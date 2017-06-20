USE ConferenceDB
GO

CREATE TABLE [dbo].[Users]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[DevicePhoneNumber] NVARCHAR(50) NOT NULL,
	[Pin] NVARCHAR(50) NOT NULL,
	[DateCreated] DATETIME NOT NULL DEFAULT GETDATE(),
	[IsActive] BIT NOT NULL,
)
GO


CREATE TABLE [dbo].[VirtualPhoneNumbers]
(
	[VirtualPhoneNumberId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[PhoneNumber] NVARCHAR(50) NOT NULL,
	[DateCreated] DATETIME NOT NULL DEFAULT GETDATE(),
	[IsActive] BIT NOT NULL,
	[ProviderId] NVARCHAR(100),
)
GO

ALTER TABLE VirtualPhoneNumbers
ADD CONSTRAINT FK_VirtualPhoneNumber_Users 
	FOREIGN KEY (UserId) 
	REFERENCES	Users (UserId)
GO

CREATE TABLE [dbo].[Conferences]
(
	[ConferenceId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[ConferenceName] NVARCHAR(50) NOT NULL,
	[ConferencePassCode] NVARCHAR(50) NOT NULL,
	[WelcomeMessage] NVARCHAR(50),
	[Participants] NVARCHAR(MAX) NOT NULL,
	[Cost] DECIMAL(10,2),
	[DateCreated] DATETIME NOT NULL DEFAULT GETDATE(),
	[Status] NVARCHAR(50),
	[ProviderId] NVARCHAR(100),
)
GO

ALTER TABLE Conferences
ADD CONSTRAINT FK_Conference_Users 
	FOREIGN KEY (UserId) 
	REFERENCES	Users (UserId)
GO



