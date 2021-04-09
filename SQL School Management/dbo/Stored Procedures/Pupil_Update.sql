CREATE PROCEDURE [dbo].[Pupil_Update]
	@DateJoined date,
	@PersonId int
AS
BEGIN
	UPDATE Pupil
	SET DateJoined = @DateJoined
	WHERE PersonId = @PersonId;


END