CREATE TABLE [dbo].[Technology]
(
    [Id]			[int] IDENTITY(1,1) NOT NULL,
	[Name]			[varchar](100) NOT NULL,
	[Detail]		[varchar](500) NULL,
	[Enabled]		[bit]  NOT NULL DEFAULT 1,
	[CreatedBy]		[varchar](25) NOT NULL,
	[CreatedDate]	[datetime] NOT NULL,
	[EditedBy]		[varchar](25) NULL,
	[EditedDate]	[datetime]  NULL,
	CONSTRAINT [Pk_Technology] PRIMARY KEY ([Id])
);
