
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/15/2018 18:53:20
-- Generated from EDMX file: E:\win_git\baeckerei40\baeckerei40_visualstudio\baekerei40_visualstudio\baeckerei40dbModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_BestellungBestellungEnthaelt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdukteInBestellungen] DROP CONSTRAINT [FK_BestellungBestellungEnthaelt];
GO
IF OBJECT_ID(N'[dbo].[FK_KundeBestellung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bestellungen] DROP CONSTRAINT [FK_KundeBestellung];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktBestellungEnthaelt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdukteInBestellungen] DROP CONSTRAINT [FK_ProduktBestellungEnthaelt];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktProduktEnthaelt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RohstoffeInProdukte] DROP CONSTRAINT [FK_ProduktProduktEnthaelt];
GO
IF OBJECT_ID(N'[dbo].[FK_RohstoffProduktEnthaelt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RohstoffeInProdukte] DROP CONSTRAINT [FK_RohstoffProduktEnthaelt];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bestellungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bestellungen];
GO
IF OBJECT_ID(N'[dbo].[Kunden]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kunden];
GO
IF OBJECT_ID(N'[dbo].[Produkte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produkte];
GO
IF OBJECT_ID(N'[dbo].[ProdukteInBestellungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdukteInBestellungen];
GO
IF OBJECT_ID(N'[dbo].[Rohstoffe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rohstoffe];
GO
IF OBJECT_ID(N'[dbo].[RohstoffeInProdukte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RohstoffeInProdukte];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bestellungen'
CREATE TABLE [dbo].[Bestellungen] (
    [BestellID] int IDENTITY(1,1) NOT NULL,
    [Abholdatum] datetime  NOT NULL,
    [KundenID] int  NOT NULL
);
GO

-- Creating table 'Kunden'
CREATE TABLE [dbo].[Kunden] (
    [KundenID] int IDENTITY(1,1) NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Nachname] nvarchar(max)  NOT NULL,
    [Telefonnummer] nvarchar(max)  NOT NULL,
    [EMail] nvarchar(max)  NOT NULL,
    [Adresse] nvarchar(max)  NOT NULL,
    [PLZ] nvarchar(max)  NULL,
    [Ort] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Produkte'
CREATE TABLE [dbo].[Produkte] (
    [ProduktID] int IDENTITY(1,1) NOT NULL,
    [Produktname] nvarchar(max)  NOT NULL,
    [Produktpreis] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProdukteInBestellungen'
CREATE TABLE [dbo].[ProdukteInBestellungen] (
    [BestellungEnthaeltID] int IDENTITY(1,1) NOT NULL,
    [BestellMenge] nvarchar(max)  NOT NULL,
    [BestellID] int  NOT NULL,
    [ProduktID] int  NOT NULL
);
GO

-- Creating table 'Rohstoffe'
CREATE TABLE [dbo].[Rohstoffe] (
    [RohstoffID] int IDENTITY(1,1) NOT NULL,
    [Rohstoffname] nvarchar(max)  NOT NULL,
    [Rohstoffeinheit] nvarchar(max)  NOT NULL,
    [Rohstoffpreis] float  NOT NULL,
    [Lagermenge] int  NOT NULL
);
GO

-- Creating table 'RohstoffeInProdukte'
CREATE TABLE [dbo].[RohstoffeInProdukte] (
    [ProduktEnthaeltID] int IDENTITY(1,1) NOT NULL,
    [RohstoffMenge] int  NOT NULL,
    [ProduktID] int  NOT NULL,
    [RohstoffID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BestellID] in table 'Bestellungen'
ALTER TABLE [dbo].[Bestellungen]
ADD CONSTRAINT [PK_Bestellungen]
    PRIMARY KEY CLUSTERED ([BestellID] ASC);
GO

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

-- Creating primary key on [BestellungEnthaeltID] in table 'ProdukteInBestellungen'
ALTER TABLE [dbo].[ProdukteInBestellungen]
ADD CONSTRAINT [PK_ProdukteInBestellungen]
    PRIMARY KEY CLUSTERED ([BestellungEnthaeltID] ASC);
GO

-- Creating primary key on [RohstoffID] in table 'Rohstoffe'
ALTER TABLE [dbo].[Rohstoffe]
ADD CONSTRAINT [PK_Rohstoffe]
    PRIMARY KEY CLUSTERED ([RohstoffID] ASC);
GO

-- Creating primary key on [ProduktEnthaeltID] in table 'RohstoffeInProdukte'
ALTER TABLE [dbo].[RohstoffeInProdukte]
ADD CONSTRAINT [PK_RohstoffeInProdukte]
    PRIMARY KEY CLUSTERED ([ProduktEnthaeltID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BestellID] in table 'ProdukteInBestellungen'
ALTER TABLE [dbo].[ProdukteInBestellungen]
ADD CONSTRAINT [FK_BestellungBestellungEnthaelt]
    FOREIGN KEY ([BestellID])
    REFERENCES [dbo].[Bestellungen]
        ([BestellID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BestellungBestellungEnthaelt'
CREATE INDEX [IX_FK_BestellungBestellungEnthaelt]
ON [dbo].[ProdukteInBestellungen]
    ([BestellID]);
GO

-- Creating foreign key on [KundenID] in table 'Bestellungen'
ALTER TABLE [dbo].[Bestellungen]
ADD CONSTRAINT [FK_KundeBestellung]
    FOREIGN KEY ([KundenID])
    REFERENCES [dbo].[Kunden]
        ([KundenID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KundeBestellung'
CREATE INDEX [IX_FK_KundeBestellung]
ON [dbo].[Bestellungen]
    ([KundenID]);
GO

-- Creating foreign key on [ProduktID] in table 'ProdukteInBestellungen'
ALTER TABLE [dbo].[ProdukteInBestellungen]
ADD CONSTRAINT [FK_ProduktBestellungEnthaelt]
    FOREIGN KEY ([ProduktID])
    REFERENCES [dbo].[Produkte]
        ([ProduktID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktBestellungEnthaelt'
CREATE INDEX [IX_FK_ProduktBestellungEnthaelt]
ON [dbo].[ProdukteInBestellungen]
    ([ProduktID]);
GO

-- Creating foreign key on [ProduktID] in table 'RohstoffeInProdukte'
ALTER TABLE [dbo].[RohstoffeInProdukte]
ADD CONSTRAINT [FK_ProduktProduktEnthaelt]
    FOREIGN KEY ([ProduktID])
    REFERENCES [dbo].[Produkte]
        ([ProduktID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktProduktEnthaelt'
CREATE INDEX [IX_FK_ProduktProduktEnthaelt]
ON [dbo].[RohstoffeInProdukte]
    ([ProduktID]);
GO

-- Creating foreign key on [RohstoffID] in table 'RohstoffeInProdukte'
ALTER TABLE [dbo].[RohstoffeInProdukte]
ADD CONSTRAINT [FK_RohstoffProduktEnthaelt]
    FOREIGN KEY ([RohstoffID])
    REFERENCES [dbo].[Rohstoffe]
        ([RohstoffID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RohstoffProduktEnthaelt'
CREATE INDEX [IX_FK_RohstoffProduktEnthaelt]
ON [dbo].[RohstoffeInProdukte]
    ([RohstoffID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------