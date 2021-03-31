CREATE VIEW [dbo].[FullClass]
	AS SELECT 
	[dbo].[Course].[Subject], 
	[dbo].[Course].[Scqf], 
	[dbo].[Course].[Level], 
	[dbo].[Course_Class].[ClassTime], 
	[dbo].[Course_Class].[TeacherId], 
	[dbo].[Pupil Class].[PupilId], 
	[dbo].[Pupil Class].[ClassId]
	FROM Course,Course_Class,[Pupil Class]
	WHERE Course.CourseId = Course_Class.CourseId
	AND [Pupil Class].ClassId = Course_Class.ClassId
