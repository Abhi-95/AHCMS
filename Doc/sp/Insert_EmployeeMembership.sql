USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[Insert_EmployeeMembership]    Script Date: 24-08-2018 18:26:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Insert_EmployeeMembership]
	@EmployeeID	nvarchar(128),
	@ReffNo nvarchar(20) Null,
	@username nvarchar(50) Null,
	@password nvarchar(max) Null,
	@EmailID nvarchar(100) Null,
	@CountryCode nvarchar(5) Null,
	@PhoneNumber bigint Null,
	@FirstName nvarchar(50) Null,
	@MiddleName nvarchar(50) Null,
	@LastName nvarchar(50) Null,
	@BirthDate nvarchar(15) NUll,
	@Street nvarchar(200) NULL,
	@City nvarchar(50) NULL,
	@State nvarchar(50) NUll,
	@Country nvarchar(50) NUll,
	@Zipcode nvarchar(10) Null,
	@ProfileImg nvarchar(max) NUll,	
	@BloodGroup nchar(5) Null,
	@Gender int Null,
	@role nvarchar(20)
AS
BEGIN
	
	declare @roleId int

	INSERT INTO Employee(EmployeeID, ReffNo, UserName, Password, Email, CountryCode, PhoneNumber, FirstName, MiddleName, LastName,
		BirthDate, Street, City, State, Country, ZipCode, Img, BloodGroup, Gender, IsDeleted)
	VALUES(@EmployeeID, @ReffNo, @username, @password, @EmailID, @CountryCode, @PhoneNumber,@FirstName, @MiddleName, @LastName,
		@BirthDate, @Street, @City, @State, @Country, @Zipcode, @ProfileImg, @BloodGroup, @Gender, 0)

		IF(@@ERROR = 0)
		BEGIN
			select @roleId = Roles.RoleID from Roles where Roles.Role = @role and IsDeleted = 0

			insert into EmployeeRole(EmployeeId,RoleId,IsDeleted) values(@EmployeeID,@roleId,0)
		END

		return @@ERROR
END
