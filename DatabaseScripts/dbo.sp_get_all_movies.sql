USE [IMDB]
GO

/****** Object: SqlProcedure [dbo].[sp_get_all_movies] Script Date: 09-05-2019 22:21:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO

CREATE PROCEDURE [dbo].[sp_get_all_movies]
AS

SELECT
	M.MovieId,
	M.Name as MovieName,
	M.Plot,
	M.ReleaseDate,
	P.ProducerName as Producer,
	M.ImgPath,
	M.ReleaseDate,
	(Select SUBSTRING( 
	( 
     SELECT ', ' + ActorName AS 'data()' 
         FROM Actors as A join Movie_Actor as B on A.ActorId = B.ActorId
		 where B.MovieId = M.MovieId
		 FOR XML PATH('') 
	), 2 , 9999)) As Actors
	FROM [Movies] as M join Producers as P on M.ProducerId=P.ProducerId
