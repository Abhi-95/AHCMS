USE [AHCMS]
GO

/****** Object:  Table [dbo].[PatientWalkIn]    Script Date: 24-08-2018 18:29:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PatientWalkIn](
	[WalkInID] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Age] [tinyint] NULL,
	[BirthDate] [date] NULL,
	[ArriavalTimeStamp] [datetime] NULL,
	[DepatureTimeStamp] [datetime] NULL,
	[PatientReffNo] [nvarchar](20) NULL,
 CONSTRAINT [PK_PatientWalkIn] PRIMARY KEY CLUSTERED 
(
	[WalkInID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


