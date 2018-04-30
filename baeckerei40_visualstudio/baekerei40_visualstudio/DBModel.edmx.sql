
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/30/2018 21:13:49
-- Generated from EDMX file: E:\win_git\baekerei40\baeckerei40_wpf\baekerei40_visualstudio\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [baeckerei40];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KundenBestellungen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bestellungen] DROP CONSTRAINT [FK_KundenBestellungen];
GO
IF OBJECT_ID(N'[dbo].[FK_BestellungenProdukteInBestellungen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdukteInBestellungen] DROP CONSTRAINT [FK_BestellungenProdukteInBestellungen];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdukteInBestellungenProdukte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Produkte] DROP CONSTRAINT [FK_ProdukteInBestellungenProdukte];
GO
IF OBJECT_ID(N'[dbo].[FK_RohstoffeInProdukteRohstoffe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RohstoffeInProdukte] DROP CONSTRAINT [FK_RohstoffeInProdukteRohstoffe];
GO
IF OBJECT_ID(N'[dbo].[FK_RohstoffeInProdukteProdukte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RohstoffeInProdukte] DROP CONSTRAINT [FK_RohstoffeInProdukteProdukte];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Kunden]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kunden];
GO
IF OBJECT_ID(N'[dbo].[Produkte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produkte];
GO
IF OBJECT_ID(N'[dbo].[Rohstoffe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rohstoffe];
GO
IF OBJECT_ID(N'[dbo].[Bestellungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bestellungen];
GO
IF OBJECT_ID(N'[dbo].[RohstoffeInProdukte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RohstoffeInProdukte];
GO
IF OBJECT_ID(N'[dbo].[ProdukteInBestellungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdukteInBestellungen];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kunden'
CREATE TABLE [dbo].[Kunden] (
    [KundenID] int IDENTITY(1,1) NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Nachname] nvarchar(max)  NOT NULL,
    [Telefonnummer] nvarchar(max)  NOT NULL,
    [EMail] nvarchar(max)  NOT NULL,
    [Adresse] nvarchar(max)  NOT NULL,
    [PLZ] nvarchar(max)  NOT NULL,
    [Ort] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Produkte'
CREATE TABLE [dbo].[Produkte] (
    [ProduktID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Produktpreis] nvarchar(max)  NOT NULL,
    [ProdukteInBestellungenProdukteInBestellungenID] int  NOT NULL
);
GO

-- Creating table 'Rohstoffe'
CREATE TABLE [dbo].[Rohstoffe] (
    [RohstoffID] int IDENTITY(1,1) NOT NULL,
    [Rohstoffname] nvarchar(max)  NOT NULL,
    [Rohstoffeinheit] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bestellungen'
CREATE TABLE [dbo].[Bestellungen] (
    [BestellID] int IDENTITY(1,1) NOT NULL,
    [Abholungstermin] nvarchar(max)  NOT NULL,
    [Rechnungsbetrag] nvarchar(max)  NOT NULL,
    [KundenID] int  NOT NULL
);
GO

-- Creating table 'RohstoffeInProdukte'
CREATE TABLE [dbo].[RohstoffeInProdukte] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Menge] nvarchar(max)  NOT NULL,
    [ProduktID] int  NOT NULL,
    [Rohstoffe_RohstoffID] int  NOT NULL,
    [Produkte_ProduktID] int  NOT NULL
);
GO

-- Creating table 'ProdukteInBestellungen'
CREATE TABLE [dbo].[ProdukteInBestellungen] (
    [ProdukteInBestellungenID] int IDENTITY(1,1) NOT NULL,
    [Menge] nvarchar(max)  NOT NULL,
    [BestellID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [KundenID] in table 'Kunden'
ALTER TABLE [dbo].[Kunden]
ADD CONSTRAINT [PK_Kunden]
    PRIMARY KEY CLUSTERED ([KundenID] ASC);
GO

-- Creating primary key on [ProduktID] in table 'Produkte'
ALTER TABLE [dbo].[Produkte]
ADD CONSTRAINT [PK_Produkte]
    PRIMARY KEY CLUSTERED ([ProduktID] ASC);
GO

-- Creating primary key on [RohstoffID] in table 'Rohstoffe'
ALTER TABLE [dbo].[Rohstoffe]
ADD CONSTRAINT [PK_Rohstoffe]
    PRIMARY KEY CLUSTERED ([RohstoffID] ASC);
GO

-- Creating primary key on [BestellID] in table 'Bestellungen'
ALTER TABLE [dbo].[Bestellungen]
ADD CONSTRAINT [PK_Bestellungen]
    PRIMARY KEY CLUSTERED ([BestellID] ASC);
GO

-- Creating primary key on [Id] in table 'RohstoffeInProdukte'
ALTER TABLE [dbo].[RohstoffeInProdukte]
ADD CONSTRAINT [PK_RohstoffeInProdukte]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ProdukteInBestellungenID] in table 'ProdukteInBestellungen'
ALTER TABLE [dbo].[ProdukteInBestellungen]
ADD CONSTRAINT [PK_ProdukteInBestellungen]
    PRIMARY KEY CLUSTERED ([ProdukteInBestellungenID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KundenID] in table 'Bestellungen'
ALTER TABLE [dbo].[Bestellungen]
ADD CONSTRAINT [FK_KundenBestellungen]
    FOREIGN KEY ([KundenID])
    REFERENCES [dbo].[Kunden]
        ([KundenID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KundenBestellungen'
CREATE INDEX [IX_FK_KundenBestellungen]
ON [dbo].[Bestellungen]
    ([KundenID]);
GO

-- Creating foreign key on [BestellID] in table 'ProdukteInBestellungen'
ALTER TABLE [dbo].[ProdukteInBestellungen]
ADD CONSTRAINT [FK_BestellungenProdukteInBestellungen]
    FOREIGN KEY ([BestellID])
    REFERENCES [dbo].[Bestellungen]
        ([BestellID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BestellungenProdukteInBestellungen'
CREATE INDEX [IX_FK_BestellungenProdukteInBestellungen]
ON [dbo].[ProdukteInBestellungen]
    ([BestellID]);
GO

-- Creating foreign key on [ProdukteInBestellungenProdukteInBestellungenID] in table 'Produkte'
ALTER TABLE [dbo].[Produkte]
ADD CONSTRAINT [FK_ProdukteInBestellungenProdukte]
    FOREIGN KEY ([ProdukteInBestellungenProdukteInBestellungenID])
    REFERENCES [dbo].[ProdukteInBestellungen]
        ([ProdukteInBestellungenID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdukteInBestellungenProdukte'
CREATE INDEX [IX_FK_ProdukteInBestellungenProdukte]
ON [dbo].[Produkte]
    ([ProdukteInBestellungenProdukteInBestellungenID]);
GO

-- Creating foreign key on [Rohstoffe_RohstoffID] in table 'RohstoffeInProdukte'
ALTER TABLE [dbo].[RohstoffeInProdukte]
ADD CONSTRAINT [FK_RohstoffeInProdukteRohstoffe]
    FOREIGN KEY ([Rohstoffe_RohstoffID])
    REFERENCES [dbo].[Rohstoffe]
        ([RohstoffID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RohstoffeInProdukteRohstoffe'
CREATE INDEX [IX_FK_RohstoffeInProdukteRohstoffe]
ON [dbo].[RohstoffeInProdukte]
    ([Rohstoffe_RohstoffID]);
GO

-- Creating foreign key on [Produkte_ProduktID] in table 'RohstoffeInProdukte'
ALTER TABLE [dbo].[RohstoffeInProdukte]
ADD CONSTRAINT [FK_RohstoffeInProdukteProdukte]
    FOREIGN KEY ([Produkte_ProduktID])
    REFERENCES [dbo].[Produkte]
        ([ProduktID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RohstoffeInProdukteProdukte'
CREATE INDEX [IX_FK_RohstoffeInProdukteProdukte]
ON [dbo].[RohstoffeInProdukte]
    ([Produkte_ProduktID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------