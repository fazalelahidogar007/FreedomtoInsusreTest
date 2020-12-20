CREATE DATABASE [freedomtoinsure]
USE [freedomtoinsure]
GO

/****** Object:  Table [dbo].[UserDetails]    Script Date: 20/12/2020 19:39:13 ******/
DROP TABLE [dbo].[UserDetails]
GO

/****** Object:  Table [dbo].[UserDetails]    Script Date: 20/12/2020 19:39:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserDetails](
	[UserDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL
) ON [PRIMARY]
GO

