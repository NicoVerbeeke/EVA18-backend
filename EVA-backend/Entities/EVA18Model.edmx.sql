
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2015 18:02:23
-- Generated from EDMX file: C:\Users\Nico\Documents\Projecten TILE\EVA18-backend\EVA-backend\Entities\EVA18Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EVA18];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ChallengeSet'
CREATE TABLE [dbo].[ChallengeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ChallengeSet'
ALTER TABLE [dbo].[ChallengeSet]
ADD CONSTRAINT [PK_ChallengeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------