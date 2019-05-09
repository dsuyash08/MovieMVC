
CREATE PROCEDURE [dbo].[sp_add_producer]
	@ProducerName varchar(200),
	@Sex varchar(10),
	@DOB datetime,
	@Bio varchar(max)
AS
	Insert into Producers(ProducerName,Sex,DOB,Bio) values (@ProducerName,@Sex,@DOB,@Bio)