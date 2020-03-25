USE [master]
GO
/****** Object:  Database [IssueTracker]    Script Date: 3/25/2020 11:22:01 AM ******/
CREATE DATABASE [IssueTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IssueTracker] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IssueTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IssueTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IssueTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IssueTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IssueTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IssueTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [IssueTracker] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [IssueTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IssueTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IssueTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IssueTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IssueTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IssueTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IssueTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IssueTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IssueTracker] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IssueTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IssueTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IssueTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IssueTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IssueTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IssueTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IssueTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IssueTracker] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IssueTracker] SET  MULTI_USER 
GO
ALTER DATABASE [IssueTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IssueTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IssueTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IssueTracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IssueTracker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IssueTracker] SET QUERY_STORE = OFF
GO
USE [IssueTracker]
GO
/****** Object:  Table [dbo].[Assignee]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_issue] [int] NOT NULL,
	[Id_person] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Issue]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Issue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](1024) NULL,
	[CreationDate] [datetime] NULL,
	[Id_status] [int] NOT NULL,
	[Id_severity] [int] NOT NULL,
	[Id_author] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Severity]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Severity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeverityName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assignee]  WITH CHECK ADD FOREIGN KEY([Id_issue])
REFERENCES [dbo].[Issue] ([Id])
GO
ALTER TABLE [dbo].[Assignee]  WITH CHECK ADD FOREIGN KEY([Id_person])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD FOREIGN KEY([Id_author])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD FOREIGN KEY([Id_severity])
REFERENCES [dbo].[Severity] ([Id])
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD FOREIGN KEY([Id_status])
REFERENCES [dbo].[Status] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[spAssignee_Insert]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[spAssignee_Insert]

	@Id_issue int,
	@Id_person int,

	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

    insert into dbo.Assignee(Id_issue, Id_person) 
				 values (@Id_issue, @Id_person);

	select @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spAssignees_GetByIssue]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[spAssignees_GetByIssue]
	@PersonId int
AS
BEGIN
	SET NOCOUNT ON;

    select Distinct P.* from dbo.Person P, dbo.Issue I, dbo.Assignee A WHERE A.Id_issue = @PersonId AND A.Id_person = P.Id;
END

GO
/****** Object:  StoredProcedure [dbo].[spIssue_GetAll]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[spIssue_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

    select I.id, I.Title, I.Description, I.CreationDate from dbo.Issue I
END
GO
/****** Object:  StoredProcedure [dbo].[spIssue_Insert]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[spIssue_Insert]
	@Title nvarchar(255),
	@Description nvarchar(1024),
	@CreationDate datetime,
	@Id_status int = 1,
	@Id_severity int,
	@Id_author int,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

    insert into dbo.Issue (Title, Description, CreationDate, Id_status, Id_severity, Id_author) 
				 values (@Title, @Description, @CreationDate, @Id_status, @Id_severity, @Id_author);

	select @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spIssue_Update]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[spIssue_Update]
	@Id int,
	@Title nvarchar(255),
	@Description nvarchar(1024),
	@CreationDate datetime,
	@Id_status int,
	@Id_severity int,
	@Id_author int
AS
BEGIN
	SET NOCOUNT ON;

	update dbo.Issue 
		set Title = @Title, 
			Description = @Description, 
			CreationDate = @CreationDate, 
			Id_status = @Id_status, 
			Id_severity = @Id_severity, 
			Id_author = @Id_author
		where  Issue.Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[spPerson_Authenticate]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create         PROCEDURE [dbo].[spPerson_Authenticate]
	@login nvarchar(255),
	@password nvarchar(255),
	@output bit
AS
BEGIN
	SET NOCOUNT ON;

	If Exists 
		(Select 1 From Person Where Login = @login AND Password = @password) 
			Set @output = 1
    Else Set @output = 0

    Select @output
END

GO
/****** Object:  StoredProcedure [dbo].[spPerson_GetAll]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spPerson_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

    select * from dbo.Person;
END
GO
/****** Object:  StoredProcedure [dbo].[spPerson_GetByIssue]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[spPerson_GetByIssue]
	@PersonId int
AS
BEGIN
	SET NOCOUNT ON;

    select DISTINCT P.* from dbo.Person P, dbo.Issue I WHERE I.Id = @PersonId AND I.Id_author = P.id;
END

GO
/****** Object:  StoredProcedure [dbo].[spPerson_GetByLogin]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[spPerson_GetByLogin]
	@Login nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    select DISTINCT * from dbo.Person WHERE Person.Login = @Login;
END

GO
/****** Object:  StoredProcedure [dbo].[spPerson_Insert]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[spPerson_Insert]
	@Login nvarchar(255),
	@Password nvarchar(1024),
	@Email varchar(320),
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

    insert into dbo.Person (Login, Password, Email) 
				 values (@Login, @Password, @Email);

	select @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spSeverity_GetAll]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[spSeverity_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

    select * from dbo.Severity;
END
GO
/****** Object:  StoredProcedure [dbo].[spSeverity_GetByIssue]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[spSeverity_GetByIssue]
	@SeverityId int
AS
BEGIN
	SET NOCOUNT ON;

    select S.id, S.SeverityName from dbo.Issue I, dbo.Severity S WHERE I.Id = @SeverityId AND I.Id_severity = S.Id;
END





GO
/****** Object:  StoredProcedure [dbo].[spStatus_GetAll]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[spStatus_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

    select * from dbo.Status;
END
GO
/****** Object:  StoredProcedure [dbo].[spStatus_GetByIssue]    Script Date: 3/25/2020 11:22:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       PROCEDURE [dbo].[spStatus_GetByIssue]
	@StatusId int
AS
BEGIN
	SET NOCOUNT ON;

        select S.id, S.StatusName from dbo.Issue I, dbo.Status S WHERE I.Id = @StatusId AND I.Id_status = S.Id;
END
GO
USE [master]
GO
ALTER DATABASE [IssueTracker] SET  READ_WRITE 
GO
