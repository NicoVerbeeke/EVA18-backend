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

        internal IEnumerable<Challenge> GetAllChallengesForVariant(string variant)
        {
            ChallengeVariant challengeVariant = _db.Set<ChallengeVariant>().Where(x => x.Name.Equals(variant)).FirstOrDefault();         
          
            return challengeVariant.Challenges;
        }

        public void SetUpDemoData()
        {
            List<ChallengeVariant> challengeVariants = _db.Set<ChallengeVariant>().ToList();
            String eersteRecept = "'bereidingstijd: 15 min \n\r aantal personen: 8 \n\r Ingredienten: \n\r 75 g sojaboter \n\r 75 g tarwebloem \n\r 250 ml groentebouillon \n\r 500 ml ongezoete sojamelk \n\r 3 el gistvlokken(optioneel) \n\r nootmuskaat \n\r peper \n\r zout" +
                "Bereidingswijze: \n\r Smelt de sojaboter op een zacht vuurtje.Meng er vervolgens de tarwebloem door. Laat op een laag vuurtje gedurende 2 minuten koken, blijf voortdurend roeren (deze stap zorgt ervoor dat de saus niet naar bloem smaakt). Voeg heel geleidelijk sojamelk en groentebouillon toe, roer stevig om geen klonters te krijgen.Breng op smaak met peper, zout en nootmuskaat.Voeg, indien gewenst, de gistvlokken toe." +
                "\n\r \n\rTips: \n\r -Dit is een basissaus.Aan deze saus kan vb. 1 el mosterd toegevoegd worden, citroensap, miso, ...";

            _db.Set<Challenge>().Add(new Challenge()
            {
                Description = eersteRecept,
                Difficulty = 5,
                Title = "Plantaardige Béchamelsaus",
                Image = "http://www.evavzw.be/sites/default/files/styles/news_thumbnail/public/faq/bechamelsaus.jpg?itok=1fnUN4ca",
                ChallengeVariants = new List<ChallengeVariant>() { challengeVariants.Where(x => x.Name.Equals("Recipe")).First() }
            });
            _db.SaveChanges();

            String tweedeRecept = "Ga eens een kookworkshop gaan volgen in het gebouw van Eva.";

            Tag tag1 = new Tag() { Name = "Cooking" };
            Tag tag2 = new Tag() { Name = "Eva" };
            Tag tag3 = new Tag() { Name = "Bechamel" };
            
            _db.Set<Challenge>().Add(new Challenge()
            {
                Description = tweedeRecept,
                Difficulty = 3,
                Title = "Kookworkshop",
                Image = "http://www.evavzw.be/sites/default/files/styles/news_thumbnail/public/faq/bechamelsaus.jpg?itok=1fnUN4ca",
                ChallengeVariants = new List<ChallengeVariant>()
                {
                    challengeVariants.Where(x => x.Name.Equals("Recipe")).First()                        
                },
                Tag = new List<Tag>()
                {
                  tag1, tag2, tag3   
                },

            });

            _db.SaveChanges();

            
        }
    }
}