USE [master]
GO
/****** Object:  Database [CarRental]    Script Date: 6/11/2021 6:36:51 PM ******/
CREATE DATABASE [CarRental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRental', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarRental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRental_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarRental_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarRental] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRental].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRental] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRental] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRental] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRental] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRental] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRental] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRental] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRental] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRental] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRental] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRental] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRental] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRental] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRental] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRental] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRental] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRental] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRental] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRental] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRental] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRental] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRental] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRental] SET RECOVERY FULL 
GO
ALTER DATABASE [CarRental] SET  MULTI_USER 
GO
ALTER DATABASE [CarRental] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRental] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRental] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRental] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRental] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRental] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CarRental', N'ON'
GO
ALTER DATABASE [CarRental] SET QUERY_STORE = OFF
GO
USE [CarRental]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CarID] [int] NOT NULL,
	[ImagePath] [varchar](100) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BrandID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ModelYear] [int] NOT NULL,
	[DailyPrice] [decimal](19, 4) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[UserID] [int] NOT NULL,
	[CompanyName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CityID] [int] NOT NULL,
	[Name] [nvarchar](75) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CarID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[RentDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[OperationClaimID] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([ID], [Name]) VALUES (1, N'Fiat')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (2, N'Ford')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (3, N'Mercedes')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (4, N'Audi')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (5, N'Honda')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (6, N'Hyundai')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (7, N'BMW')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (8, N'Volkswagen')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (1003, N'Renault')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (1004, N'Ferrari')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([ID], [CarID], [ImagePath], [Date]) VALUES (1, 3, N'25bba34a-870a-4bc7-bd70-40961108c58e.png', CAST(N'2021-06-06T00:42:37.213' AS DateTime))
INSERT [dbo].[CarImages] ([ID], [CarID], [ImagePath], [Date]) VALUES (2, 3, N'afe2d9ef-6770-4c20-a76f-03bfee5db9fe.png', CAST(N'2021-06-06T00:43:13.317' AS DateTime))
INSERT [dbo].[CarImages] ([ID], [CarID], [ImagePath], [Date]) VALUES (3, 3, N'6d54a19a-9a2d-4198-a364-67f24b127d83.png', CAST(N'2021-06-06T00:43:25.920' AS DateTime))
INSERT [dbo].[CarImages] ([ID], [CarID], [ImagePath], [Date]) VALUES (1002, 2, N'1d1dd27f-c2a6-473b-93b7-5553263fcc69.png', CAST(N'2021-06-06T16:24:39.793' AS DateTime))
INSERT [dbo].[CarImages] ([ID], [CarID], [ImagePath], [Date]) VALUES (1003, 2, N'9c47fd6e-3e99-4df7-80fb-a7e6a7fc3ed7.png', CAST(N'2021-06-06T16:24:47.170' AS DateTime))
INSERT [dbo].[CarImages] ([ID], [CarID], [ImagePath], [Date]) VALUES (1004, 6, N'7f1153f6-a78e-4da0-8bf0-6e3fec82395b.png', CAST(N'2021-06-06T16:37:21.563' AS DateTime))
INSERT [dbo].[CarImages] ([ID], [CarID], [ImagePath], [Date]) VALUES (1005, 6, N'40015a73-c64a-409f-bd50-6f3e37ed569f.png', CAST(N'2021-06-06T16:37:27.510' AS DateTime))
INSERT [dbo].[CarImages] ([ID], [CarID], [ImagePath], [Date]) VALUES (1006, 6, N'4aabf543-09aa-4ed9-83bd-3feb9ff61170.png', CAST(N'2021-06-06T16:37:33.387' AS DateTime))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([ID], [BrandID], [ColorID], [LocationID], [Name], [ModelYear], [DailyPrice], [Description]) VALUES (2, 1, 1, 2, N'Egea', 2016, CAST(95.0000 AS Decimal(19, 4)), N'Only for families.')
INSERT [dbo].[Cars] ([ID], [BrandID], [ColorID], [LocationID], [Name], [ModelYear], [DailyPrice], [Description]) VALUES (3, 2, 2, 2, N'Focus', 2018, CAST(110.0000 AS Decimal(19, 4)), N'This vehicle must be returned to the point where it was rented.')
INSERT [dbo].[Cars] ([ID], [BrandID], [ColorID], [LocationID], [Name], [ModelYear], [DailyPrice], [Description]) VALUES (5, 2, 3, 2, N'Mondeo', 2017, CAST(130.9900 AS Decimal(19, 4)), NULL)
INSERT [dbo].[Cars] ([ID], [BrandID], [ColorID], [LocationID], [Name], [ModelYear], [DailyPrice], [Description]) VALUES (6, 1003, 1, 2, N'Megane', 2020, CAST(145.0000 AS Decimal(19, 4)), N'This vehicle can be rented for a minimum of 1 month.')
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([ID], [Name]) VALUES (1, N'İstanbul')
INSERT [dbo].[Cities] ([ID], [Name]) VALUES (2, N'Ankara')
INSERT [dbo].[Cities] ([ID], [Name]) VALUES (3, N'Kayseri')
INSERT [dbo].[Cities] ([ID], [Name]) VALUES (4, N'İzmir')
INSERT [dbo].[Cities] ([ID], [Name]) VALUES (5, N'Antalya')
INSERT [dbo].[Cities] ([ID], [Name]) VALUES (6, N'Bursa')
INSERT [dbo].[Cities] ([ID], [Name]) VALUES (7, N'Hatay')
INSERT [dbo].[Cities] ([ID], [Name]) VALUES (8, N'Mersin')
INSERT [dbo].[Cities] ([ID], [Name]) VALUES (9, N'Gaziantep')
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ID], [Name]) VALUES (1, N'Beyaz')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (2, N'Kırmızı')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (3, N'Yeşil')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (4, N'Siyah')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (7, N'Mavi')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (8, N'Gri')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([ID], [CityID], [Name]) VALUES (1, 1, N'İstanbul Havalimanı')
INSERT [dbo].[Locations] ([ID], [CityID], [Name]) VALUES (2, 2, N'Esenboğa Havalimanı')
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([ID], [Name]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([ID], [UserID], [OperationClaimID]) VALUES (1, 2, 1)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Firstname], [Lastname], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (2, N'Ali', N'Demir', N'a@demir.com', 0x04D065D0142503246C76922A513C271D787D0F2ED9B7B0796C793066898E98BDEE9927028CEFD28F0A19CADDFE6EAB8DFD8488C4EB7448C25649B3C72D0511F6, 0x04EEB139A4781C0D0A54AA0E70540895D80D36ECA5C32D64D874DDFE6033B69306F7CFF139FAF5399CAEFCF676508280894FAC87D6E9AA7DDEB1C0A1664C69DBC62C029C9EF84580A60CD5FF89788F9B826413159914AFE4CF3543A78D4EC7076016F6AC5E2B348E5F9C76B0823A65DA46ED4EBBE938C906B59DB4FF88DCADCA, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  StoredProcedure [dbo].[AvailableCarsByLocation]    Script Date: 6/11/2021 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AvailableCarsByLocation] @LocationID int
AS
select * from Cars where ID not in (select CarID from Rentals where ReturnDate = null) and LocationID = @LocationID
GO
USE [master]
GO
ALTER DATABASE [CarRental] SET  READ_WRITE 
GO
