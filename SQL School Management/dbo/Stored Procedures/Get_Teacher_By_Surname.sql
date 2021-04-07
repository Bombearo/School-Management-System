CREATE PROCEDURE [dbo].[Get_Teacher_By_Surname]
AS
Begin
	SELECT *
	FROM dbo.FullTeacher
	ORDER BY Surname ASC
END