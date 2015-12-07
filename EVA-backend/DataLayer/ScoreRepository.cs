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
            _db.Set<Score>().Add(new Score()
            {
                Challenge = _db.Set<Challenge>().Where(x => x.Id == challengeId).FirstOrDefault(),
                User = u,
                UserId = u.Id,
                Points = 0
            });
        }
    }
}