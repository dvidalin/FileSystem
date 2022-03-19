CREATE TABLE [dbo].[Folders] (
    [Node]      [sys].[hierarchyid] NOT NULL UNIQUE,
    [Level]     AS ([Node].[GetLevel]()),
    [Id]        INT                 NOT NULL IDENTITY(1,1),
    [Name]      VARCHAR (32)        NOT NULL,
    [ParentId]  INT                 NULL,
    
    [IsDeleted] BIT                 NULL

    CONSTRAINT PK_Folders PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT FK_Folders_Parent FOREIGN KEY ([ParentId])
               REFERENCES [dbo].[Folders] ([Id])

);


GO
CREATE UNIQUE NONCLUSTERED INDEX [FoldersNC1]
    ON [dbo].[Folders]([Level] ASC, [Node] ASC);

