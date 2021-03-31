
CREATE PROCEDURE [dbo].[People_Insert]
	@Forename nvarchar(30),
	@Surname nvarchar(30),
	@DateOfBirth date,
	@EmailAddress nvarchar(50),
	@ContactNo nvarchar(11)
AS
BEGIN
	INSERT INTO Person(Forename,Surname,DateOfBirth,EmailAddress,ContactNo)
	VALUES (@Forename,@Surname,@DateOfBirth,@EmailAddress,@ContactNo);
	SELECT CAST(SCOPE_IDENTITY() AS INT);
END
RETURN 0

