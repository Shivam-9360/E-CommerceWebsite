CREATE TABLE Products (
	Product_ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Product_Name varchar(255) NOT NULL,
	Description ntext,
	ImagePath_1 ntext,
	ImagePath_2 ntext,
	ImagePath_3 ntext,
	ImagePath_4 ntext,
	Stock int NOT NULL	
)