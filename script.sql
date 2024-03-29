USE [master]
GO
/****** Object:  Database [stoktakip]    Script Date: 1.05.2018 23:24:40 ******/
CREATE DATABASE [stoktakip]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'stoktakip', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\stoktakip.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'stoktakip_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\stoktakip_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [stoktakip] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [stoktakip].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [stoktakip] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [stoktakip] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [stoktakip] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [stoktakip] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [stoktakip] SET ARITHABORT OFF 
GO
ALTER DATABASE [stoktakip] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [stoktakip] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [stoktakip] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [stoktakip] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [stoktakip] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [stoktakip] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [stoktakip] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [stoktakip] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [stoktakip] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [stoktakip] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [stoktakip] SET  ENABLE_BROKER 
GO
ALTER DATABASE [stoktakip] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [stoktakip] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [stoktakip] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [stoktakip] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [stoktakip] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [stoktakip] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [stoktakip] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [stoktakip] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [stoktakip] SET  MULTI_USER 
GO
ALTER DATABASE [stoktakip] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [stoktakip] SET DB_CHAINING OFF 
GO
ALTER DATABASE [stoktakip] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [stoktakip] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [stoktakip]
GO
/****** Object:  Table [dbo].[kategori]    Script Date: 1.05.2018 23:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kategori](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kategori_adi] [varchar](50) NULL,
 CONSTRAINT [PK_kategori] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kullanici]    Script Date: 1.05.2018 23:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kullanici](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adsoyad] [varchar](max) NOT NULL,
	[kullanici_adi] [varchar](max) NOT NULL,
	[kullanici_sifre] [varchar](max) NOT NULL,
 CONSTRAINT [PK_kullanici] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[urun]    Script Date: 1.05.2018 23:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[urun](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullanici_id] [int] NULL,
	[kategori_id] [int] NULL,
	[urun_adi] [nvarchar](max) NOT NULL,
	[urun_kodu] [varchar](max) NOT NULL,
	[urun_adet] [int] NOT NULL,
	[fiyat] [float] NOT NULL,
	[tarih] [datetime] NULL,
 CONSTRAINT [PK_urun] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[kategori] ON 

INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (1, N'Kuru Gida')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (2, N'Sarküteri ve Kahvaltilik Ürünler')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (3, N'Kagit Ürünleri')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (4, N'Et & Et Ürünleri')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (5, N'Süt & Süt Ürünleri')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (6, N'Meyve & Sebze')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (7, N'Içecek')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (8, N'Kozmetik & Kisisel Bakim')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (9, N'Temizlik Ürünleri')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (10, N'Ofis & Kirtasiye')
INSERT [dbo].[kategori] ([id], [kategori_adi]) VALUES (11, N'Atistirmalik Ürünler ve Unlu Mamüller')
SET IDENTITY_INSERT [dbo].[kategori] OFF
SET IDENTITY_INSERT [dbo].[kullanici] ON 

INSERT [dbo].[kullanici] ([id], [adsoyad], [kullanici_adi], [kullanici_sifre]) VALUES (1, N'ömer faruk dilek', N'omer', N'123')
INSERT [dbo].[kullanici] ([id], [adsoyad], [kullanici_adi], [kullanici_sifre]) VALUES (2, N'ilyas saglam', N'ilyas', N'1234')
SET IDENTITY_INSERT [dbo].[kullanici] OFF
SET IDENTITY_INSERT [dbo].[urun] ON 

INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (31, 1, 11, N'Eti Canga', N'2165', 100, 1, CAST(0x0000A8AE00000000 AS DateTime))
INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (46, 1, 7, N'Coca Cola (2,5lt)', N'7889', 1289, 4, CAST(0x0000A8D300000000 AS DateTime))
INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (47, 1, 7, N'Lipton Ice Tea Limon (330ml)', N'2035', 7784, 2, CAST(0x0000A8D300000000 AS DateTime))
INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (48, 1, 11, N'Biskrem', N'5200', 9080, 1, CAST(0x0000A8D300000000 AS DateTime))
INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (49, 1, 5, N'Pınar Süt (1lt)', N'2698', 8961, 3, CAST(0x0000A8D300000000 AS DateTime))
INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (53, 1, 8, N'Nivea Yüz Temizleme Jeli', N'5496', 482, 11, CAST(0x0000A8D300000000 AS DateTime))
INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (54, 2, 9, N'Ariel Toz Çamaşır Deterjanı(9KG)', N'9854', 142, 89, CAST(0x0000A8D300000000 AS DateTime))
INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (55, 2, 1, N'Torku Küp Şeker (1000gr)', N'2479', 78, 6, CAST(0x0000A8D300000000 AS DateTime))
INSERT [dbo].[urun] ([id], [kullanici_id], [kategori_id], [urun_adi], [urun_kodu], [urun_adet], [fiyat], [tarih]) VALUES (57, 1, 2, N'Dil Peyniri (250gr)', N'88', 100, 9.8, CAST(0x0000A8D300000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[urun] OFF
USE [master]
GO
ALTER DATABASE [stoktakip] SET  READ_WRITE 
GO
