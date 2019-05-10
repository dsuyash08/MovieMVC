USE [IMDB]
GO

/****** Object: Table [dbo].[Movies] Script Date: 10-05-2019 13:17:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies] (
    [MovieId]     INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (200) NOT NULL,
    [ReleaseDate] DATETIME      NULL,
    [ImgPath]     VARCHAR (MAX) NULL,
    [Plot]        VARCHAR (MAX) NULL,
    [ProducerId]  INT           NOT NULL
);


