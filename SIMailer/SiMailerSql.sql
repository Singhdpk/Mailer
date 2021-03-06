USE [master]
GO
/****** Object:  Database [dbSIMailer]    Script Date: 22-08-2016 19:22:13 ******/
CREATE DATABASE [dbSIMailer]
 CONTAINMENT = NONE

ALTER DATABASE [dbSIMailer] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSIMailer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbSIMailer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbSIMailer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbSIMailer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbSIMailer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbSIMailer] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbSIMailer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbSIMailer] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [dbSIMailer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbSIMailer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbSIMailer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbSIMailer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbSIMailer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbSIMailer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbSIMailer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbSIMailer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbSIMailer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbSIMailer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbSIMailer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbSIMailer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbSIMailer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbSIMailer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbSIMailer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbSIMailer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbSIMailer] SET RECOVERY FULL 
GO
ALTER DATABASE [dbSIMailer] SET  MULTI_USER 
GO
ALTER DATABASE [dbSIMailer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbSIMailer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbSIMailer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbSIMailer] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [dbSIMailer]
GO
/****** Object:  Table [dbo].[tblAdmin]    Script Date: 22-08-2016 19:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailId] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblAdmin_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMailCategory]    Script Date: 22-08-2016 19:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMailCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblMailCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMails]    Script Date: 22-08-2016 19:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[AdminId] [int] NOT NULL,
 CONSTRAINT [PK_tblMails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPerson]    Script Date: 22-08-2016 19:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_tblPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPersonType]    Script Date: 22-08-2016 19:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPersonType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblPersonType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSendTo]    Script Date: 22-08-2016 19:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSendTo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MailId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[AdminId] [int] NOT NULL,
 CONSTRAINT [PK_tblSendTo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblAdmin] ON 

INSERT [dbo].[tblAdmin] ([Id], [EmailId], [Password]) VALUES (2, N'dpksingh1729@gmail.com', N'12345')
INSERT [dbo].[tblAdmin] ([Id], [EmailId], [Password]) VALUES (3, N'reachakashkool@gmail.com', N'12345')
SET IDENTITY_INSERT [dbo].[tblAdmin] OFF
SET IDENTITY_INSERT [dbo].[tblMailCategory] ON 

INSERT [dbo].[tblMailCategory] ([Id], [Category]) VALUES (6, N'Permissions')
INSERT [dbo].[tblMailCategory] ([Id], [Category]) VALUES (8, N'Formal')
INSERT [dbo].[tblMailCategory] ([Id], [Category]) VALUES (9, N'Informal')
SET IDENTITY_INSERT [dbo].[tblMailCategory] OFF
SET IDENTITY_INSERT [dbo].[tblMails] ON 

INSERT [dbo].[tblMails] ([Id], [CategoryId], [Title], [Subject], [Body], [AdminId]) VALUES (2, 6, N'Demo Title', N'Demo Subject', N'DemoBody', 1)
INSERT [dbo].[tblMails] ([Id], [CategoryId], [Title], [Subject], [Body], [AdminId]) VALUES (3, 8, N'DemoTitle', N'DemoSubject', N'DemoBody', 2)
SET IDENTITY_INSERT [dbo].[tblMails] OFF
SET IDENTITY_INSERT [dbo].[tblPerson] ON 

INSERT [dbo].[tblPerson] ([Id], [EmailId], [Name], [TypeId]) VALUES (10, N'reachakashkool@gmail.com', N'Akash Kool', 12)
INSERT [dbo].[tblPerson] ([Id], [EmailId], [Name], [TypeId]) VALUES (11, N'muditjuneja@gmail.com', N'Mudit Juneja', 13)
SET IDENTITY_INSERT [dbo].[tblPerson] OFF
SET IDENTITY_INSERT [dbo].[tblPersonType] ON 

INSERT [dbo].[tblPersonType] ([Id], [Name]) VALUES (12, N'Student')
INSERT [dbo].[tblPersonType] ([Id], [Name]) VALUES (13, N'Alumni')
INSERT [dbo].[tblPersonType] ([Id], [Name]) VALUES (14, N'Client')
INSERT [dbo].[tblPersonType] ([Id], [Name]) VALUES (15, N'Faculty')
INSERT [dbo].[tblPersonType] ([Id], [Name]) VALUES (16, N'Heads')
INSERT [dbo].[tblPersonType] ([Id], [Name]) VALUES (17, N'HOD')
SET IDENTITY_INSERT [dbo].[tblPersonType] OFF
ALTER TABLE [dbo].[tblMails]  WITH CHECK ADD  CONSTRAINT [FK_tblMails_tblMailCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblMailCategory] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblMails] CHECK CONSTRAINT [FK_tblMails_tblMailCategory]
GO
ALTER TABLE [dbo].[tblPerson]  WITH CHECK ADD  CONSTRAINT [FK_tblPerson_tblPersonType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[tblPersonType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblPerson] CHECK CONSTRAINT [FK_tblPerson_tblPersonType]
GO
ALTER TABLE [dbo].[tblSendTo]  WITH CHECK ADD  CONSTRAINT [FK_tblSendTo_tblMails] FOREIGN KEY([MailId])
REFERENCES [dbo].[tblMails] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblSendTo] CHECK CONSTRAINT [FK_tblSendTo_tblMails]
GO
ALTER TABLE [dbo].[tblSendTo]  WITH CHECK ADD  CONSTRAINT [FK_tblSendTo_tblPerson] FOREIGN KEY([PersonId])
REFERENCES [dbo].[tblPerson] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblSendTo] CHECK CONSTRAINT [FK_tblSendTo_tblPerson]
GO
USE [master]
GO
ALTER DATABASE [dbSIMailer] SET  READ_WRITE 
GO
