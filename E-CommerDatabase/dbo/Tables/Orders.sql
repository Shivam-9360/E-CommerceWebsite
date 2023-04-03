CREATE TABLE [dbo].[Orders] (
    [Order_ID]       INT  IDENTITY (1, 1) NOT NULL,
    [Order_NO]       INT  NOT NULL,
    [Customer_ID]    INT  NOT NULL,
    [Cart_ID]        INT  NOT NULL,
    [Order_Date]     DATE NOT NULL,
    [Base_Price]     INT  NOT NULL,
    [Shipping_price] INT  NOT NULL,
    [Discount]       INT  NULL,
    PRIMARY KEY CLUSTERED ([Order_ID] ASC),
    FOREIGN KEY ([Cart_ID]) REFERENCES [dbo].[Cart] ([Cart_ID]),
    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_ID])
);

