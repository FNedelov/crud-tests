USE [CRUDApp]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26/04/2023 14:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Definition] [varchar](20) NOT NULL,
	[CreatedBy] [varchar](12) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Definition], [CreatedBy], [CreatedDate], [Status], [ModifiedDate]) VALUES (1, N'Operator', N'jb43xg', CAST(N'2023-04-11T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[Roles] ([RoleId], [Definition], [CreatedBy], [CreatedDate], [Status], [ModifiedDate]) VALUES (2, N'Admin', N'jb43xg', CAST(N'2023-04-12T00:00:00.000' AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
