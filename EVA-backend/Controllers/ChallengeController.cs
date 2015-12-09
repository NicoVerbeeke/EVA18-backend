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

        [Route("testconnection")]
        [AcceptVerbs("GET")]
        public String TestConnection()
        {
            return "it worked";
        }

        [Authorize]
        public IEnumerable<ChallengeDataObject> Get()
        {
            return _challengeAdapter.GetChallenges();
        }       

        

        [Route("GetChallengeVariants/{number}")]
        [AcceptVerbs("GET")]
        public IEnumerable<String> GetRandomVariants(int number)
        {
            return _challengeAdapter.GetRandomVariants(number);
        }

        [Authorize]
        [Route("GetRandomChallenges/{number}")]
        public IEnumerable<ChallengeDataObject> GetRandomChallenges(int number)
        {
            return _challengeAdapter.GetRandomChallenges(number);
        }

        [Authorize]
        [AcceptVerbs("POST")]
        [Route("ChooseChallenge")]
        public void ChooseChallenge([FromBody] string email, [FromBody] int challengeId)
        {
            _challengeAdapter.ChooseChallenge(email, challengeId);
        }

        [AcceptVerbs("GET")]
        [Route("SetUpDemoData")]
        public void SetUpDemoData()
        {
            _challengeAdapter.SetUpDemoData();
        }
    }

}
