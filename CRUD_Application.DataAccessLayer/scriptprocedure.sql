USE [master]
GO
/****** Object:  Database [CRUD_Application]    Script Date: 08-Jun-22 11:03:18 PM ******/
CREATE DATABASE [CRUD_Application]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRUD_Application', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSSQLDEV2017\MSSQL\DATA\CRUD_Application.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRUD_Application_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSSQLDEV2017\MSSQL\DATA\CRUD_Application_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CRUD_Application] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRUD_Application].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRUD_Application] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRUD_Application] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRUD_Application] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRUD_Application] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRUD_Application] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRUD_Application] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRUD_Application] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRUD_Application] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRUD_Application] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRUD_Application] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRUD_Application] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRUD_Application] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRUD_Application] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRUD_Application] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRUD_Application] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CRUD_Application] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRUD_Application] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRUD_Application] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRUD_Application] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRUD_Application] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRUD_Application] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRUD_Application] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRUD_Application] SET RECOVERY FULL 
GO
ALTER DATABASE [CRUD_Application] SET  MULTI_USER 
GO
ALTER DATABASE [CRUD_Application] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRUD_Application] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRUD_Application] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRUD_Application] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRUD_Application] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CRUD_Application', N'ON'
GO
ALTER DATABASE [CRUD_Application] SET QUERY_STORE = OFF
GO
USE [CRUD_Application]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08-Jun-22 11:03:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsersDetails]    Script Date: 08-Jun-22 11:03:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsersDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FistName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Mobile] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifyedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyedDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tblUsersDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[USP_RegisterUser]    Script Date: 08-Jun-22 11:03:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- USP_RegisterUser 'vikram','vikram','12341234','vikfram72@gmail.com','1234',0
CREATE PROC [dbo].[USP_RegisterUser]
 @FistName nvarchar(max)
,@LastName nvarchar(max)
,@Mobile nvarchar(max)
,@Email nvarchar(max)
,@Password nvarchar(max),
@id int output
AS
BEGIN
	IF EXISTS(SELECT Id from tblUsersDetails where Email=@Email)
		BEGIN
			set @id=0
		END
	ElSE
		BEGIN
			INSERT INTO [dbo].[tblUsersDetails]
				   ([FistName]
				   ,[LastName]
				   ,[Mobile]
				   ,[Email]
				   ,[Password]
				   ,[CreatedBy]
				   ,[CreatedDate]
				   )
			 VALUES
				   (
				   @FistName,
				   @LastName,
				   @Mobile,
				   @Email,
				   @Password,
				   @Email,
				   GETDATE()
				   )
		END
		set @id= SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateUser]    Script Date: 08-Jun-22 11:03:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_UpdateUser]
 @FistName nvarchar(max)
,@LastName nvarchar(max)
,@Mobile nvarchar(max),
@id int 
AS
BEGIN
	
	UPDATE [dbo].[tblUsersDetails]
	SET [FistName] = @FistName
			,[LastName] = @LastName
			,[Mobile] = @Mobile
			,[ModifyedBy] =@FistName
			,[ModifyedDate] =GETDATE()
	WHERE Id=@id
	
END


GO
USE [master]
GO
ALTER DATABASE [CRUD_Application] SET  READ_WRITE 
GO
