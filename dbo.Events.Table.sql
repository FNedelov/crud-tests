USE [CRUDApp]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 26/04/2023 14:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (1, 1, N'System', N'Calling API method', CAST(N'2023-04-14T15:03:57.947' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (2, 1, N'System', N'Calling API method /api/Auth/Authenticate', CAST(N'2023-04-14T15:05:40.040' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (3, 1, N'System', N'Test exception -    at CRUD.API.Middlewares.ExceptionMiddleware.InvokeAsync(HttpContext httpContext, IEventService eventService) in C:\Users\JB43XG\Programming\CRUDApp.NET.Core\CRUD.API\Middlewares\ExceptionMiddleware.cs:line 33', CAST(N'2023-04-14T15:06:53.387' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (4, 1, N'System', N'Test exception -    at CRUD.API.Middlewares.ExceptionMiddleware.InvokeAsync(HttpContext httpContext, IEventService eventService) in C:\Users\JB43XG\Programming\CRUDApp.NET.Core\CRUD.API\Middlewares\ExceptionMiddleware.cs:line 33', CAST(N'2023-04-14T15:07:56.013' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (5, 0, N'System', N'Test exception -    at CRUD.API.Middlewares.ExceptionMiddleware.InvokeAsync(HttpContext httpContext, IEventService eventService) in C:\Users\JB43XG\Programming\CRUDApp.NET.Core\CRUD.API\Middlewares\ExceptionMiddleware.cs:line 33', CAST(N'2023-04-14T15:11:46.630' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (6, 1, N'System', N'Calling API method: /api/Auth/Authenticate', CAST(N'2023-04-14T15:17:06.670' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (7, 0, N'string', N'string', CAST(N'2023-04-14T15:18:21.507' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (8, 0, N'string', N'Client side exception', CAST(N'2023-04-14T15:19:58.603' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (9, 2, N'user', N'Calling API method: /api/Auth/Authenticate', CAST(N'2023-04-14T15:21:27.913' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (10, 2, N'user', N'Calling API method: /api/Auth/Authenticate', CAST(N'2023-04-14T15:24:21.753' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (11, 2, N'userTestName', N'Calling API method: /api/Auth/Authenticate', CAST(N'2023-04-14T15:27:16.283' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (12, 2, N'userTestName', N'Calling API method: /api/Auth/Authenticate', CAST(N'2023-04-17T12:23:52.030' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (13, 1, N'System', N'Calling API method: /api/Auth/Authenticate', CAST(N'2023-04-17T13:30:45.313' AS DateTime))
INSERT [dbo].[Events] ([Id], [Type], [UserName], [Description], [CreatedDate]) VALUES (14, 1, N'System', N'Calling API method: /api/Auth/Authenticate', CAST(N'2023-04-17T13:32:13.207' AS DateTime))
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
