CREATE TABLE [dbo].[Pupil Class]
(
	[pupil_id] INT NOT NULL FOREIGN KEY REFERENCES Student(Id),
	[class_id] INT NOT NULL FOREIGN KEY REFERENCES Class(Id),
	PRIMARY KEY (pupil_id,class_id)
)
