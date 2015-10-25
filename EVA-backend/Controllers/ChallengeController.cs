using EVA_backend.Adapters;
using EVA_backend.DataModels;
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
        private ChallengeBusinessComponentAdapter _challengeAdapter = new ChallengeBusinessComponentAdapter();

        public IEnumerable<ChallengeDataObject> Get()
        {
            return _challengeAdapter.GetChallenges();
        }       
    }
}
