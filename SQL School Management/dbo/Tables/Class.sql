﻿CREATE TABLE [dbo].[Class]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[time] TIME NOT NULL,
	[course_id] INT NOT NULL FOREIGN KEY REFERENCES Course(Id),
	[teacher_id] INT NOT NULL FOREIGN KEY REFERENCES Teacher(Id)
)
