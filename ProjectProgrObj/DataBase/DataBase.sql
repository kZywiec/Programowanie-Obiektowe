USE [master]
GO
/****** Object:  Database [FastFood_Sys]    Script Date: 10.06.2022 03:26:14 ******/
CREATE DATABASE [FastFood_Sys]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FastFood_Sys', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLPROGOBJ\MSSQL\DATA\FastFood_Sys.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FastFood_Sys_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLPROGOBJ\MSSQL\DATA\FastFood_Sys_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FastFood_Sys] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FastFood_Sys].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FastFood_Sys] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FastFood_Sys] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FastFood_Sys] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FastFood_Sys] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FastFood_Sys] SET ARITHABORT OFF 
GO
ALTER DATABASE [FastFood_Sys] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FastFood_Sys] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FastFood_Sys] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FastFood_Sys] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FastFood_Sys] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FastFood_Sys] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FastFood_Sys] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FastFood_Sys] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FastFood_Sys] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FastFood_Sys] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FastFood_Sys] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FastFood_Sys] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FastFood_Sys] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FastFood_Sys] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FastFood_Sys] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FastFood_Sys] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FastFood_Sys] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FastFood_Sys] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FastFood_Sys] SET  MULTI_USER 
GO
ALTER DATABASE [FastFood_Sys] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FastFood_Sys] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FastFood_Sys] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FastFood_Sys] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FastFood_Sys] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FastFood_Sys] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FastFood_Sys] SET QUERY_STORE = OFF
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
