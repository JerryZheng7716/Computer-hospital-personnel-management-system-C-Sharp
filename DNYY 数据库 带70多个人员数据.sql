USE [master]
GO
/****** Object:  Database [ComputerHosipital]    Script Date: 12/11/2017 00:49:13 ******/
CREATE DATABASE [ComputerHosipital] ON  PRIMARY 
( NAME = N'ComputerHosipital', FILENAME = N'C:\DB\ComputerHosipital.mdf' , SIZE = 10240KB , MAXSIZE = 20480KB , FILEGROWTH = 2048KB )
 LOG ON 
( NAME = N'ComputerHosipital_log', FILENAME = N'C:\DB\ComputerHosipital_log.ldf' , SIZE = 15360KB , MAXSIZE = 30720KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComputerHosipital] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComputerHosipital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComputerHosipital] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ComputerHosipital] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ComputerHosipital] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ComputerHosipital] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ComputerHosipital] SET ARITHABORT OFF
GO
ALTER DATABASE [ComputerHosipital] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ComputerHosipital] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ComputerHosipital] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ComputerHosipital] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ComputerHosipital] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ComputerHosipital] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ComputerHosipital] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ComputerHosipital] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ComputerHosipital] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ComputerHosipital] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ComputerHosipital] SET  ENABLE_BROKER
GO
ALTER DATABASE [ComputerHosipital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ComputerHosipital] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ComputerHosipital] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ComputerHosipital] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ComputerHosipital] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ComputerHosipital] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ComputerHosipital] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ComputerHosipital] SET  READ_WRITE
GO
ALTER DATABASE [ComputerHosipital] SET RECOVERY FULL
GO
ALTER DATABASE [ComputerHosipital] SET  MULTI_USER
GO
ALTER DATABASE [ComputerHosipital] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ComputerHosipital] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ComputerHosipital', N'ON'
GO
USE [ComputerHosipital]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 12/11/2017 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[departNo] [char](2) NOT NULL,
	[departName] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[departNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Department] ([departNo], [departName]) VALUES (N'1 ', N'实训科')
