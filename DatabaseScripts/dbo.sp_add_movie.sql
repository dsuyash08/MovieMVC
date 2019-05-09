USE [IMDB]
GO

/****** Object: SqlProcedure [dbo].[sp_add_movie] Script Date: 09-05-2019 22:20:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO
CREATE PROCEDURE [dbo].[sp_add_movie]
	@MovieName varchar(200),
	@Plot varchar(max),
    @ReleaseDate datetime,
    @Producer varchar(10),
    @ImgPath varchar(300),
    @Actors varchar(max)
AS
	Declare @movieid int;
	
	Insert into dbo.Movies(Name,Plot,ReleaseDate,ProducerId,ImgPath) values 
	(@MovieName,@Plot,@ReleaseDate,CAST(@Producer as int),@ImgPath);
	
	select @movieid = @@Identity;

	select @movieid as movieid, cast(value as int) as actorid into #Temp from string_split(@Actors,',') ;

	insert into dbo.Movie_Actor(MovieId,ActorId) select movieid,actorid from #Temp;
