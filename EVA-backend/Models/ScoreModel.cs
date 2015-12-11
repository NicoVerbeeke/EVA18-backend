using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVA_backend.Models
{
    public class ScoreModel
    {
        public int TotalScore
        {
            get; set;
        }

        public int TotalChallengesCompleted
        {
            get; set;
        }

        public List<VariantScoreModel> VariantScores
        {
            get; set;
        }
    }
}