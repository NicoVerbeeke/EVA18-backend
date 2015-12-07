using EVA_backend.DataLayer;
using EVA_backend.DataModels;
using EVA_backend.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EVA_backend.Adapters
{
    public class ChallengeBusinessComponentAdapter
    {
        //Creating the datacontext
        private DbContext _db;
        private ChallengeRepository _chalRepo;
        private ScoreRepository _scoreRepo;
        private DbContext _auth;

        public ChallengeBusinessComponentAdapter()
        {
            _db = new EVA18Entities();
            _auth = new AuthContext();
            _chalRepo = new ChallengeRepository();
            _scoreRepo = new ScoreRepository();
        }

        public IEnumerable<ChallengeDataObject> GetChallenges()
        {
            List<Challenge> challenges = _db.Set<Challenge>().ToList();
            List<ChallengeDataObject> mappedChallenges = new List<ChallengeDataObject>();

            foreach(Challenge c in challenges)
            {
                mappedChallenges.Add(MapChallenge(c));
            }

            return mappedChallenges.AsEnumerable();
        }

        public ChallengeDataObject MapChallenge(Challenge chal)
        {
            ChallengeDataObject dto = new ChallengeDataObject();
            dto.Title = chal.Title;
            dto.Image = chal.Image;
            dto.Description = chal.Description;

            return dto;
        }

        public void ChooseChallenge(string email, int challengeId)
        {
            User u = _db.Set<User>().Where(x => x.Email.Equals(email)).FirstOrDefault();
            _scoreRepo.AddNewScore(u, challengeId);
        }

        public IEnumerable<String> GetRandomVariants(int number)
        {
            return _chalRepo.GetRandomVariants(number);
        }

        public IEnumerable<ChallengeDataObject> GetRandomChallenges(int number, string variant)
        {
            List<Challenge> challenges = _chalRepo.GetAllChallengesForVariant(variant).ToList();
            List<ChallengeDataObject> chosenChallenges = new List<ChallengeDataObject>();
            Random r = new Random();

            if (challenges.Count > 0)
            {
                for (int i = 0; i < number; i++)
                {
                    if (i < challenges.Count)
                    {
                        int random = r.Next(0, challenges.Count);
                        chosenChallenges.Add(this.MapChallenge(challenges[random]));
                        challenges.Remove(challenges[random]);
                    }
                }
            }

            return chosenChallenges;
        }

        public void SetUpDemoData()
        {
            _chalRepo.SetUpDemoData();
        }
    }
}