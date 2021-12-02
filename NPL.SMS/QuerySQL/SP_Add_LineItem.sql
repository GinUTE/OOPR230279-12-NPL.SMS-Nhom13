USE SMS
GO
CREATE PROC dbo.SP_Add_LineItem (@oder_id int, @product_id int, @quantity int, @price float)
AS
INSERT INTO LineItem(order_id, product_id, quantity, price) VALUES(@oder_id, @product_id, @quantity, @price)