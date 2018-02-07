
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/27/2017 22:09:51
-- Generated from EDMX file: C:\Users\Saidel\Source\Workspaces\DemoPortales\Source\DataLayer\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PORTALES];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BillDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Details] DROP CONSTRAINT [FK_BillDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientBill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK_ClientBill];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_CategoryProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Details] DROP CONSTRAINT [FK_ProductDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileClient] DROP CONSTRAINT [FK_ClientFile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bill];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Details];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log];
GO
IF OBJECT_ID(N'[dbo].[FileClient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileClient];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bill'
CREATE TABLE [dbo].[Bill] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ClientId] int  NOT NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DNI] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Last_Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Details'
CREATE TABLE [dbo].[Details] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] int  NOT NULL,
    [BillId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(18,2)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Stock] int  NOT NULL,
    [CategoryId] int  NOT NULL
);
GO

-- Creating table 'Log'
CREATE TABLE [dbo].[Log] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Thread] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [Level] nvarchar(max)  NULL,
    [Logger] nvarchar(max)  NULL,
    [Message] nvarchar(max)  NULL,
    [Exception] nvarchar(max)  NULL
);
GO

-- Creating table 'FileClient'
CREATE TABLE [dbo].[FileClient] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [ContentType] nvarchar(max)  NOT NULL,
    [Content] varbinary(max)  NOT NULL,
    [FileType] int  NOT NULL,
    [ClientId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bill'
ALTER TABLE [dbo].[Bill]
ADD CONSTRAINT [PK_Bill]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [BillId] in table 'Details'
ALTER TABLE [dbo].[Details]
ADD CONSTRAINT [PK_Details]
    PRIMARY KEY CLUSTERED ([Id], [BillId] ASC);
GO

-- Creating primary key on [Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Log'
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [PK_Log]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FileClient'
ALTER TABLE [dbo].[FileClient]
ADD CONSTRAINT [PK_FileClient]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BillId] in table 'Details'
ALTER TABLE [dbo].[Details]
ADD CONSTRAINT [FK_BillDetails]
    FOREIGN KEY ([BillId])
    REFERENCES [dbo].[Bill]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillDetails'
CREATE INDEX [IX_FK_BillDetails]
ON [dbo].[Details]
    ([BillId]);
GO

-- Creating foreign key on [ClientId] in table 'Bill'
ALTER TABLE [dbo].[Bill]
ADD CONSTRAINT [FK_ClientBill]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientBill'
CREATE INDEX [IX_FK_ClientBill]
ON [dbo].[Bill]
    ([ClientId]);
GO

-- Creating foreign key on [CategoryId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_CategoryProduct]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProduct'
CREATE INDEX [IX_FK_CategoryProduct]
ON [dbo].[Product]
    ([CategoryId]);
GO

-- Creating foreign key on [ProductId] in table 'Details'
ALTER TABLE [dbo].[Details]
ADD CONSTRAINT [FK_ProductDetails]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductDetails'
CREATE INDEX [IX_FK_ProductDetails]
ON [dbo].[Details]
    ([ProductId]);
GO

-- Creating foreign key on [ClientId] in table 'FileClient'
ALTER TABLE [dbo].[FileClient]
ADD CONSTRAINT [FK_ClientFile]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientFile'
CREATE INDEX [IX_FK_ClientFile]
ON [dbo].[FileClient]
    ([ClientId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------