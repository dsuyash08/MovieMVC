USE [IMDB]
GO

/****** Object: Table [dbo].[Actors] Script Date: 09-05-2019 22:13:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO
CREATE TABLE [dbo].[Actors] (
    [ActorId]   INT            IDENTITY (1, 1) NOT NULL,
    [ActorName] VARCHAR (200)  NOT NULL,
    [Sex]       VARCHAR (10)   NOT NULL,
    [DOB]       DATETIME       NOT NULL,
    [Bio]       NVARCHAR (MAX) NOT NULL
);


