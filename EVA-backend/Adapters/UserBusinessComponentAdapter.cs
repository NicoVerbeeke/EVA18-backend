﻿using EVA_backend.DataLayer;
using EVA_backend.DataModels;
using EVA_backend.Entities;
using EVA_backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EVA_backend.Adapters
{
    public class UserBusinessComponentAdapter
    {
        private UserRepository _uRepo;
        private ScoreRepository _scoreRepo;
        private ChallengeBusinessComponentAdapter _chalBCA;
        public UserBusinessComponentAdapter()
        {
            _uRepo = new UserRepository();
            _scoreRepo = new ScoreRepository();
            _chalBCA = new ChallengeBusinessComponentAdapter(); 
        }

        public User MapToUser(UserModel dto)
        {
            return new User()
            {
                NmbrOfChildren = dto.NmbrOfChildren,
                Email = dto.Email,
                UserName = dto.Email,
                IsStudent = dto.IsStudent,
                Language = dto.Language,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                Difficulty = dto.Difficulty,
                SendNewsletter = dto.SendNewsletter
            };
        }

        public UserModel MapToUserModel(User entity)
        {
            if (entity != null)
            {
                return new UserModel()
                {
                    NmbrOfChildren = entity.NmbrOfChildren,
                    Email = entity.Email,
                    UserName = entity.Email,
                    IsStudent = entity.IsStudent,
                    Language = entity.Language,
                    BirthDate = entity.BirthDate,
                    Gender = entity.Gender,
                    Difficulty = entity.Difficulty,
                    SendNewsletter = entity.SendNewsletter
                };
            }
            else return new UserModel();
        }

        public ScoreModel GetUserAccomplishments(String email)
        {
            User u = _uRepo.GetUserByEmail(email);
            List<Score> scores = _scoreRepo.GetAllUserScores(u);
            List<VariantScoreModel> vScoreModels = new List<VariantScoreModel>();
            List<ChallengeDataObject> challenges = new List<ChallengeDataObject>();
            int totalScore = 0;
            int totalChallengesCompleted = 0;

            foreach(Score s in scores)
            {
                ChallengeDataObject chal = _chalBCA.MapChallenge(s.Challenge);

                bool vScoreModelPresent = false;
                foreach(VariantScoreModel v in vScoreModels)
                {
                    if (v.Variant.Equals(chal.Variant))
                    {
                        vScoreModelPresent = true;
                        if (s.Points > 0)
                        {
                            v.CompletedVariantChallenges += 1;
                            v.Score += s.Points;
                            totalChallengesCompleted += 1;
                        }                      

                    }
                }

                if (!vScoreModelPresent)
                {
                    VariantScoreModel vScoreModel = new VariantScoreModel();
                    vScoreModels.Add(vScoreModel);

                    if (s.Points > 0)
                    {
                        vScoreModel.CompletedVariantChallenges = 1;
                        vScoreModel.Score = s.Points;
                        vScoreModel.Variant = chal.Variant;
                        totalChallengesCompleted += 1;
                    }
                    else
                    {
                        vScoreModel.Score = 0;
                        vScoreModel.CompletedVariantChallenges = 0;
                    }
                }

                totalScore += s.Points;
            }

            ScoreModel scoreModel = new ScoreModel();
            scoreModel.TotalScore = totalScore;
            scoreModel.TotalChallengesCompleted = totalChallengesCompleted;
            scoreModel.VariantScores = vScoreModels;

            return scoreModel;
        }

        public int  InsertUser(UserModel dto)
        {
            //first map to user then insert the new entity into the db
          return _uRepo.InsertUser(MapToUser(dto));
        }

        public UserModel GetUserByEmail(string email)
        {
           return MapToUserModel(_uRepo.GetUserByEmail(email));
        }

        public void DeleteUser(UserModel dto)
        {
            _uRepo.DeleteUser(MapToUser(dto));
        }
    }
}