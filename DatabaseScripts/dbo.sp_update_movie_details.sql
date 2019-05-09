USE [IMDB]
GO

/****** Object: SqlProcedure [dbo].[sp_update_movie_details] Script Date: 09-05-2019 22:23:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO

CREATE PROCEDURE [dbo].[sp_update_movie_details]
	@MovieName varchar(200),
	@Plot varchar(max),
    @ReleaseDate datetime,
    @Producer varchar(10),
    @Actors varchar(max),
	@Id int
AS
	Update dbo.Movies
	Set
	Name = @MovieName,
	Plot = @Plot,
	ReleaseDate = @ReleaseDate,
	ProducerId = Cast(@Producer as int)
	where MovieId = @Id;

	Delete from Movie_Actor where MovieId = @Id;

	Select @Id as movieid, cast(value as int) as actorid into #Temp from string_split(@Actors,',');

	Insert into dbo.Movie_Actor(MovieId,ActorId) Select movieid,actorid from #Temp;
