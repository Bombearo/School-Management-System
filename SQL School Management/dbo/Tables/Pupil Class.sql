CREATE TABLE [dbo].[Pupil Class]
(
	[PupilId] INT NOT NULL FOREIGN KEY REFERENCES [Pupil]([PupilId]),
	[ClassId] INT NOT NULL FOREIGN KEY REFERENCES [Course_Class]([ClassId]),
	PRIMARY KEY ([PupilId],[ClassId])
)
