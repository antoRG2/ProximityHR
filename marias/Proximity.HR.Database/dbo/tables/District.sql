CREATE TABLE [dbo].[District]
(
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[City]          [int] NOT NULL,
	[Name]			[varchar](100) NOT NULL,
	[Detail]		[varchar](500) NULL,
	[Enabled]		[bit] NOT NULL,
	[CreatedBy]		[varchar](25) NOT NULL,
	[CreatedDate]	[datetime] NOT NULL,
	[EditedBy]		[varchar](25) NULL,
	[EditedDate]	[datetime]  NULL,
	CONSTRAINT [Pk_District] PRIMARY KEY ([Id]),
	CONSTRAINT [Pk_District_City] FOREIGN KEY ([City]) REFERENCES [dbo].[City]([Id])
);
