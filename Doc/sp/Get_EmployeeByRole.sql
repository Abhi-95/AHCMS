USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[Get_EmployeeByRole]    Script Date: 24-08-2018 18:25:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Get_EmployeeByRole]	
	@Role nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	Declare @roleId int
	select @roleId = RoleID from Roles where Role = @Role and IsDeleted = 0 

	SELECT Employee.* FROM Employee INNER JOIN EmployeeRole ON Employee.EmployeeID = EmployeeRole.EmployeeId
	WHERE (EmployeeRole.RoleId = @roleId)
END