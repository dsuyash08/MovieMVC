USE [IMDB]
GO

/****** Object: SqlProcedure [dbo].[sp_get_movie] Script Date: 09-05-2019 22:22:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO

CREATE PROCEDURE [dbo].[sp_get_movie]
	@Id int
AS
	SELECT MovieId,Name as MovieName,Plot,ReleaseDate from Movies where MovieId = @Id
