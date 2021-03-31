CREATE PROCEDURE [dbo].[Get_Students_By_Age]
AS
Begin
	SELECT *
	FROM dbo.FullStudent
	ORDER BY DateOfBirth DESC
END
