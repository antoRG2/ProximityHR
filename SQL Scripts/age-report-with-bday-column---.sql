USE [Proximity.HR.Database]
GO
/****** Object:  StoredProcedure [dbo].[agesReport]    Script Date: 1/19/2017 1:47:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER PROCEDURE [dbo].[agesReport] 
      
AS   
    SET NOCOUNT ON;

	SELECT  [dbo].[Employee].FullName as 'Person',
			CONVERT(varchar(25),[dbo].[Employee].[BirthDate], 101) as 'BirthDate',
			DATEDIFF(YEAR, [dbo].[Employee].[BirthDate], GETDATE())  AS 'Age'
			FROM [dbo].[Employee]