CREATE PROCEDURE [dbo].[Get_Course_By_Level]
AS
Begin
	SELECT [CourseId], [Subject],[Level], [Scqf]
	FROM dbo.Course
	ORDER BY Scqf ASC
END
