USE [Proximity.HR.Database]
GO

/****** Object:  UserDefinedFunction [dbo].[GetEmployeeWorkingYears]    Script Date: 1/26/2017 4:13:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Allan Serrano>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetEmployeeWorkingYears]
(
	-- Add the parameters for the function here
	@EMP_DATE DATETIME
)
RETURNS varchar(100)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @date datetime, @tmpdate datetime, @years int, @months int, @days int, @result VARCHAR(100)
	SET @date = @EMP_DATE

	SET @tmpdate = @date

	SET @years = DATEDIFF(yy, @tmpdate, GETDATE()) - CASE WHEN (MONTH(@date) > MONTH(GETDATE())) OR (MONTH(@date) = MONTH(GETDATE()) AND DAY(@date) > DAY(GETDATE())) THEN 1 ELSE 0 END
	SET @tmpdate = DATEADD(yy, @years, @tmpdate)
	SET @months = DATEDIFF(m, @tmpdate, GETDATE()) - CASE WHEN DAY(@date) > DAY(GETDATE()) THEN 1 ELSE 0 END
	SET @tmpdate = DATEADD(m, @months, @tmpdate)
	SET @days = DATEDIFF(d, @tmpdate, GETDATE())

	SET @result = CONCAT(@years, ' years and ', @months, ' months')

	-- Return the result of the function
	RETURN  @result

END

GO


