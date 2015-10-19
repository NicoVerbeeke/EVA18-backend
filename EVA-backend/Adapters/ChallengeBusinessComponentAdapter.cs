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
        private DbContext _db = new EVA18Entities();

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
    }
}