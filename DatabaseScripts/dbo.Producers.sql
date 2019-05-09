USE [IMDB]
GO

/****** Object: Table [dbo].[Producers] Script Date: 09-05-2019 22:19:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO
CREATE TABLE [dbo].[Producers] (
    [ProducerId]   INT            IDENTITY (1, 1) NOT NULL,
    [ProducerName] VARCHAR (200)  NOT NULL,
    [Sex]          VARCHAR (10)   NOT NULL,
    [DOB]          DATETIME       NOT NULL,
    [Bio]          NVARCHAR (MAX) NOT NULL
);


