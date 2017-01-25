CREATE TABLE [dbo].[Country]
(
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Name]			[varchar](100) NOT NULL,
	[Nationality]	[varchar](100) NOT NULL,
	[Detail]		[varchar](500) NULL,
	[Enabled]		[bit] NOT NULL,
	[CreatedBy]		[varchar](25) NOT NULL,
	[CreatedDate]	[datetime] NOT NULL,
	[EditedBy]		[varchar](25) NULL,
	[EditedDate]	[datetime]  NULL,
	CONSTRAINT [Pk_Country] PRIMARY KEY ([Id])
);



