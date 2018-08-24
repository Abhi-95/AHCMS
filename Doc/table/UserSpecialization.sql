USE [AHCMS]
GO

/****** Object:  Table [dbo].[UserSpecialization]    Script Date: 24-08-2018 18:29:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserSpecialization](
	[UserSpecializationId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[SpecializationId] [nvarchar](128) NULL,
 CONSTRAINT [PK_UserSpecialization] PRIMARY KEY CLUSTERED 
(
	[UserSpecializationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


