USE SMS
GO
CREATE PROC SP_Update_Order_Total (@order_id int, @total float)
AS
UPDATE Orders
SET total = @total
WHERE order_id = @order_id;