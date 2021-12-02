USE SMS
GO
CREATE PROC SP_Add_Customer (@Customer_Name nvarchar (100))
AS
INSERT INTO Customer(customer_name) VALUES(@customer_Name)