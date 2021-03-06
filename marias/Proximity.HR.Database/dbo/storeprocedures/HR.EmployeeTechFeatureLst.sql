-- =============================================
-- Author:      Martin Zamora
-- Description: Gest the skill set of the user 
-- =============================================
IF OBJECT_ID ( 'dbo.EmployeeTechFeatureLst', 'P' ) IS NOT NULL   
    DROP PROCEDURE dbo.EmployeeTechFeatureLst;  
GO 
 
CREATE PROCEDURE dbo.EmployeeTechFeatureLst  
    @EmployeeId nvarchar(50)     
AS   
    SET NOCOUNT ON;  
	SELECT 
		Employee =CASE WHEN sk.Employee IS NULL THEN -1 ELSE sk.Employee END, 
		Feature=ft.id,
		Teachable= CONVERT(bit,CASE WHEN (sk.Teachable IS NULL OR sk.Teachable=0) THEN 0 ELSE 1 END),
		Desirable=CONVERT(bit,CASE WHEN (sk.Desirable IS NULL OR sk.Desirable=0) THEN 0 ELSE 1 END), 
		Detail= ft.Detail,
		Enabled=ft.Enabled,
		CreatedBy=ft.CreatedBy,
		CreatedDate=ft.CreatedDate,
		EditedBy=ft.EditedBy,
		EditedDate=ft.EditedDate,
		Level=CASE WHEN (sk.level IS NULL OR sk.level=0) THEN 0 ELSE sk.level END 
	FROM dbo.Feature ft LEFT JOIN dbo.SkillSet sk 
	ON (sk.Feature=ft.Id AND sk.Employee=@EmployeeId);
	 
