CREATE TABLE [dbo].[Teacher]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[forename] VARCHAR(30) NOT NULL,
	[surname] VARCHAR(30) NOT NULL,
	[dob] date NOT NULL,
	[dateJoined] date NOT NULL DEFAULT getdate(),
	[salary] INT NOT NULL,
	[bonusAdded] BIT NOT NULL DEFAULT 0,
	[expertise] VARCHAR(20),
	[emailAddress] VARCHAR(50),
	[contactNo] VARCHAR(11)
)
