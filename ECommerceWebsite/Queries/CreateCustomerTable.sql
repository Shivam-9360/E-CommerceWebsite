CREATE TABLE Customers (
    Customer_ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FullName varchar(255) NOT NULL,
    Email varchar(255) NOT NULL,
    PhoneNumber varchar(10) 
			constraint Check_PhoneNumber 
			check (PhoneNumber like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
			NOT NULL,
		HashPassword varchar(255) NOT NULL,
		HashSalt varchar(255) NOT NULL		
)