ALTER TABLE Employee ADD
 [HasLicense] [bit] NOT NULL DEFAULT 0 ,
 [LicenseNumber] [varchar](100)  NULL,
 [LicenseExpeditionDate] [datetime] NULL ,
 [LicenseExpirationDate] [datetime]  NULL
GO

SELECT TOP 10 * FROM Employee