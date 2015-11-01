DELETE [dbo].[ChallengeTag]
DELETE [dbo].[ScoreSet]
DELETE [dbo].[RatingSet]
DELETE [dbo].[ChallengeSet]
DELETE [dbo].[TagSet]
DELETE [dbo].[UserSet]
DELETE [dbo].[ChallengeVariantSet]

GO

INSERT INTO [dbo].[ChallengeVariantSet] VALUES ('Recipe')
INSERT INTO [dbo].[ChallengeVariantSet] VALUES ('Product')
INSERT INTO [dbo].[ChallengeVariantSet] VALUES ('Social Media')
INSERT INTO [dbo].[ChallengeVariantSet] VALUES ('Restaurants')
INSERT INTO [dbo].[ChallengeVariantSet] VALUES ('Learning')
INSERT INTO [dbo].[ChallengeVariantSet] VALUES ('Friend')
INSERT INTO [dbo].[ChallengeVariantSet] VALUES ('Get Involved')
