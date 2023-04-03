CREATE TABLE [dbo].[Cart] (
    [Cart_ID]     INT IDENTITY (1, 1) NOT NULL,
    [Product_ID]  INT NOT NULL,
    [Customer_ID] INT NOT NULL,
    [Quantity]    INT NOT NULL,
    [IsWished]    BIT NULL,
    [IsInCart]    BIT NULL,
    PRIMARY KEY CLUSTERED ([Cart_ID] ASC),
    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_ID]),
    FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Products] ([Product_ID])
);





