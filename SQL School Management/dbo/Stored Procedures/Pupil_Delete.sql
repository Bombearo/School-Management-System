CREATE PROCEDURE [dbo].[Pupil_Delete]
	@PersonId int

AS
BEGIN
DELETE FROM Pupil
WHERE PersonId = @PersonId;
DELETE FROM Person
WHERE PersonId = @PersonId;

END