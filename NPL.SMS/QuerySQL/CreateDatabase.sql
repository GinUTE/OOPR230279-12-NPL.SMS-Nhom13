CREATE DATABASE SMS
GO

USE SMS
GO

CREATE TABLE Customer
(
	customer_id int IDENTITY(1,1) NOT NULL,
	customer_name nvarchar(100),
	PRIMARY KEY(customer_id)
)
GO

CREATE TABLE Employee
(
	employee_id int IDENTITY(1,1) NOT NULL,
	employee_name nvarchar(100),
	salary float,
	supervisor_id int,
	PRIMARY KEY(employee_id)
)
GO

CREATE TABLE Product
(
	product_id int IDENTITY(1,1) NOT NULL,
	product_name nvarchar(100),
	product_price float,
	PRIMARY KEY(product_id)
)
GO

CREATE TABLE Orders
(
	order_id int IDENTITY(1,1) NOT NULL,
	order_date datetime,
	customer_id int NOT NULL,
	employee_id int NOT NULL,
	total float,
	PRIMARY KEY(order_id)
)
GO

CREATE TABLE LineItem
(
	order_id int,
	product_id int,
	quantity int,
	price float,
	PRIMARY KEY(product_id, order_id)
)
GO

ALTER TABLE Orders ADD FOREIGN KEY(customer_id) REFERENCES Customer(customer_id)
ALTER TABLE Orders ADD FOREIGN KEY(employee_id) REFERENCES Employee(employee_id)
ALTER TABLE LineItem ADD FOREIGN KEY(order_id) REFERENCES Orders(order_id)
ALTER TABLE LineItem ADD FOREIGN KEY(product_id) REFERENCES Product(product_id)
GO