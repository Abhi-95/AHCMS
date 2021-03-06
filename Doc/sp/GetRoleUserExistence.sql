USE [AHCMS]
GO
/****** Object:  StoredProcedure [dbo].[GetRoleUserExistence]    Script Date: 24-08-2018 18:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- find user existence with deleting role
-- if user exist then through true response else false
 
ALTER PROCEDURE [dbo].[GetRoleUserExistence]
	@id int
AS
BEGIN
	DECLARE @MyCursor CURSOR;
	DECLARE @IsDeleted bit;
	DECLARE @status bit;

	BEGIN
		SET @MyCursor = CURSOR FOR
		select IsDeleted from dbo.EmployeeRole where RoleId = @id
		set @status = 0;
		OPEN @MyCursor 
		FETCH NEXT FROM @MyCursor 
		INTO @IsDeleted

		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @IsDeleted = 1
			BEGIN
				set @status = 1;
				BREAK;
			END
			
			-- select @status
			
			FETCH NEXT FROM @MyCursor INTO @IsDeleted
		END; 
				
		CLOSE @MyCursor ;
		DEALLOCATE @MyCursor;
	
	END;
	select @status;
END
