CREATE TABLE [dbo].[Files]
(
	[Id]			INT NOT NULL IDENTITY,
	[Name]			NVARCHAR(255) NOT NULL,
	[ParentFolderId]		INT NOT NULL,

	[IsDeleted]		BIT NOT NULL DEFAULT 0,
	[DateCreated]	DATETIME NOT NULL,
	[DateModified]	DATETIME NOT NULL,

	CONSTRAINT PK_Files PRIMARY KEY NONCLUSTERED ([Id]),
	CONSTRAINT FK_Files_Folder FOREIGN KEY ([ParentFolderId])
				REFERENCES [dbo].[Folders] ([Id])
)
