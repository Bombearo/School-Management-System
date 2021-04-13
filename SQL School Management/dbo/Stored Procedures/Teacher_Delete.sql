CREATE PROCEDURE [dbo].[Teacher_Delete]
	@PersonId int

AS
BEGIN
DELETE FROM Teacher
WHERE PersonId = @PersonId;
DELETE FROM Person
WHERE PersonId = @PersonId;

END