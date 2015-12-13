using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVA_backend.Models
{
    public class VariantScoreModel
    {
        public String Variant { get; set; }
        public int CompletedVariantChallenges { get; set; }
        public int Score { get; set; }
    }
}