USE [AHCMS]
GO

/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 24-08-2018 18:28:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeRole](
	[EmployeeRoleId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](128) NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_EmployeeRole] PRIMARY KEY CLUSTERED 
(
	[EmployeeRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeeRole] ADD  CONSTRAINT [DF_EmployeeRole_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


