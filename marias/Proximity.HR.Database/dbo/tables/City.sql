CREATE TABLE [dbo].[City]
(
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[State]         [int] NOT NULL,
	[Name]			[varchar](100) NOT NULL,
	[Detail]		[varchar](500) NULL,
	[Enabled]		[bit] NOT NULL,
	[CreatedBy]		[varchar](25) NOT NULL,
	[CreatedDate]	[datetime] NOT NULL,
	[EditedBy]		[varchar](25) NULL,
	[EditedDate]	[datetime]  NULL,
	CONSTRAINT [Pk_City] PRIMARY KEY ([Id]),
	CONSTRAINT [Pk_City_State] FOREIGN KEY ([State]) REFERENCES [dbo].[State]([Id])
);