INSERT [dbo].[Department] ([departNo], [departName]) VALUES (N'2 ', N'人事科')
INSERT [dbo].[Department] ([departNo], [departName]) VALUES (N'3 ', N'新闻科')
INSERT [dbo].[Department] ([departNo], [departName]) VALUES (N'4 ', N'外联科')
INSERT [dbo].[Department] ([departNo], [departName]) VALUES (N'5 ', N'外宣科')
INSERT [dbo].[Department] ([departNo], [departName]) VALUES (N'6 ', N'总裁室')
/****** Object:  Table [dbo].[Admin]    Script Date: 12/11/2017 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[adminName] [varchar](20) NOT NULL,
	[pwd] [varchar](40) NOT NULL,
	[changeStuPower] [bit] NOT NULL,
	[isSuperAdmin] [bit] NOT NULL,
 CONSTRAINT [PK__Admin__330679FF1367E606] PRIMARY KEY CLUSTERED 
(
	[adminName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Admin] ([adminName], [pwd], [changeStuPower], [isSuperAdmin]) VALUES (N'1', N'356A192B7913B04C54574D18C28D46E6395428AB', 1, 1)
INSERT [dbo].[Admin] ([adminName], [pwd], [changeStuPower], [isSuperAdmin]) VALUES (N'hxn', N'0DDB5877C896F43E8734E10B001E7F1EB92889CD', 1, 1)
INSERT [dbo].[Admin] ([adminName], [pwd], [changeStuPower], [isSuperAdmin]) VALUES (N'螺栓', N'356A192B7913B04C54574D18C28D46E6395428AB', 1, 0)
INSERT [dbo].[Admin] ([adminName], [pwd], [changeStuPower], [isSuperAdmin]) VALUES (N'小鱼', N'7B52009B64FD0A2A49E6D8A939753077792B0554', 0, 0)
INSERT [dbo].[Admin] ([adminName], [pwd], [changeStuPower], [isSuperAdmin]) VALUES (N'郑健磊', N'356A192B7913B04C54574D18C28D46E6395428AB', 1, 0)
/****** Object:  Table [dbo].[Student]    Script Date: 12/11/2017 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[stuNo] [varchar](50) NOT NULL,
	[stuName] [varchar](50) NOT NULL,
	[departNo] [char](2) NOT NULL,
	[post] [varchar](50) NOT NULL,
	[class] [varchar](20) NOT NULL,
	[sex] [char](2) NOT NULL,
	[birthday] [date] NOT NULL,
	[enjoyDate] [date] NOT NULL,
	[contactWay] [varchar](100) NOT NULL,
	[isWorking] [bit] NOT NULL,
 CONSTRAINT [PK__Student__AEC9536003317E3D] PRIMARY KEY CLUSTERED 
(
	[stuNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219201213', N'郑健磊', N'6 ', N'副会长', N'15计算机本1', N'女', CAST(0x751F0B00 AS Date), CAST(0x9F3D0B00 AS Date), N'TEL:13968869792', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219201214', N'余豪士', N'1 ', N'干事', N'15计算机本1', N'男', CAST(0x531E0B00 AS Date), CAST(0x9F3D0B00 AS Date), N'12345678', 0)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219201215', N'螺栓', N'3 ', N'干事', N'15计算机本1', N'女', CAST(0x521E0B00 AS Date), CAST(0x9F3D0B00 AS Date), N'12345678', 0)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210000', N'袁浩杰', N'6 ', N'会长', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210002', N'何孙杰', N'6 ', N'副会长', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210003', N'陈春晖', N'6 ', N'副会长', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210004', N'戴文浩', N'2 ', N'科长', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210005', N'何铮铮', N'2 ', N'副科长', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210006', N'黄莉情', N'2 ', N'副科长', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210007', N'钱璐晔', N'2 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210008', N'杨雅雯', N'2 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210009', N'陈仕立', N'2 ', N'干事', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210010', N'林瑞东', N'2 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210011', N'俞杰强', N'2 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210012', N'严思奇', N'2 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210013', N'卓炜豪', N'1 ', N'科长', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210014', N'李传锴', N'1 ', N'副科长', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210015', N'倪浩轩', N'1 ', N'副科长', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210016', N'叶方超', N'1 ', N'副科长', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210017', N'沈珈羽', N'1 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210018', N'兰轩', N'1 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210019', N'胡斯宇', N'1 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210020', N'闵家驹', N'1 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210021', N'蔡乐欣', N'1 ', N'干事', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210022', N'杨子慧', N'1 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210023', N'王烨锋', N'1 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210024', N'许振忠', N'1 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210025', N'施文强', N'1 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210026', N'王鑫洋', N'1 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210027', N'洪路博', N'1 ', N'干事', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210028', N'陈俊安', N'1 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210029', N'何瑜媚', N'1 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210030', N'詹德威', N'1 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210031', N'钱润远', N'1 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210032', N'黄国炯', N'1 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210033', N'赵心怡', N'1 ', N'干事', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210034', N'冯靖雯', N'1 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210035', N'文一理', N'1 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210036', N'王盛纬', N'1 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210037', N'杨恒溢', N'1 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210038', N'詹德寅', N'1 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210039', N'叶克源', N'1 ', N'干事', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210040', N'俞明睿', N'1 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210041', N'王昊', N'1 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210042', N'汪帅', N'1 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210043', N'陈明', N'3 ', N'科长', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210044', N'朱慧玲', N'3 ', N'副科长', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210045', N'章虞立', N'3 ', N'副科长', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210046', N'张洁', N'3 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210047', N'李静捷', N'3 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210048', N'何涔阳', N'3 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210049', N'严宇航', N'3 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210050', N'林雨露', N'3 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210051', N'姜文育', N'4 ', N'科长', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210052', N'徐诗琪', N'4 ', N'副科长', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210053', N'宋兴豪', N'4 ', N'副科长', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210054', N'王雨婷', N'4 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210055', N'王稼禾', N'4 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210056', N'汤丁威', N'4 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210057', N'黄虹斌', N'4 ', N'干事', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210058', N'陈序格', N'4 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210059', N'应臣威', N'4 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210060', N'叶婷婷', N'5 ', N'科长', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210061', N'王芸芸', N'5 ', N'副科长', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210062', N'陈瑞', N'5 ', N'副科长', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210063', N'黄紫阳', N'5 ', N'干事', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210064', N'毛庆澜', N'5 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210065', N'洪慧', N'5 ', N'干事', N'15电气本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210066', N'孙奕惠', N'5 ', N'干事', N'17计专1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210067', N'陈轩浩', N'5 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210068', N'朱梓墨', N'5 ', N'干事', N'15计本1', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210069', N'谢诚杰', N'5 ', N'干事', N'16审计本1', N'女', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
INSERT [dbo].[Student] ([stuNo], [stuName], [departNo], [post], [class], [sex], [birthday], [enjoyDate], [contactWay], [isWorking]) VALUES (N'15219210070', N'吴成昊', N'5 ', N'干事', N'17管理本2', N'男', CAST(0xAB1F0B00 AS Date), CAST(0x493C0B00 AS Date), N'12331241', 1)
/****** Object:  Table [dbo].[Activity]    Script Date: 12/11/2017 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Activity](
	[acId] [int] IDENTITY(1,1) NOT NULL,
	[acName] [varchar](40) NOT NULL,
	[acPlace] [varchar](40) NOT NULL,
	[acTime] [date] NOT NULL,
	[stuNo] [varchar](50) NULL,
	[mark] [varchar](100) NULL,
 CONSTRAINT [PK__Activity__57F81DD108EA5793] PRIMARY KEY CLUSTERED 
(
	[acId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Activity] ON
INSERT [dbo].[Activity] ([acId], [acName], [acPlace], [acTime], [stuNo], [mark]) VALUES (4, N'12', N'2313', CAST(0xA03D0B00 AS Date), N'15219201214', N'1221')
INSERT [dbo].[Activity] ([acId], [acName], [acPlace], [acTime], [stuNo], [mark]) VALUES (5, N'实训开课', N'2-219', CAST(0x893D0B00 AS Date), N'15219201215', N'18：30-20：00')
INSERT [dbo].[Activity] ([acId], [acName], [acPlace], [acTime], [stuNo], [mark]) VALUES (6, N'2', N'2', CAST(0xA03D0B00 AS Date), N'15219201213', N'')
INSERT [dbo].[Activity] ([acId], [acName], [acPlace], [acTime], [stuNo], [mark]) VALUES (7, N'lll', N'D区', CAST(0xA03D0B00 AS Date), N'15219201214', N'kkk')
SET IDENTITY_INSERT [dbo].[Activity] OFF
/****** Object:  Table [dbo].[Attendance]    Script Date: 12/11/2017 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attendance](
	[atId] [int] IDENTITY(1,1) NOT NULL,
	[stuNo] [varchar](50) NOT NULL,
	[acid] [int] NOT NULL,
	[atTime] [int] NULL,
	[notAcTime] [int] NULL,
	[laterTime] [int] NULL,
	[mark] [varchar](100) NULL,
 CONSTRAINT [PK__Attendan__5B38D4C10DAF0CB0] PRIMARY KEY CLUSTERED 
(
	[atId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Attendance] ON
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (1, N'15219201213', 5, 1, 0, 2, N'21331')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (2, N'15219201214', 6, 1, 0, 2, N'21331')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (3, N'15219201215', 5, 1, 0, 2, N'21331')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (4, N'15219201213', 5, 12, 0, 0, N'')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (5, N'15219201214', 5, 12, 0, 0, N'')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (6, N'15219201215', 5, 12, 0, 0, N'')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (7, N'15219201213', 4, 233, 3, 2, N'423')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (8, N'15219201213', 6, 1, 0, 2, N'21331')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (9, N'15219201214', 6, 1, 0, 2, N'21331')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (10, N'15219201213', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (11, N'15219201214', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (12, N'15219201215', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (13, N'15219210000', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (14, N'15219210002', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (15, N'15219210003', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (16, N'15219210004', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (17, N'15219210005', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (18, N'15219210006', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (19, N'15219210007', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (20, N'15219210008', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (21, N'15219210009', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (22, N'15219210010', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (23, N'15219210011', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (24, N'15219210012', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (25, N'15219210013', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (26, N'15219210014', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (27, N'15219210015', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (28, N'15219210016', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (29, N'15219210017', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (30, N'15219210018', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (31, N'15219210019', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (32, N'15219210020', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (33, N'15219210021', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (34, N'15219210022', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (35, N'15219210023', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (36, N'15219210024', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (37, N'15219210025', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (38, N'15219210026', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (39, N'15219210027', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (40, N'15219210028', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (41, N'15219210029', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (42, N'15219210030', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (43, N'15219210031', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (44, N'15219210032', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (45, N'15219210033', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (46, N'15219210034', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (47, N'15219210035', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (48, N'15219210036', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (49, N'15219210037', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (50, N'15219210038', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (51, N'15219210039', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (52, N'15219210040', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (53, N'15219210041', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (54, N'15219210042', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (55, N'15219210044', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (56, N'15219210045', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (57, N'15219210046', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (58, N'15219210047', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (59, N'15219210048', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (60, N'15219210049', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (61, N'15219210050', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (62, N'15219210051', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (63, N'15219210052', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (64, N'15219210053', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (65, N'15219210054', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (66, N'15219210055', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (67, N'15219210056', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (68, N'15219210057', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (69, N'15219210058', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (70, N'15219210059', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (71, N'15219210060', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (72, N'15219210061', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (73, N'15219210063', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (74, N'15219210064', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (75, N'15219210065', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (76, N'15219210066', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (77, N'15219210067', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (78, N'15219210068', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (79, N'15219210069', 5, 2, 1, 1, N'测试数据')
INSERT [dbo].[Attendance] ([atId], [stuNo], [acid], [atTime], [notAcTime], [laterTime], [mark]) VALUES (80, N'15219210070', 5, 2, 1, 1, N'测试数据')
SET IDENTITY_INSERT [dbo].[Attendance] OFF
/****** Object:  Default [df_t1_id1]    Script Date: 12/11/2017 00:49:14 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [df_t1_id1]  DEFAULT ((1)) FOR [isWorking]
GO
/****** Object:  Check [Ck_Sex]    Script Date: 12/11/2017 00:49:14 ******/
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [Ck_Sex] CHECK  (([sex]='女' OR [sex]='男'))
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [Ck_Sex]
GO
/****** Object:  ForeignKey [Fk_Student_Department]    Script Date: 12/11/2017 00:49:14 ******/
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [Fk_Student_Department] FOREIGN KEY([departNo])
REFERENCES [dbo].[Department] ([departNo])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [Fk_Student_Department]
GO
/****** Object:  ForeignKey [Fk_Activity_Student]    Script Date: 12/11/2017 00:49:14 ******/
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [Fk_Activity_Student] FOREIGN KEY([stuNo])
REFERENCES [dbo].[Student] ([stuNo])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [Fk_Activity_Student]
GO
/****** Object:  ForeignKey [Fk_Attendance_Activity]    Script Date: 12/11/2017 00:49:14 ******/
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [Fk_Attendance_Activity] FOREIGN KEY([acid])
REFERENCES [dbo].[Activity] ([acId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [Fk_Attendance_Activity]
GO
/****** Object:  ForeignKey [Fk_Attendance_Student]    Script Date: 12/11/2017 00:49:14 ******/
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [Fk_Attendance_Student] FOREIGN KEY([stuNo])
REFERENCES [dbo].[Student] ([stuNo])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [Fk_Attendance_Student]
GO
