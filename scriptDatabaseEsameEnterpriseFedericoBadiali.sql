USE [master]
GO
/****** Object:  Database [Paradigmi]    Script Date: 01/12/2024 18:13:24 ******/
CREATE DATABASE [Paradigmi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Paradigmi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Paradigmi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Paradigmi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Paradigmi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Paradigmi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Paradigmi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Paradigmi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Paradigmi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Paradigmi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Paradigmi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Paradigmi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Paradigmi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Paradigmi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Paradigmi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Paradigmi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Paradigmi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Paradigmi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Paradigmi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Paradigmi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Paradigmi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Paradigmi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Paradigmi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Paradigmi] SET RECOVERY FULL 
GO
ALTER DATABASE [Paradigmi] SET  MULTI_USER 
GO
ALTER DATABASE [Paradigmi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Paradigmi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Paradigmi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Paradigmi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Paradigmi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Paradigmi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Paradigmi', N'ON'
GO
ALTER DATABASE [Paradigmi] SET QUERY_STORE = ON
GO
ALTER DATABASE [Paradigmi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Paradigmi]
GO
/****** Object:  User [Paradigmi]    Script Date: 01/12/2024 18:13:24 ******/
CREATE USER [Paradigmi] FOR LOGIN [Paradigmi] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Paradigmi]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 01/12/2024 18:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NomeCategoria] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Categorie] UNIQUE NONCLUSTERED 
(
	[NomeCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategorieLibro]    Script Date: 01/12/2024 18:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorieLibro](
	[IdLibro] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libri]    Script Date: 01/12/2024 18:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libri](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nchar](50) NOT NULL,
	[Autore] [nchar](50) NOT NULL,
	[DataDiPubblicazione] [date] NULL,
	[Editore] [nchar](50) NULL,
 CONSTRAINT [PK_Libri_2] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libri2]    Script Date: 01/12/2024 18:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libri2](
	[Nome] [nchar](40) NOT NULL,
	[Autore] [nchar](40) NOT NULL,
	[DataDiPubblicazione] [date] NULL,
	[Editore] [nchar](50) NULL,
 CONSTRAINT [PK_Libri] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[testtestunique]    Script Date: 01/12/2024 18:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[testtestunique](
	[ID] [int] NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[Age] [int] NULL,
UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 01/12/2024 18:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[IdUtente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nchar](20) NULL,
	[Cognome] [nchar](30) NULL,
	[Email] [nchar](50) NULL,
	[Password] [nchar](30) NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Utenti]    Script Date: 01/12/2024 18:13:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Utenti] ON [dbo].[Utenti]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CategorieLibro]  WITH CHECK ADD  CONSTRAINT [FK_CategorieLibro_Categorie] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorie] ([IdCategoria])
GO
ALTER TABLE [dbo].[CategorieLibro] CHECK CONSTRAINT [FK_CategorieLibro_Categorie]
GO
ALTER TABLE [dbo].[CategorieLibro]  WITH CHECK ADD  CONSTRAINT [FK_CategorieLibro_Libri] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[Libri] ([IdLibro])
GO
ALTER TABLE [dbo].[CategorieLibro] CHECK CONSTRAINT [FK_CategorieLibro_Libri]
GO
USE [master]
GO
ALTER DATABASE [Paradigmi] SET  READ_WRITE 
GO
