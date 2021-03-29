CREATE TABLE [dbo].[Teacher]
(
	[TeacherId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Forename] VARCHAR(30) NOT NULL,
	[Surname] VARCHAR(30) NOT NULL,
	[DateOfBirth] date NOT NULL,
	[DateJoined] date NOT NULL DEFAULT getdate(),
	[Salary] INT NOT NULL,
	[BonusAdded] BIT NOT NULL DEFAULT 0,
	[Expertise] VARCHAR(20),
	[EmailAddress] VARCHAR(50),
	[ContactNo] VARCHAR(11)
)
