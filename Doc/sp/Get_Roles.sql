USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[Get_Roles]    Script Date: 24-08-2018 18:25:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Get_Roles]
	@id int
AS
BEGIN	
	SET NOCOUNT ON;
	SELECT * from Roles where (RoleID = @id or RoleID = '-1') and IsDeleted = 0;
END
