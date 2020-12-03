IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [efusers] (
    [_id] uniqueidentifier NOT NULL,
    [openid] nvarchar(max) NOT NULL,
    [createTime] datetime2 NOT NULL,
    [updateTime] datetime2 NOT NULL,
    [vote] int NOT NULL,
    [reason] nvarchar(max) NULL,
    [__v] int NOT NULL,
    CONSTRAINT [PK_efusers] PRIMARY KEY ([_id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201201085345_init20201201165337', N'3.1.9');

GO

