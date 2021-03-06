USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[ResetPassword]    Script Date: 24-08-2018 18:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ResetPassword]
	@id nvarchar(128),
	@username nvarchar(50),
	@email nvarchar(50),
	@password nvarchar(max),
	@source int
AS
BEGIN
	
	SET NOCOUNT ON;

	declare @status int
	
	update Patient set Password = @password 	
	where PatientID = @id and Patient.UserName = @username and Patient.Email = @email and IsDeleted = 0

	set @status = @@ROWCOUNT

	select @status
END
