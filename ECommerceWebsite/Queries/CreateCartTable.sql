CREATE TABLE Cart (
	Cart_ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Product_ID int NOT NULL FOREIGN KEY REFERENCES Products(Product_ID),
	Customer_ID int NOT NULL FOREIGN KEY REFERENCES Customers(Customer_ID),
	Quantity int NOT NULL,
	IsWished BIT,
	IsOrdered BIT,
	IsInCart BIT
);