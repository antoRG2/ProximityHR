/*=========================================================================

	AUTHOR: MELISSA ARIAS

	TITLE: MARITAL STATUS REPORT


===========================================================================*/


USE [Proximity.HR.Database]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[maritalStatusReport] 
      
AS   
    SET NOCOUNT ON;
SELECT   [dbo].Employee.FullName as "Person",
		 CASE	WHEN ([dbo].Employee.MaritalStatus = 1) THEN 'Soltero (a)'
				WHEN ([dbo].Employee.MaritalStatus = 2) THEN  'Casado (a)' 
				WHEN ([dbo].Employee.MaritalStatus = 3) THEN  'Divorciado (a)'
				WHEN ([dbo].Employee.MaritalStatus = 4) THEN  'Viudo (a)'
				WHEN ([dbo].Employee.MaritalStatus = 5) THEN  'Union Libre'
				ELSE 'not specified'
		END AS 'Marital Status'

		FROM [dbo].[Employee]

		ORDER BY "Person" ASC