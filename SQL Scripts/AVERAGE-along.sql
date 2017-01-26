/*==================================================================================
	AUTHOR: MELISSA ARIAS

	TITLE: AVERAGE WORKING YEARS REPORT THE AVERAGE

===================================================================================*/

USE [Proximity.HR.Database]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[average] 
      
AS   
    SET NOCOUNT ON;

	SELECT SUM(DATEDIFF(YEAR, [dbo].[Employee].[StartDate], GETDATE())) / COUNT([dbo].[Employee].[FullName]) 
		as 'total average'
		FROM [dbo].[Employee] 