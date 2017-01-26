USE [Proximity.HR.Database]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeTechFeature]    Script Date: 1/23/2017 3:34:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[EmployeeTechFeature]   
   @Employee int,
	@Feature int,
	@Level int,
	@Teachable bit ,
	@Desirable bit,
	@Detail varchar(500),
	@Enable bit,
	@CreatedBy varchar(25),
	@CreatedDate datetime,
	@EditedBy varchar(25),
	@EditedDate datetime  
AS
    SET NOCOUNT ON; 
DECLARE
@Result INT;
 
IF EXISTS(SELECT 
	Employee = s.Employee, 
	Feature=ft.id 
	FROM dbo.Feature ft INNER JOIN dbo.SkillSet s
	ON (s.Feature=ft.Id AND s.Employee=@Employee AND ft.id=@Feature))
	BEGIN
		BEGIN TRY
			UPDATE sk SET
				sk.Level = @Level,
				sk.Teachable=@Teachable,
				sk.Desirable=@Desirable,
				sk.EditedBy=@EditedBy,
				sk.EditedDate=getdate()
			FROM dbo.SkillSet sk
			WHERE sk.Employee=@Employee AND sk.Feature=@Feature
			PRINT 'UPDATE';
			
			SET @Result =2; 
			
		END TRY  
		BEGIN CATCH   
			SET @Result =22; 
			PRINT ERROR_MESSAGE(); 
		END CATCH;  
	END;
ELSE
	BEGIN 
		BEGIN TRY
			INSERT INTO dbo.SkillSet
						(Employee
						,Feature
						,Level
						,Teachable
						,Desirable
						,Detail
						,Enabled
						,CreatedBy
						,CreatedDate
						,EditedBy
						,EditedDate)
					VALUES
						(@Employee
						,@Feature
						,@Level
						,@Teachable 
						,@Desirable
						,null
						,1 
						,@CreatedBy
						,getdate() 
						,@EditedBy 
						,getdate());
			PRINT 'INSERT';
			SET @Result =1; 
		END TRY  
		BEGIN CATCH   
			SET @Result =11; 
			PRINT ERROR_MESSAGE(); 
		END CATCH;  

END;
	Select @Result;
