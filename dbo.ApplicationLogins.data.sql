SET IDENTITY_INSERT [dbo].[ApplicationLogins] ON
INSERT INTO [dbo].[ApplicationLogins] ([id], [username], [password]) VALUES (NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ApplicationLogins] OFF

INSERT INTO [dbo].[ApplicationLogins] ([username], [password]) VALUES ('LivingCarParkWeb', 'manycars')
