USE [AHCMS]
GO

/****** Object:  Table [dbo].[Appointment]    Script Date: 24-08-2018 18:27:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Appointment](
	[AppointmentId] [nvarchar](128) NOT NULL,
	[AppointmentDate] [date] NULL,
	[Slot] [tinyint] NULL,
	[Token] [tinyint] NULL,
	[PatientId] [nvarchar](128) NULL,
	[DoctorId] [nvarchar](128) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


