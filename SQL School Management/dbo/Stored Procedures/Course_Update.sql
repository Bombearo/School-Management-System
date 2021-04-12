CREATE PROCEDURE [dbo].[Course_Update]
	@Scqf int,
	@Subject nvarchar(50),
	@Level nvarchar(20),
	@CourseId int
AS
IF NOT EXISTS (	SELECT CourseId
	FROM Course
	WHERE Subject = @Subject
	AND Level = @Level
	AND Scqf = @Scqf)
BEGIN
    UPDATE Course
    SET scqf = @Scqf,subject = @Subject,level=@Level
    WHERE CourseId = @CourseId
END

