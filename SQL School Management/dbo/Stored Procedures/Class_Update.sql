CREATE PROCEDURE [dbo].[Class_Update]
    @ClassId int,
	@DayOfWeek nvarchar(9),
	@ClassTime time,
	@TeacherId int,
	@CourseId int
AS
IF NOT EXISTS (	SELECT ClassId
	FROM Course_Class
	WHERE DayOfWeek = @DayOfWeek
	AND ClassTime = @ClassTime
	AND TeacherId = @TeacherId)
BEGIN
UPDATE Course_Class
SET DayOfWeek = @DayOfWeek,ClassTime=@ClassTime,TeacherId=@TeacherId,CourseId=@CourseId
WHERE ClassId = @ClassId;
END
