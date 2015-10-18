using EVA_backend.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EVA_backend.Controllers
{
    [RoutePrefix("api/challenge")]
    public class ChallengeController : ApiController
    {
        private DbContext db = new EVA18Entities();
        public IEnumerable<string> Get()
        {
            List<String> output = new List<string>();
            List<Challenge> challenges = db.Set<Challenge>().ToList();
            foreach(Challenge c in challenges)
            {
                output.Add(c.Title);
            }

            return output.AsEnumerable();
        }       

    }
}
