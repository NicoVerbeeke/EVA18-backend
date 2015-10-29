
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2015 19:17:45
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

IF OBJECT_ID(N'[dbo].[FK_ChallengeTag_Challenge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChallengeTag] DROP CONSTRAINT [FK_ChallengeTag_Challenge];
GO
IF OBJECT_ID(N'[dbo].[FK_ChallengeTag_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChallengeTag] DROP CONSTRAINT [FK_ChallengeTag_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_ChallengeDifficulty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChallengeSet] DROP CONSTRAINT [FK_ChallengeDifficulty];
GO
IF OBJECT_ID(N'[dbo].[FK_ScoreChallenge]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScoreSet] DROP CONSTRAINT [FK_ScoreChallenge];
GO
IF OBJECT_ID(N'[dbo].[FK_UserScore]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScoreSet] DROP CONSTRAINT [FK_UserScore];
GO
IF OBJECT_ID(N'[dbo].[FK_RatingTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RatingSet] DROP CONSTRAINT [FK_RatingTag];
GO
IF OBJECT_ID(N'[dbo].[FK_RatingUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RatingSet] DROP CONSTRAINT [FK_RatingUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ChallengeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChallengeSet];
GO
IF OBJECT_ID(N'[dbo].[DifficultySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DifficultySet];
GO
IF OBJECT_ID(N'[dbo].[TagSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[ScoreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScoreSet];
GO
IF OBJECT_ID(N'[dbo].[RatingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RatingSet];
GO
IF OBJECT_ID(N'[dbo].[ChallengeTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChallengeTag];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ChallengeSet'
CREATE TABLE [dbo].[ChallengeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsRecipeChallenge] bit  NOT NULL,
    [IsSocialChallenge] bit  NOT NULL,
    [IsRestaurantChallenge] bit  NOT NULL,
    [Difficulty_Id] int  NULL
);
GO

-- Creating table 'DifficultySet'
CREATE TABLE [dbo].[DifficultySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Level] nvarchar(max)  NOT NULL,
    [Num_Level] int  NOT NULL
);
GO

-- Creating table 'TagSet'
CREATE TABLE [dbo].[TagSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NmbrOfChildren] int  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [IsStudent] bit  NOT NULL,
    [Language] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL
);
GO

-- Creating table 'ScoreSet'
CREATE TABLE [dbo].[ScoreSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Points] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Challenge_Id] int  NOT NULL
);
GO

-- Creating table 'RatingSet'
CREATE TABLE [dbo].[RatingSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Score] int  NOT NULL,
    [Tag_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'ChallengeTag'
CREATE TABLE [dbo].[ChallengeTag] (
    [Challenge_Id] int  NOT NULL,
    [Tag_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'DifficultySet'
ALTER TABLE [dbo].[DifficultySet]
ADD CONSTRAINT [PK_DifficultySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [PK_TagSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [PK_ScoreSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RatingSet'
ALTER TABLE [dbo].[RatingSet]
ADD CONSTRAINT [PK_RatingSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Challenge_Id], [Tag_Id] in table 'ChallengeTag'
ALTER TABLE [dbo].[ChallengeTag]
ADD CONSTRAINT [PK_ChallengeTag]
    PRIMARY KEY CLUSTERED ([Challenge_Id], [Tag_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Challenge_Id] in table 'ChallengeTag'
ALTER TABLE [dbo].[ChallengeTag]
ADD CONSTRAINT [FK_ChallengeTag_Challenge]
    FOREIGN KEY ([Challenge_Id])
    REFERENCES [dbo].[ChallengeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tag_Id] in table 'ChallengeTag'
ALTER TABLE [dbo].[ChallengeTag]
ADD CONSTRAINT [FK_ChallengeTag_Tag]
    FOREIGN KEY ([Tag_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChallengeTag_Tag'
CREATE INDEX [IX_FK_ChallengeTag_Tag]
ON [dbo].[ChallengeTag]
    ([Tag_Id]);
GO

-- Creating foreign key on [Difficulty_Id] in table 'ChallengeSet'
ALTER TABLE [dbo].[ChallengeSet]
ADD CONSTRAINT [FK_ChallengeDifficulty]
    FOREIGN KEY ([Difficulty_Id])
    REFERENCES [dbo].[DifficultySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChallengeDifficulty'
CREATE INDEX [IX_FK_ChallengeDifficulty]
ON [dbo].[ChallengeSet]
    ([Difficulty_Id]);
GO

-- Creating foreign key on [Challenge_Id] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [FK_ScoreChallenge]
    FOREIGN KEY ([Challenge_Id])
    REFERENCES [dbo].[ChallengeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScoreChallenge'
CREATE INDEX [IX_FK_ScoreChallenge]
ON [dbo].[ScoreSet]
    ([Challenge_Id]);
GO

-- Creating foreign key on [UserId] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [FK_UserScore]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserScore'
CREATE INDEX [IX_FK_UserScore]
ON [dbo].[ScoreSet]
    ([UserId]);
GO

-- Creating foreign key on [Tag_Id] in table 'RatingSet'
ALTER TABLE [dbo].[RatingSet]
ADD CONSTRAINT [FK_RatingTag]
    FOREIGN KEY ([Tag_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RatingTag'
CREATE INDEX [IX_FK_RatingTag]
ON [dbo].[RatingSet]
    ([Tag_Id]);
GO

-- Creating foreign key on [User_Id] in table 'RatingSet'
ALTER TABLE [dbo].[RatingSet]
ADD CONSTRAINT [FK_RatingUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RatingUser'
CREATE INDEX [IX_FK_RatingUser]
ON [dbo].[RatingSet]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------