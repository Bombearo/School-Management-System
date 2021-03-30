CREATE TABLE [dbo].[Teacher]
(
	[TeacherId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Salary] INT NOT NULL,
	[BonusAdded] BIT NOT NULL DEFAULT 0,
	[Expertise] VARCHAR(20),
	[DateJoined] date NOT NULL DEFAULT getdate(),
	[PersonId] INT NOT NULL FOREIGN KEY REFERENCES Person(PersonId)
)
