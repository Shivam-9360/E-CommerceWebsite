CREATE TABLE Reviews (
	Review_ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Product_ID int FOREIGN KEY REFERENCES Products(Product_ID),
	Customer_ID int FOREIGN KEY REFERENCES Customers(Customer_ID),
	Description ntext,
	Rating int NOT NULL,
	Liking varchar(50) NOT NULL
)