CREATE TABLE [dbo].[Person]
(
	[PersonId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Forename] VARCHAR(30) NOT NULL,
	[Surname] VARCHAR(30) NOT NULL,
	[DateOfBirth] date NOT NULL,
	[EmailAddress] VARCHAR(50),
	[ContactNo] VARCHAR(11)
)
