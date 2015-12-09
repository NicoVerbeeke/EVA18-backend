using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EVA_backend.DataModels
{
    public class ChallengeDataObject
    {
        public String Title { get; set; }

        public String Description { get; set; }

        //Link to an image
        public String Image { get; set; }

        public int Difficulty { get; set; }

        public String Variant { get; set; }
    }
}