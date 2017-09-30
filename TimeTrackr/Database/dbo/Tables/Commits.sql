CREATE TABLE [dbo].[Commits] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [ProjectId]   UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]   DATETIME2 (7)    NOT NULL,
    [Description] NVARCHAR (300)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_commit_project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);

