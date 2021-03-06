USE [master]
GO
/****** Object:  Database [FastFood_Sys]    Script Date: 10.06.2022 03:26:14 ******/
CREATE DATABASE [FastFood_Sys]
GO

USE [FastFood_Sys]
GO
/****** Object:  Table [dbo].[FoodItems]    Script Date: 10.06.2022 03:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[Type] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10.06.2022 03:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[DateOfOrder] [smalldatetime] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10.06.2022 03:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10.06.2022 03:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Pin] [nchar](4) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Second_name] [nvarchar](25) NOT NULL,
	[Role_id] [tinyint] NOT NULL,
	[Pesel] [nchar](11) NOT NULL,
	[Phone_number] [nchar](9) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [FastFood_Sys] SET  READ_WRITE 
GO


USE [FastFood_Sys]
GO

INSERT INTO [dbo].[FoodItems]
           ([Name]
           ,[Price]
           ,[Type])
     VALUES
			('Tiramisu','12','Dessert'),
			('Panna cotta','9','Dessert'),
			('Cornetti','4,5','Dessert'),
			('Gelato','7,5','Dessert'),
			('Cantuccini','5','Dessert'),
			('Bisci Amaretto','10','Dessert'),
			('Crostata','16','Dessert'),
			('La Bomba','6','Dessert'),
			('Nerra','5','Caffe'),
			('Latte','12','Caffe'),
			('Cappuccino','7','Caffe'),
			('Ristretto','7,5','Caffe'),
			('Espresso','6','Caffe'),
			('Doppio','12','Caffe'),
			('Cortado','7,5','Caffe'),
			('Lungo','8','Caffe'),
			('Pancetta','13','Appetizer'),
			('Bruschetta','12,5','Appetizer'),
			('Focaccia','15','Appetizer'),
			('Panzeritti','17','Appetizer'),
			('Pizza Bianca','20','Appetizer'),
			('Insalata caprese','18','Appetizer'),
			('Porchetta','26','Appetizer'),
			('Olive ripiene','26','Appetizer')
GO

USE [FastFood_Sys]
GO

INSERT INTO [dbo].[Roles]
           ([Name])
     VALUES
           ('ADMIN'),
		   ('WORKER')
GO

USE [FastFood_Sys]
GO

INSERT INTO [dbo].[Users]
           ([Pin]
           ,[Name]
           ,[Second_name]
           ,[Role_id]
           ,[Pesel]
           ,[Phone_number])
     VALUES
			('2608','Krystian','Żywiec','1','00345678972','543543545'),
			('5555','Adam','Kombinerkowicz','2','99949175348','456987231'),
			('1235','Alicja','Kubek','2','00149175852','515355494'),
			('1212','Eustachy','Głośnik','2','92053001248','544667798')
GO
