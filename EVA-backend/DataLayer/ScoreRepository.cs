using EVA_backend.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EVA_backend.DataLayer
{
    public class ScoreRepository
    {
        //Creating the datacontext
        private DbContext _db = new EVA18Entities();

        public void AddNewScore(User u, int challengeId)
        {
            Challenge challenge = _db.Set<Challenge>().Where(x => x.Id == challengeId).FirstOrDefault();

            _db.Set<Score>().Add(new Score()
            {
                Challenge = challenge,
                User = u,
                UserId = u.Id,
                Points = 0
            });
        }

        private int CalculateScore(int userDifficulty, int challengeDifficulty)
        {
            return userDifficulty >= challengeDifficulty ? 100 : 50;
        }

        public void UpdateScore(User u, int challengeId)
        {
            Challenge challenge = _db.Set<Challenge>().Where(x => x.Id == challengeId).FirstOrDefault();

            Score score = _db.Set<Score>().Where(x => (x.UserId == u.Id) && (x.Challenge.Id == challenge.Id)).FirstOrDefault();
            score.Points = CalculateScore(u.Difficulty, challenge.Difficulty);
            _db.SaveChanges();
        }

        public List<Score> GetAllUserScores(User u)
        {
            return _db.Set<Score>().Where(x => x.UserId == u.Id).ToList();
        }

        public int GetUserScore(User u)
        {
            List<Score> scores = GetAllUserScores(u);

            int totalScore = 0;

            foreach(Score s in scores)
            {
                totalScore += s.Points;
            }

            return totalScore;
        }
    }
}