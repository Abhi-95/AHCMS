USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[ForgotPassword]    Script Date: 28-08-2018 17:56:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ForgotPassword]
	@username nvarchar(50),
	@email nvarchar(50),
	@source int
AS
BEGIN
	
	SET NOCOUNT ON;

	declare @user nvarchar(50), @emailId nvarchar(50), @reffno nvarchar(20)
	
	IF @source = 0
	BEGIN
		select @user = Patient.UserName, @reffno = Patient.PatientReffNo, @emailId = Patient.Email from Patient 
			where Patient.UserName = @username and Patient.Email = @email and IsDeleted = 0

		IF @user is not null and @emailId is not null
		begin
			SELECT Patient.FirstName, Patient.LastName, Patient.Password from Patient where Patient.PatientReffNo = @reffno and IsDeleted = 0
		end
	END

	IF @source = 1
	BEGIN
		select @user = Employee.UserName, @reffno = Employee.ReffNo, @emailId = Employee.Email from Employee 
			where Employee.UserName = @username and Employee.Email = @email and IsDeleted = 0

		IF @user is not null and @emailId is not null
		begin
			SELECT Employee.FirstName, Employee.LastName, Employee.Password from Employee where Employee.ReffNo = @reffno and IsDeleted = 0			
		end
	END
	
END
