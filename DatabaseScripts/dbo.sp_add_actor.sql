USE [IMDB]
GO

/****** Object: SqlProcedure [dbo].[sp_add_actor] Script Date: 09-05-2019 22:20:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO
CREATE PROCEDURE [dbo].[sp_add_actor]
	@ActorName varchar(200),
	@Sex varchar(10),
	@DOB datetime,
	@Bio varchar(max)
AS
	Insert into Actors(ActorName,Sex,DOB,Bio) values (@ActorName,@Sex,@DOB,@Bio)
