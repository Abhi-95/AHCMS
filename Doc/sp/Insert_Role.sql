USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Role]    Script Date: 24-08-2018 18:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Insert_Role]
	@Role nvarchar(50)
AS
BEGIN
	insert into [Roles](Role,IsDeleted) values(@Role,0)
END
