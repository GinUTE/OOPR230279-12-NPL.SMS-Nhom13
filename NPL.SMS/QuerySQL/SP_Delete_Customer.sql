CREATE PROC SP_Delete_Customer(@id int)
AS
BEGIN TRY
BEGIN TRANSACTION
	DELETE FROM LineItem
	WHERE LineItem.Order_id=(SELECT	Ordr.order_id						
							FROM Orders Ordr
							WHERE Ordr.customer_id = @id)
	DELETE FROM Orders WHERE customer_id = @id
	DELETE FROM Customer WHERE customer_id = @id
COMMIT
END TRY
BEGIN CATCH
	if(@@TRANCOUNT > 0)
		ROLLBACK TRAN
END CATCH
GO