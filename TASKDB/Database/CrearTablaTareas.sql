CREATE TABLE [dbo].[Tareas]
(
    [Id] INT IDENTITY(1,1) NOT NULL
        CONSTRAINT [PK_Tareas] PRIMARY KEY,

    [Titulo] NVARCHAR(150) NOT NULL,

    [Descripcion] NVARCHAR(MAX) NULL,

    [Estado] NVARCHAR(20) NOT NULL
        CONSTRAINT [DF_Tareas_Estado]
        DEFAULT (N'Pendiente'),

    [FechaCreacion] DATETIME NOT NULL
        CONSTRAINT [DF_Tareas_FechaCreacion]
        DEFAULT (GETDATE()),

    CONSTRAINT [CK_Tareas_Estado]
        CHECK ([Estado] IN (N'Pendiente', N'Completada'))
);