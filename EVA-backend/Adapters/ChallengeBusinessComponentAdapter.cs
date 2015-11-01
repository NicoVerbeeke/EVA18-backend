﻿using EVA_backend.DataLayer;
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

        public ChallengeBusinessComponentAdapter()
        {
            _db = new EVA18Entities();
            _chalRepo = new ChallengeRepository();
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

        public IEnumerable<String> GetRandomVariants(int number)
        {
            return _chalRepo.GetRandomVariants(number);
        }
    }
}