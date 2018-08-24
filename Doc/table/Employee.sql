USE [AHCMS]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 24-08-2018 18:28:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [nvarchar](128) NOT NULL,
	[ReffNo] [nvarchar](20) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL,
	[EmailConfirmed] [bit] NULL,
	[CountryCode] [nvarchar](5) NULL,
	[PhoneNumber] [bigint] NULL,
	[PhoneNumberConfirmed] [bit] NULL,
	[LockOutEnabled] [bit] NULL,
	[LockOutDate] [datetime] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NULL,
	[Street] [nvarchar](200) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](10) NULL,
	[Img] [nvarchar](max) NULL,
	[BloodGroup] [nchar](5) NULL,
	[Gender] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


