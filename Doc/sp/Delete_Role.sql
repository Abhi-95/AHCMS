USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Role]    Script Date: 24-08-2018 18:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Delete_Role]
	@id int
AS
BEGIN
	update dbo.Roles set IsDeleted=1 where RoleId=@id

END
