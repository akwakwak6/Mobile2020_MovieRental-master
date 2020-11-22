CREATE PROCEDURE [dbo].[GetFilletedMovieList]
	@Category int = NULL,
	@Actor int = NULL,
	@Title NVARCHAR(300) = NULL,
	@Langage int = NULL,
	@KeyWord NVARCHAR(300) = NULL
AS
BEGIN

	DECLARE @filmID IdList;
	SET NOCOUNT ON;

	INSERT INTO @filmID select FilmId from Film
	DECLARE @filmIdTP IdList;

	IF (@Category IS NOT NULL)
	BEGIN 
		INSERT INTO @filmIdTP select FC.FilmId from @filmID AS F JOIN FilmCategory AS FC ON F.Id = FC.FilmId WHERE FC.CategoryId = @Category
		DELETE FROM @filmID
		INSERT INTO @filmID select Id from @filmIdTP
	END

	IF (@Actor IS NOT NULL)
	BEGIN 
		DELETE FROM @filmIdTP
		INSERT INTO @filmIdTP select FA.FilmId from @filmID AS F JOIN FilmActor AS FA ON F.Id = FA.FilmId WHERE FA.ActorId = @Actor
		DELETE FROM @filmID
		INSERT INTO @filmID select Id from @filmIdTP
	END

	IF (@Title IS NOT NULL)
	BEGIN 
		DELETE FROM @filmIdTP
		INSERT INTO @filmIdTP select F.FilmId from @filmID AS Fid JOIN Film AS F ON Fid.Id = F.FilmId WHERE F.Title LIKE @Title
		DELETE FROM @filmID
		INSERT INTO @filmID select Id from @filmIdTP
	END

	IF (@Langage IS NOT NULL)
	BEGIN 
		DELETE FROM @filmIdTP
		INSERT INTO @filmIdTP select F.FilmId from @filmID AS Fid JOIN Film AS F ON Fid.Id = F.FilmId WHERE F.LanguageId = @Langage
		DELETE FROM @filmID
		INSERT INTO @filmID select Id from @filmIdTP
	END

	IF (@KeyWord IS NOT NULL)
	BEGIN 
		DELETE FROM @filmIdTP
		INSERT INTO @filmIdTP select F.FilmId from @filmID AS Fid JOIN Film AS F ON Fid.Id = F.FilmId WHERE F.Title LIKE ('%'+@KeyWord+'%')
		INSERT INTO @filmIdTP select F.FilmId from @filmID AS Fid JOIN Film AS F ON Fid.Id = F.FilmId WHERE F.Description LIKE ('%'+@KeyWord+'%')
		DELETE FROM @filmID
		INSERT INTO @filmID select Id from @filmIdTP
	END


	SELECT FilmID,Title,RentalPrice from V_Film WHERE FilmID IN (SELECT Id FROM @filmID)

END
