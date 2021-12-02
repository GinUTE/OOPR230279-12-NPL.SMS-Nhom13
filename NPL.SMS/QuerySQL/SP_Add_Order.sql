USE SMS
GO
CREATE PROC SP_Add_Order (@oder_date datetime, @customer_id int, @employee_id int)
AS
INSERT INTO Orders(order_date, customer_id, employee_id, total) VALUES(@oder_date, @customer_id, @employee_id, 0)