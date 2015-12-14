using EVA_backend.DataLayer;
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
    public class ChallengeBusinessComponentAdapter
    {
        //Creating the datacontext
        private DbContext _db;
        private ChallengeRepository _chalRepo;
        private ScoreRepository _scoreRepo;
        private UserRepository _userRepo;
        private DbContext _auth;

        public ChallengeBusinessComponentAdapter()
        {
            _db = Eva18Singleton.Db;
            _auth = new AuthContext();
            _chalRepo = new ChallengeRepository();
            _scoreRepo = new ScoreRepository();
            _userRepo = new UserRepository();
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

        public ChosenChallenge IsChallengeChosen(string email)
        {
            User u = _userRepo.GetUserByEmail(email);
            Score s = _scoreRepo.GetLastValidUserScore(u);
            DateTime dayLaterThenStartTime = DateTime.Now;
            if (s != null)
            {
                DateTime d = s.TimeStarted;
                dayLaterThenStartTime = new DateTime(d.Year, d.Month, d.Day + 1, d.Hour, d.Minute, d.Second);
            }
            ChosenChallenge challengeChosen = new ChosenChallenge();

            if (s==null || (DateTime.Now > dayLaterThenStartTime))
            {
                challengeChosen.ChallengeChosen = false;
            }
            else {
                challengeChosen.ChallengeChosen = true;
            }

            if (s != null && s.Challenge != null)
            {
                challengeChosen.CurrentChallenge = MapChallenge(s.Challenge);
            }
            else
            {
                challengeChosen.CurrentChallenge = new ChallengeDataObject();
            }
            return challengeChosen;
        }

        public Boolean IsChallengeChosen(Score s)
        {
            Boolean IsChallengeChosen = false;

            if (s != null)
            {
                if (!s.Completed)
                {
                    IsChallengeChosen = true;
                }
            }

            return IsChallengeChosen;
        }


        public ChallengeDataObject MapChallenge(Challenge chal)
        {
            Random r = new Random();
            ChallengeDataObject dto = new ChallengeDataObject();
            dto.Id = chal.Id;
            dto.Title = chal.Title;
            dto.Image = chal.Image;
            dto.Description = chal.Description;
            dto.Difficulty = chal.Difficulty;
            dto.Variant = chal.ChallengeVariants.First().Name;
            return dto;
        }

        public void ChooseChallenge(string email, int challengeId)
        {
            User u = _db.Set<User>().Where(x => x.Email.Equals(email)).FirstOrDefault();
            _scoreRepo.AddNewScore(u, challengeId);
        }

        public void CompleteChallenge( string email, int challengeId, bool passed)
        {
            User u = _db.Set<User>().Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (u != null && passed)
            {
                _scoreRepo.UpdateScore(u, challengeId);
            }
        }

        public IEnumerable<String> GetRandomVariants(int number)
        {
            return _chalRepo.GetRandomVariants(number);
        }

        public IEnumerable<ChallengeDataObject> GetRandomChallenges(int number)
        {
            
            List<String> variants = _chalRepo.GetAllChallengeVariants().ToList();
            Random r = new Random();
            List<ChallengeDataObject> chosenChallenges = new List<ChallengeDataObject>();
            List<Challenge> challenges = _chalRepo.GetAllChallenges().ToList();
            if(challenges.Count < number)
            {
                number = challenges.Count;
            }
            while(chosenChallenges.Count < number) { 
                do
                {
                    int randomVariant = r.Next(0, 2);
                    challenges = _chalRepo.GetAllChallengesForVariant(variants[randomVariant]).ToList();
                } while (challenges.Count <= 0);
                int random;          
                random = r.Next(0, challenges.Count);

                _db.Entry(challenges[random]).Reload();
                Challenge ch = _db.Set<Challenge>().Find(challenges[random].Id);
                ChallengeDataObject candidate = MapChallenge(ch);
                bool distinct = true;
                foreach(ChallengeDataObject c in chosenChallenges)
                {
                    if (c.Title.Equals(candidate.Title)){
                        distinct = false;
                    }
                }

                if (distinct) {
                    chosenChallenges.Add(candidate);
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