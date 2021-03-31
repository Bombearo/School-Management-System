CREATE PROCEDURE [dbo].[Class_Insert]
	@DayOfWeek nvarchar(10),
	@ClassTime time,
	@TeacherId int
AS
IF EXISTS (	SELECT ClassId
	FROM Course_Class
	WHERE DayOfWeek = @DayOfWeek
	AND ClassTime = @ClassTime
	AND TeacherId = @TeacherId)
BEGIN
RETURN -1
END
ELSE
BEGIN
	INSERT INTO Course_Class(DayOfWeek,ClassTime,TeacherId)
	VALUES (@DayOfWeek,@ClassTime,@TeacherId);
	SELECT CAST(SCOPE_IDENTITY() AS INT);
END
RETURN 0
