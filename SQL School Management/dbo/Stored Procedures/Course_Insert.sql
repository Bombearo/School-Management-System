CREATE PROCEDURE [dbo].[Course_Insert]
	@Scqf int,
	@Subject nvarchar(50),
	@Level nvarchar(20)
AS
	INSERT INTO Course(Scqf,Subject,Level)
	VALUES (@Scqf,@Subject,@Level);
	SELECT CAST(SCOPE_IDENTITY() AS INT);
RETURN 0
