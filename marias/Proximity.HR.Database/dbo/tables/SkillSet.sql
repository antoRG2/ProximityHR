CREATE TABLE [dbo].[SkillSet]
(
	[Employee]	    [int]  NOT NULL,
	[Feature]       [int]  NOT NULL,
	[Level]			[int]  NOT NULL,
	[Teachable]	    [bit] NOT NULL,
	[Desirable]	    [bit] NOT NULL,
	[Detail]		[varchar](500) NULL,
	[Enabled]		[bit] NOT NULL,
	[CreatedBy]		[varchar](25) NOT NULL,
	[CreatedDate]	[datetime] NOT NULL,
	[EditedBy]		[varchar](25) NULL,
	[EditedDate]	[datetime]  NULL,
    CONSTRAINT [Pk_SkillSet] PRIMARY KEY ([Employee],[Feature] ),
	CONSTRAINT [Pk_SkillSet_Employee] FOREIGN KEY ([Employee]) REFERENCES [dbo].[Employee]([Id]),
	CONSTRAINT [Pk_SkillSet_Feature] FOREIGN KEY ([Feature]) REFERENCES [dbo].[Feature]([Id])
);
