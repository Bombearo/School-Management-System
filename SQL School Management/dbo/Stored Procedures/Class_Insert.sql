CREATE PROCEDURE [dbo].[Class_Insert]
	@DayOfWeek nvarchar(10),
	@ClassTime time,
	@TeacherId int,
	@CourseId int
AS
IF EXISTS (	SELECT ClassId
	FROM Course_Class
	WHERE DayOfWeek = @DayOfWeek
	AND ClassTime = @ClassTime
	AND TeacherId = @TeacherId)
BEGIN
SELECT ClassId
	FROM Course_Class
	WHERE DayOfWeek = @DayOfWeek
	AND ClassTime = @ClassTime
	AND TeacherId = @TeacherId
END
ELSE
BEGIN
	INSERT INTO Course_Class(DayOfWeek,ClassTime,TeacherId,CourseId)
	VALUES (@DayOfWeek,@ClassTime,@TeacherId,@CourseId);
	SELECT CAST(SCOPE_IDENTITY() AS INT);
END
RETURN 0
