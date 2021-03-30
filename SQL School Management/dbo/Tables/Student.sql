CREATE TABLE [dbo].[Pupil]
(
	[PupilId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[DateJoined] date NOT NULL DEFAULT getdate(),
	[PersonId] INT NOT NULL FOREIGN KEY REFERENCES Person(PersonId)
)
