DELETE [dbo].[ChallengeTag]
DELETE [dbo].[ScoreSet]
DELETE [dbo].[DifficultySet]
DELETE [dbo].[RatingSet]
DELETE [dbo].[ChallengeSet]
DELETE [dbo].[TagSet]
DELETE [dbo].[UserSet]

GO

SET IDENTITY_INSERT [dbo].[DifficultySet] ON

INSERT INTO [dbo].[DifficultySet] ([Id], [Level], [Num_Level]) VALUES (1, 'Omnivoor', 1);
INSERT INTO [dbo].[DifficultySet] ([Id], [Level], [Num_Level]) VALUES (2, 'Pescotariër (geen vlees, wel vis)', 2);
INSERT INTO [dbo].[DifficultySet] ([Id], [Level], [Num_Level]) VALUES (3, 'Parttime-vegetariër (Minstens 3 keer per week vegetarisch)', 3);
INSERT INTO [dbo].[DifficultySet] ([Id], [Level], [Num_Level]) VALUES (4, 'Vegetariër (geen vlees of vis)', 4);
INSERT INTO [dbo].[DifficultySet] ([Id], [Level], [Num_Level]) VALUES (5, 'Veganist (geen dierlijke producten)', 5);