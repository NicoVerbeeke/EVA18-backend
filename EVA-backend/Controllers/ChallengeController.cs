using EVA_backend.Adapters;
using EVA_backend.DataModels;
using EVA_backend.Entities;
using EVA_backend.Models;
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
        private UserBusinessComponentAdapter _userAdapter = new UserBusinessComponentAdapter();

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
        public void ChooseChallenge(ChooseChallengeHelper helper)
        {
            _challengeAdapter.ChooseChallenge(helper.Email, helper.ChallengeId);
        }

        [Authorize]
        [AcceptVerbs("POST")]
        [Route("CompleteChallenge")]
        public void CompleteChallenge(CompleteChallengeHelper helper)
        {
            _challengeAdapter.CompleteChallenge(helper.Email, helper.ChallengeId, helper.Passed);
        }

        [AcceptVerbs("GET")]
        [Route("SetUpDemoData")]
        public void SetUpDemoData()
        {
            _challengeAdapter.SetUpDemoData();
        }

        [AcceptVerbs("GET")]
        [Route("getchosenchallenge")]
        public ChosenChallenge GetChosenChallenge(string email)
        {
            return _userAdapter.GetActiveChallenge(email);
        }
    }

}

public class ChooseChallengeHelper
{
    public String Email { get; set; }
    public int ChallengeId { get; set; }
}

public class CompleteChallengeHelper
{
    public String Email { get; set; }
    public int ChallengeId { get; set; }
    public bool Passed { get; set; }
}
