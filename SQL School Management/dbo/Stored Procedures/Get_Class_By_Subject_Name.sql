CREATE PROCEDURE [dbo].[Get_Class_By_Subject_Name]
AS
Begin
	SELECT [ClassId], [Subject],[Level], [Scqf], [CourseId], [TeacherId], [ClassTime]
	FROM dbo.FullClass
	ORDER BY Subject DESC
END
