CREATE PROCEDURE [dbo].[FindTeacher]
	@TeacherID int = 0
AS

BEGIN
	SELECT *
	FROM dbo.FullTeacher
	WHERE TeacherId = @TeacherID
END
RETURN 0
