CREATE TABLE [dbo].[Reviews] (
    [Review_ID]   INT          IDENTITY (1, 1) NOT NULL,
    [Product_ID]  INT          NOT NULL,
    [Customer_ID] INT          NOT NULL,
    [Description] NTEXT        NULL,
    [Liking]      VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Review_ID] ASC),
    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_ID]),
    FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Products] ([Product_ID])
);

