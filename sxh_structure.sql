USE [Sxh]
GO

IF EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID('Logs'))
	DROP TABLE Logs
GO


IF EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID('ProductPayment'))
	DROP TABLE ProductPayment
GO

IF EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID('Product'))
	DROP TABLE Product
GO

IF EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID('Project'))
	DROP TABLE Project
GO

IF EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID('PayType'))
	DROP TABLE PayType
GO

IF EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID('StatusType'))
	DROP TABLE StatusType
GO

CREATE TABLE [dbo].[Logs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LogType] [int] NOT NULL,
	[Memo] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[PayType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_PayType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[StatusType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_StatusType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Project](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[StatusId] [int] NOT NULL,
	[PayTypeId] [int] NOT NULL,
	[Deadline] [float] NOT NULL,
	[TotalFunds] [float] NOT NULL,
	[Rate] [float] NOT NULL,
	[ProjectTypeId] [int] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_PayType] FOREIGN KEY([PayTypeId])
REFERENCES [dbo].[PayType] ([Id])
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_PayType]
GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_StatusType] FOREIGN KEY([StatusId])
REFERENCES [dbo].[StatusType] ([Id])
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_StatusType]
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[TotalFunds] [float] NOT NULL,
	[ValueDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Project]
GO

CREATE TABLE [dbo].[ProductPayment](
	[ProductId] [int] NOT NULL,
	[NextPayment] [datetime] NOT NULL,
	[FreqCurrent] [int] NOT NULL,
	[FreqTotal] [int] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductPayment] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProductPayment]  WITH CHECK ADD  CONSTRAINT [FK_ProductPayment_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[ProductPayment] CHECK CONSTRAINT [FK_ProductPayment_Product]
GO