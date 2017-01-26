/*=========================================================================

	AUTHOR: MELISSA ARIAS

	TITLE: EXPIRATION DATES REPORT FOR VISA, LICENSE AND PASSPORT


===========================================================================*/


USE [Proximity.HR.Database]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[expirationDatesReport] 
      
AS   
    SET NOCOUNT ON;

	SELECT  [dbo].[Employee].FullName as 'Person',
			CONVERT(VARCHAR(25),[dbo].[Employee].LicenseExpirationDate,101) as 'License',
			CONVERT(VARCHAR(25),[dbo].[Employee].VisaExpirationDate,101) as 'Visa',
			CONVERT(VARCHAR(25),[dbo].[Employee].PassportExpirationDate,101) as 'Passport'
			FROM [dbo].[Employee]
			ORDER BY 'Person' ASC


			