USE [Proximity.HR.Database]
GO

/****** Object:  StoredProcedure [dbo].[averageWorkingYearsReport]    Script Date: 1/26/2017 4:16:29 PM ******/
DROP PROCEDURE [dbo].[averageWorkingYearsReport]
GO

/****** Object:  StoredProcedure [dbo].[averageWorkingYearsReport]    Script Date: 1/26/2017 4:16:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[averageWorkingYearsReport] 
      
AS   
    SET NOCOUNT ON;

	SELECT [dbo].[Employee].[FullName] as name,
			[dbo].[Employee].[StartDate] as 'started on',
			[dbo].GetEmployeeWorkingYears([dbo].[Employee].[StartDate]) as 'working years',
			(SELECT 
				SUM(DATEDIFF(YEAR, [dbo].[Employee].[StartDate], GETDATE())) / COUNT([dbo].[Employee].[FullName])
				FROM [dbo].[Employee]) as 'total average'
		
			FROM [dbo].[Employee]
			ORDER BY 'working years' DESC, name ASC
GO


