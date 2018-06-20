USE [Sxh]
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

INSERT INTO PayType
					SELECT 1, '按年付息'
UNION ALL SELECT 2, '半年付息'
UNION ALL SELECT 3, '季度付息'
UNION ALL SELECT 4, '按月付息'
UNION ALL SELECT 5, '按天付息'
GO

INSERT INTO StatusType
					SELECT 1, '进行中'
UNION ALL SELECT 2, '已完成'
GO

INSERT INTO Project
SELECT 1, '新媒体项目融资', 1, 1, 5, 8000, 13.8
GO
INSERT INTO Product
                    SELECT 770675, 1, '新媒体项目融资（1）', 1000, '2017-04-11 17:07:25'
UNION ALL SELECT 770712, 1, '新媒体项目融资（2）', 500, '2017-04-11 17:13:01'
UNION ALL SELECT 770734, 1, '新媒体项目融资（3）', 500, '2017-04-11 17:25:23'
UNION ALL SELECT 770743, 1, '新媒体项目融资（4）', 500, '2017-04-11 18:00:36'
UNION ALL SELECT 773300, 1, '新媒体项目融资（5）', 500, '2017-04-11 16:17:53'
UNION ALL SELECT 773318, 1, '新媒体项目融资（6）', 500, '2017-04-12 16:15:18'
UNION ALL SELECT 773349, 1, '新媒体项目融资（7）', 500, '2017-04-12 16:32:03'
UNION ALL SELECT 775474, 1, '新媒体项目融资（8）', 500, '2017-04-13 16:00:11 '
UNION ALL SELECT 775477, 1, '新媒体项目融资（9）', 500, '2017-04-13 16:15:15'
UNION ALL SELECT 775482, 1, '新媒体项目融资（10）', 500, '2017-04-13 16:30:11'
UNION ALL SELECT 775489, 1, '新媒体项目融资（11）', 500, '2017-04-13 16:45:45'
UNION ALL SELECT 777461, 1, '新媒体项目融资（12）', 500, '2017-04-14 16:14:52'
UNION ALL SELECT 777476, 1, '新媒体项目融资（13）', 500, '2017-04-14 16:18:46'
UNION ALL SELECT 777492, 1, '新媒体项目融资（14）', 500, '2017-04-13 16:30:38'