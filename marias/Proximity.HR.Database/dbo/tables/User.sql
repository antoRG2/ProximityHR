CREATE TABLE [dbo].[User]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL ,
	[IsAdmin] [bit] NOT NULL DEFAULT 0,
	[IsResource] [bit] NOT NULL DEFAULT 0,
	[IsProyectManager] [bit] NOT NULL DEFAULT 0,
	[Enabled] [bit]  NOT NULL DEFAULT 1 ,
	[CreatedBy] [varchar](25)  NOT NULL,
	[CreatedDate] [datetime]   NOT NULL,
	[EditedBy] [varchar](25)  NULL,
	[EditedDate] [datetime]  NULL,
    CONSTRAINT [Pk_User] PRIMARY KEY (Id)
);
