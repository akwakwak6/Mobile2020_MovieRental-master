CREATE PROCEDURE [dbo].[AddRental]
	@MovieList AS dbo.IdList READONLY,
	@CostumerId int,
	@Date date
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @RentalID INT
	BEGIN TRANSACTION;
	BEGIN TRY
		INSERT INTO Rental (RentalDate,CustomerId) VALUES (@Date,@CostumerId)
		SELECT @RentalID = SCOPE_IDENTITY()
		INSERT INTO RentalDetail (RentalId,FilmId,RentalPrice) SELECT @RentalID,L.Id,(SELECT RentalPrice from Film WHERE FilmId=L.Id)  FROM @MovieList AS L
		COMMIT TRANSACTION
		SELECT @RentalID
	END TRY
    BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH

END
