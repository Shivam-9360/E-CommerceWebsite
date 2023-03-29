SET IDENTITY_INSERT [dbo].[Reviews] ON
INSERT INTO [dbo].[Reviews] ([Review_ID], [Product_ID], [Customer_ID], [Description], [Liking]) VALUES (1, 1, 3, N'Good product', N'Average')
INSERT INTO [dbo].[Reviews] ([Review_ID], [Product_ID], [Customer_ID], [Description], [Liking]) VALUES (2, 1, 4, N'The product is excellent!', N'Good')
SET IDENTITY_INSERT [dbo].[Reviews] OFF
