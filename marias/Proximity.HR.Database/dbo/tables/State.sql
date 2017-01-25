CREATE TABLE [dbo].[State]
(
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Country]       [int] NOT NULL,
	[Name]			[varchar](100) NOT NULL,
	[Detail]		[varchar](500) NULL,
	[Enabled]		[bit] NOT NULL,
	[CreatedBy]		[varchar](25) NOT NULL,
	[CreatedDate]	[datetime] NOT NULL,
	[EditedBy]		[varchar](25) NULL,
	[EditedDate]	[datetime]  NULL,
	CONSTRAINT [Pk_State] PRIMARY KEY ([Id]),
	CONSTRAINT [Pk_State_Country] FOREIGN KEY ([Country]) REFERENCES [dbo].[Country]([Id])
);
