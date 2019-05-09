CREATE TABLE [dbo].[Producers]
(
	[ProducerId] INT IDENTITY(1,1) PRIMARY KEY,
	[ProducerName] varchar NOT NULL,
	[Sex] varchar,
	[DOB] datetime,
	[Bio] varchar
)
