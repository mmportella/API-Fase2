﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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
VALUES (N'20220418131929_migracao', N'6.0.4');
GO

COMMIT;
GO

