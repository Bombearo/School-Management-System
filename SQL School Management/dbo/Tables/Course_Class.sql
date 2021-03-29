﻿CREATE TABLE [dbo].[Course_Class]
(
	[ClassId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ClassTime] TIME NOT NULL,
	[CourseId] INT NOT NULL FOREIGN KEY REFERENCES Course([CourseId]),
	[TeacherId] INT NOT NULL FOREIGN KEY REFERENCES Teacher([TeacherId])
)
