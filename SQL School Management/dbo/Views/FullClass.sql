CREATE VIEW [dbo].[FullClass]
	AS SELECT [dbo].[Course_Class].[ClassId], 
	[dbo].[Course_Class].[ClassTime], 
	[dbo].[Course_Class].[DayOfWeek], 
	[dbo].[Course_Class].[CourseId],
	[dbo].[Course_Class].[TeacherId], 
	[dbo].[Course].[Subject], 
	[dbo].[Course].[Scqf], 
	[dbo].[Course].[Level]

	FROM Course_Class
	left join Course on Course_Class.CourseId = Course.CourseId
