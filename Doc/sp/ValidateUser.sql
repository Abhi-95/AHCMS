USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[ValidateUser]    Script Date: 24-08-2018 18:27:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ValidateUser]
	@username nvarchar(50),
	@password nvarchar(128),
	@role nvarchar(20),
	@source int
AS
BEGIN	
	SET NOCOUNT ON;

	Declare @roleId int, @id nvarchar(128), @reffno nvarchar(20), @firstname nvarchar(50), @lastname nvarchar(50),
	 @img nvarchar(max), @status int, @IsActivated bit

	IF @source = 0
	BEGIN
		select @id = Patient.PatientID, @reffno = Patient.PatientReffNo, @firstname = Patient.FirstName, 
			@lastname = Patient.LastName, @img = Patient.Img from Patient 
		where UserName = @username and Password = @password and IsDeleted = 0

		IF @id IS NOT NULL 
		BEGIN
			Select @IsActivated = Patient.EmailConfirmed from Patient where PatientID = @id
			IF @IsActivated = 1
			Begin
				update Patient set Patient.LastModifiedDate = GETDATE() where PatientID = @id
				set @status = 0 -- Return sucess status of valid account
			End
			Else
			Begin
				set @status = 2 --Account not activated
			End				
		END
		ELSE
		BEGIN
			set @status = 3 -- Invalid Account detail
		END

		Select @status as 'Status', @reffno as 'ReffNo', @firstname as 'FirstName', @lastname as 'LastName', @img as 'Img'
	END
	IF @source = 1 
	BEGIN 
		--select * from Employee where UserName = @username and Password = @password and IsDeleted = 0

		select @roleId = RoleID from Roles where Role = @role and IsDeleted = 0 

		SELECT @id = Employee.EmployeeID, @reffno = Employee.ReffNo, @firstname = Employee.FirstName,
			@lastname= Employee.LastName, @img = Employee.Img FROM Employee INNER JOIN EmployeeRole ON Employee.EmployeeID = EmployeeRole.EmployeeId
		WHERE (EmployeeRole.RoleId = @roleId) and Employee.IsDeleted = 0 AND (Employee.UserName = @username) AND (Employee.Password = @password)
		
		IF @id IS NOT NULL 
		BEGIN
			Select @IsActivated = Employee.EmailConfirmed from Employee where EmployeeID = @id
			IF @IsActivated = 1
			Begin
				update Employee set Employee.LastModifiedDate = GETDATE() where EmployeeID = @id
				set @status = 0 -- Return sucess status of valid account
			End
			Else
			Begin
				set @status = 2 --Account not activated
			End				
		END
		ELSE
		BEGIN
			set @status = 3 -- Invalid Account detail
		END

		Select @status as 'Status', @reffno as 'ReffNo', @firstname as 'FirstName', @lastname as 'LastName', @img as 'Img'
	END
END
