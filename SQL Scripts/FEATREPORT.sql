USE [Proximity.HR.Database]
GO
/****** Object:  StoredProcedure [dbo].[featuresReportByExpertise]    Script Date: 1/23/2017 3:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[featuresReportByExpertise] 
      
AS   
    SET NOCOUNT ON;
	SELECT [dbo].Employee.FullName as EMPLOYEE,
		[dbo].Feature.Name AS FEATURE,
		CASE	WHEN ([dbo].SkillSet.Level = 1) THEN 'Poor'
				WHEN ([dbo].SkillSet.Level = 2) THEN  'Basic' 
				WHEN ([dbo].SkillSet.Level = 3) THEN  'Good'
				WHEN ([dbo].SkillSet.Level = 4) THEN  'Excellent'
				WHEN ([dbo].SkillSet.Level = 5) THEN  'Expert'
				ELSE 'not specified'
		END AS LEVEL
		FROM [dbo].SkillSet INNER JOIN [dbo].Employee ON [dbo].SkillSet.Employee = [dbo].Employee.Id
			 INNER JOIN [dbo].Feature ON  [dbo].Feature.Id = [dbo].SkillSet.Feature
		ORDER BY [dbo].SkillSet.Level DESC, FEATURE, EMPLOYEE ASC 