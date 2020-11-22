CREATE PROCEDURE [dbo].[GetRentalMovies]
	@RentalId int
AS
BEGIN
	select F.FilmId,F.Title,RD.RentalPrice 
	from Rental as R join RentalDetail as RD 
	on RD.RentalId = R.RentalId join Film as F 
	ON F.FilmId = RD.FilmId 
	WHERE R.RentalId = @RentalId
END
