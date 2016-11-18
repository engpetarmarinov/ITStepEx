USE [master]
GO
/****** Object:  Database [FootballLeague]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
CREATE DATABASE [FootballLeague]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FootballLeague', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FootballLeague.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FootballLeague_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FootballLeague_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FootballLeague] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FootballLeague].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FootballLeague] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FootballLeague] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FootballLeague] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FootballLeague] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FootballLeague] SET ARITHABORT OFF 
GO
ALTER DATABASE [FootballLeague] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FootballLeague] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FootballLeague] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FootballLeague] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FootballLeague] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FootballLeague] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FootballLeague] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FootballLeague] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FootballLeague] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FootballLeague] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FootballLeague] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FootballLeague] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FootballLeague] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FootballLeague] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FootballLeague] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FootballLeague] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FootballLeague] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FootballLeague] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FootballLeague] SET  MULTI_USER 
GO
ALTER DATABASE [FootballLeague] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FootballLeague] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FootballLeague] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FootballLeague] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FootballLeague]
GO
/****** Object:  Schema [Championship]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
CREATE SCHEMA [Championship]
GO
/****** Object:  Schema [Club]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
CREATE SCHEMA [Club]
GO
/****** Object:  Schema [Division]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
CREATE SCHEMA [Division]
GO
/****** Object:  Table [Championship].[Divisions]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Championship].[Divisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Championship].[Referees]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Championship].[Referees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Club].[Managers]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Club].[Managers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ClubId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Club].[Players]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Club].[Players](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Salary] [int] NULL,
	[ClubId] [int] NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Division].[Clubs]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Division].[Clubs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DivisionId] [int] NULL,
 CONSTRAINT [PK_Clubs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Division].[Matches]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Division].[Matches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HomeClubId] [int] NOT NULL,
	[GuestClubId] [int] NOT NULL,
	[StartDate] [smalldatetime] NOT NULL,
	[HomeGoals] [smallint] NULL,
	[GuestGoals] [smallint] NULL,
	[FinalSign] [char](1) NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Division].[MatchScorers]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Division].[MatchScorers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[PlayerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Club].[Managers]  WITH CHECK ADD  CONSTRAINT [FK__Managers__ClubId__276EDEB3] FOREIGN KEY([ClubId])
REFERENCES [Division].[Clubs] ([Id])
GO
ALTER TABLE [Club].[Managers] CHECK CONSTRAINT [FK__Managers__ClubId__276EDEB3]
GO
ALTER TABLE [Club].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Clubs] FOREIGN KEY([ClubId])
REFERENCES [Division].[Clubs] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Club].[Players] CHECK CONSTRAINT [FK_Players_Clubs]
GO
ALTER TABLE [Division].[Clubs]  WITH CHECK ADD  CONSTRAINT [FK_Clubs_Clubs] FOREIGN KEY([DivisionId])
REFERENCES [Championship].[Divisions] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Division].[Clubs] CHECK CONSTRAINT [FK_Clubs_Clubs]
GO
ALTER TABLE [Division].[Matches]  WITH CHECK ADD  CONSTRAINT [FK__Matches__GuestCl__31EC6D26] FOREIGN KEY([GuestClubId])
REFERENCES [Division].[Clubs] ([Id])
GO
ALTER TABLE [Division].[Matches] CHECK CONSTRAINT [FK__Matches__GuestCl__31EC6D26]
GO
ALTER TABLE [Division].[Matches]  WITH CHECK ADD  CONSTRAINT [FK__Matches__HomeClu__30F848ED] FOREIGN KEY([HomeClubId])
REFERENCES [Division].[Clubs] ([Id])
GO
ALTER TABLE [Division].[Matches] CHECK CONSTRAINT [FK__Matches__HomeClu__30F848ED]
GO
ALTER TABLE [Division].[MatchScorers]  WITH CHECK ADD FOREIGN KEY([PlayerId])
REFERENCES [Club].[Players] ([Id])
GO
/****** Object:  StoredProcedure [Club].[GetPoints]    Script Date: 18.11.2016 г. 17:45:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Club].[GetPoints](@date smalldatetime)

AS
BEGIN

	SELECT c.Id, c.Name,
	 -- WINS
	 SUM(CASE WHEN 		
			(m.HomeGoals > m.GuestGoals AND c.Id = m.HomeClubId) -- HOME WIN!
			OR 		
			(m.GuestGoals > m.HomeGoals AND c.Id = m.GuestClubId) -- GUEST WIN!
		THEN 1 ELSE 0 
		END) as 'Wins',
	 -- Draws
	 SUM(
		CASE WHEN 
			m.HomeGoals = m.GuestGoals
		THEN 1 ELSE 0 
		END) as 'Draws',
	-- LOSES
	 SUM(
		CASE WHEN 
			(m.HomeGoals > m.GuestGoals AND c.Id = m.GuestClubId)
			OR 
			(m.GuestGoals > m.HomeGoals AND c.Id = m.HomeClubId)
		THEN 1 ELSE 0 
		END) as 'Loses',
	 COUNT(*) as 'All',
	 -- Points
	 SUM(
		CASE WHEN 
			(m.HomeGoals > m.GuestGoals AND c.Id = m.HomeClubId) -- HOME WIN!
			OR 
			(m.GuestGoals > m.HomeGoals AND c.Id = m.GuestClubId) -- GUEST WIN!
		THEN 3 ELSE 0 
		END)
	 +
	 SUM(
		CASE WHEN 
			m.HomeGoals = m.GuestGoals
		THEN 1 ELSE 0 
		END) as 'Points'

	 FROM Division.Matches AS m
	 JOIN Division.Clubs AS c ON (c.Id = m.HomeClubId OR c.Id = m.GuestClubId)
	 WHERE StartDate < @date
	 GROUP BY c.Name, c.Id
	 ORDER BY Wins DESC, Draws DESC, Name

END
GO
USE [master]
GO
ALTER DATABASE [FootballLeague] SET  READ_WRITE 
GO
