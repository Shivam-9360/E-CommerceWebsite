CREATE TABLE [dbo].[Customers] (
    [Customer_ID]  INT           IDENTITY (1, 1) NOT NULL,
    [FullName]     VARCHAR (255) NOT NULL,
    [Email]        VARCHAR (255) NOT NULL,
    [PhoneNumber]  VARCHAR (10)  NOT NULL,
    [HashPassword] VARCHAR (255) NOT NULL,
    [HashSalt]     VARCHAR (255) NOT NULL,
    [Address]      NTEXT         NULL,
    PRIMARY KEY CLUSTERED ([Customer_ID] ASC),
    CONSTRAINT [Check_PhoneNumber] CHECK ([PhoneNumber] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
);



