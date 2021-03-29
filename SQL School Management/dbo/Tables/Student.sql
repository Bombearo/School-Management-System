CREATE TABLE [dbo].[Pupil]
(
	[PupilId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Forename] VARCHAR(30) NOT NULL,
	[Surname] VARCHAR(30) NOT NULL,
	[DateOfBirth] date NOT NULL,
	[DateJoined] date NOT NULL,
	[ContactNo] VARCHAR(11),
	[EmailAddress] VARCHAR(50)
)
