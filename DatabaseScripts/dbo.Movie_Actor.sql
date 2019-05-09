USE [IMDB]
GO

/****** Object: Table [dbo].[Movie_Actor] Script Date: 09-05-2019 22:15:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO
CREATE TABLE [dbo].[Movie_Actor] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [MovieId] INT NOT NULL,
    [ActorId] INT NOT NULL
	foreign key(MovieId) references Movies(MovieId)
	foreign key(ActorId) references Actors(MovieId)
);


