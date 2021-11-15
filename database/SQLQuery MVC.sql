--Create database 
USE [newdb]
GO

/****** Object:  Table [dbo].[emptable]    Script Date: 15-11-2021 11:12:41 ******/
DROP TABLE [dbo].[emptable]
GO

/****** Object:  Table [dbo].[emptable]    Script Date: 15-11-2021 11:12:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[emptable](
	[Empid] [int] IDENTITY(1,1) NOT NULL,
	[Empname] [varchar](50) NULL,
	[salary] [int] NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_emptable] PRIMARY KEY CLUSTERED 
(
	[Empid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


--stored procedure for add and edit
USE [newdb]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeAddOrEdit]    Script Date: 14-11-2021 13:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[EmployeeAddOrEdit]
@Empid int,
@Empname varchar(50),
@salary int,
@Email varchar(50)
AS

     IF @Empid=0
	   INSERT INTO emptable(Empname,salary,Email)
	   VALUES (@Empname,@salary,@Email)
	ELSE
	  UPDATE emptable
	  SET
	  Empname=@Empname,
	  salary=@salary,
	  Email=@Email
	  wHERE Empid=@Empid


-- stored procedure for deletebyid
USE [newdb]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeDeleteByID]    Script Date: 15-11-2021 11:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[EmployeeDeleteByID]
@Empid int
AS
DELETE FROM emptable
WHERE Empid=@Empid

--stored procedure for viewall
USE [newdb]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeViewAll]    Script Date: 15-11-2021 11:18:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[EmployeeViewAll]
AS
SELECT *
FROM emptable

--stored procedure for viewbyid
USE [newdb]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeViewByID]    Script Date: 15-11-2021 11:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[EmployeeViewByID]
@Empid int
AS
SELECT * 
FROM emptable
WHERE Empid=@Empid
