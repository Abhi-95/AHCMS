USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[Get_Patient]    Script Date: 24-08-2018 18:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Get_Patient]	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * from dbo.Patient
END
