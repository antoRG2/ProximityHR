/*=========================================================================

	AUTHOR: MELISSA ARIAS

	TITLE: DEMOGRAPHIC REPORT


===========================================================================*/


USE [Proximity.HR.Database]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[demographicReport] 
      
AS   
    SET NOCOUNT ON;

	SELECT e.[FullName] as 'Person',
		   co.Name as 'Country',
		   c.Name as 'City'
		   
		   FROM [dbo].[Employee] AS e INNER JOIN [dbo].Country AS co ON e.Country = co.Id
				INNER JOIN [dbo].[City] as c ON e.City = c.Id
		   
		   ORDER BY 'Person' ASC	