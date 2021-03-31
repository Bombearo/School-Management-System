﻿CREATE VIEW [dbo].[FullClass]
	AS SELECT [dbo].[Course].[CourseId], 
	[dbo].[Course].[Subject], 
	[dbo].[Course].[Scqf], 
	[dbo].[Course].[Level], 
	[dbo].[Course_Class].[ClassId],
	[dbo].[Course_Class].[ClassTime], 
	[dbo].[Course_Class].[DayOfWeek], 
	[dbo].[Course_Class].[TeacherId], 
	[dbo].[Pupil Class].[PupilId]
	FROM Course,Course_Class,[Pupil Class]
	WHERE Course.CourseId = Course_Class.CourseId
	AND [Pupil Class].ClassId = Course_Class.ClassId
