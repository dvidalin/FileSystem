CREATE TABLE [dbo].[FolderOrg] (
    [Node]      [sys].[hierarchyid] NOT NULL UNIQUE,
    [Level]     AS ([Node].[GetLevel]()),
    [Id]        INT                 NOT NULL IDENTITY(1,1),
    [Name]      VARCHAR (32)        NOT NULL,
    [IsDeleted] BIT                 NULL
    PRIMARY KEY CLUSTERED ([Id] ASC),

);


GO
CREATE UNIQUE NONCLUSTERED INDEX [FolderOrgNc1]
    ON [dbo].[FolderOrg]([Level] ASC, [Node] ASC);

