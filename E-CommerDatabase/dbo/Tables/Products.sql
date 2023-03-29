CREATE TABLE [dbo].[Products] (
    [Product_ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Product_Name] VARCHAR (255) NOT NULL,
    [Description]  NTEXT         NULL,
    [ImagePath_1]  VARCHAR (100) NULL,
    [ImagePath_2]  VARCHAR (100) NULL,
    [ImagePath_3]  VARCHAR (100) NULL,
    [ImagePath_4]  VARCHAR (100) NULL,
    [Stock]        INT           NOT NULL,
    [Price]        INT           NULL,
    [Category]     VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Product_ID] ASC)
);

