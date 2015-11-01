using EVA_backend.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EVA_backend.DataLayer
{
    public class ChallengeRepository
    {

        //Creating the datacontext
        private DbContext _db = new EVA18Entities();

        public IEnumerable<String> GetAllChallengeVariants()
        {
            IEnumerable<ChallengeVariant> challengeVariants = _db.Set<ChallengeVariant>();
            List<String> variants = new List<String>();

            foreach(ChallengeVariant cv in challengeVariants)
            {
                variants.Add(cv.Name);
            }

            return variants.AsEnumerable();
        }

        public IEnumerable<String> GetRandomVariants(int number)
        {
            List<String> variants = GetAllChallengeVariants().ToList();

            if(!(variants.Count > 0))
            {
                return new List<String>();
            }

            List<String> randomVariants = new List<String>();
            Random r = new Random();
            for (int i = 0; i < number; i++)
            {
                int random = r.Next(0, variants.Count);
                randomVariants.Add(variants[random]);
                variants.Remove(variants[random]);
            }

            return randomVariants;
        }
    }
}