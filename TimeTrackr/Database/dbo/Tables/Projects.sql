CREATE TABLE [dbo].[Projects] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (100)   NOT NULL,
    [CreatedAt] DATETIME2 (7)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_project_user] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

