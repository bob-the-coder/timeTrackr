CREATE TABLE [dbo].[Users] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Email]    NVARCHAR (200)   NOT NULL,
    [Password] VARBINARY (MAX)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

