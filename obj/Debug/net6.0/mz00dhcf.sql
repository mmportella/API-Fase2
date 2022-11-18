IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Estabelecimentos] (
    [IdEstabelecimento] int NOT NULL IDENTITY,
    [Cnpj] int NOT NULL,
    [NomeEstabelecimento] nvarchar(50) NOT NULL,
    [Logradouro] nvarchar(50) NOT NULL,
    [Numero] int NOT NULL,
    [Cidade] nvarchar(50) NOT NULL,
    [Cep] int NOT NULL,
    CONSTRAINT [PK_Estabelecimentos] PRIMARY KEY ([IdEstabelecimento])
);
GO

CREATE TABLE [Produtos] (
    [IdProduto] int NOT NULL IDENTITY,
    [Marca] nvarchar(50) NOT NULL,
    [NomeProduto] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([IdProduto])
);
GO

CREATE TABLE [Estoques] (
    [IdEstoque] int NOT NULL IDENTITY,
    [EstabelecimentoId] int NOT NULL,
    [ProdutoId] int NOT NULL,
    [valor] float NOT NULL,
    [quantidade] int NOT NULL,
    CONSTRAINT [PK_Estoques] PRIMARY KEY ([IdEstoque]),
    CONSTRAINT [FK_Estoques_Estabelecimentos_EstabelecimentoId] FOREIGN KEY ([EstabelecimentoId]) REFERENCES [Estabelecimentos] ([IdEstabelecimento]) ON DELETE CASCADE,
    CONSTRAINT [FK_Estoques_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([IdProduto]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Estoques_EstabelecimentoId] ON [Estoques] ([EstabelecimentoId]);
GO

CREATE INDEX [IX_Estoques_ProdutoId] ON [Estoques] ([ProdutoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220418131929_migracao', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Estoques].[valor]', N'Valor', N'COLUMN';
GO

EXEC sp_rename N'[Estoques].[quantidade]', N'Quantidade', N'COLUMN';
GO

CREATE TABLE [Listas] (
    [IdLista] int NOT NULL IDENTITY,
    [NomeLista] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Listas] PRIMARY KEY ([IdLista])
);
GO

CREATE TABLE [ProdutosLista] (
    [IdProdutoLista] int NOT NULL IDENTITY,
    [ListaId] int NOT NULL,
    [ProdutoId] int NOT NULL,
    [Quantidade] int NOT NULL,
    CONSTRAINT [PK_ProdutosLista] PRIMARY KEY ([IdProdutoLista]),
    CONSTRAINT [FK_ProdutosLista_Listas_ListaId] FOREIGN KEY ([ListaId]) REFERENCES [Listas] ([IdLista]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProdutosLista_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([IdProduto]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ProdutosLista_ListaId] ON [ProdutosLista] ([ListaId]);
GO

CREATE INDEX [IX_ProdutosLista_ProdutoId] ON [ProdutosLista] ([ProdutoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220902203504_Migracao2', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Estabelecimentos]') AND [c].[name] = N'Cnpj');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Estabelecimentos] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Estabelecimentos] ALTER COLUMN [Cnpj] bigint NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221118005135_Migracao123', N'6.0.8');
GO

COMMIT;
GO

