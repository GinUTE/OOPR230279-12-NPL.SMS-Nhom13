USE SMS
GO
CREATE FUNCTION dbo.Fn_ComputeOrderTotal
(
	@oderId int
)
RETURNS INT
AS
BEGIN
	DECLARE @total_price FLOAT
	SELECT @total_price = 
	(
		SELECT SUM(quantity * price)
		FROM LineItem
		WHERE order_id = @oderId
	)
	RETURN @total_price
END