CREATE PROCEDURE [dbo].[Course_Insert]
	@Scqf int,
	@Subject nvarchar(50),
	@Level nvarchar(20)
AS
IF EXISTS (	SELECT CourseId
	FROM Course
	WHERE Subject = @Subject
	AND Level = @Level
	AND Scqf = @Scqf)
BEGIN
SELECT CourseId
	FROM Course
	WHERE Subject = @Subject
	AND Level = @Level
	AND Scqf = @Scqf
END
ELSE
BEGIN
	INSERT INTO Course(Scqf,Subject,Level)
	VALUES (@Scqf,@Subject,@Level);
	SELECT CAST(SCOPE_IDENTITY() AS INT);
END
RETURN 0
