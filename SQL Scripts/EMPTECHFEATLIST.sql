USE [Proximity.HR.Database]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeTechFeatureLst]    Script Date: 1/23/2017 3:35:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[EmployeeTechFeatureLst]  
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
	 
