CREATE PROCEDURE [dbo].[People_Update]
	@PersonID int,
	@Forename nvarchar(30),
	@Surname nvarchar(30),
	@DateOfBirth date,
	@EmailAddress nvarchar(50),
	@ContactNo nvarchar(11)
AS
BEGIN
	UPDATE Person
	SET forename = @Forename,
	surname = @Surname,
	dateofBirth = @DateOfBirth,
	emailAddress = @EmailAddress,
	contactNo = @ContactNo
	WHERE PersonId = @PersonID;
END
RETURN 0