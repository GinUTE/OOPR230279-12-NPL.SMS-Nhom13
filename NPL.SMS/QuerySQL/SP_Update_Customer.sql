CREATE PROC SP_Update_Customer(@id int, @name nvarchar(100))
AS
UPDATE Customer
SET customer_name = @name
WHERE customer_id = @id
GO