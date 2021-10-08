using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating
{
    public class AutoPolicyRater : PolicyRaterAbstract
    {
        public AutoPolicyRater(IRatingUpdater ratingUpdater)
            :base(ratingUpdater)
        {
        }

        public override void Rate(Policy policy)
        {
            logger.Log("Rating AUTO policy...");
            logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                logger.Log("Auto policy must specify Make");
                return;
            }

            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    ratingUpdater.UpdateRating(100m);
                }
                ratingUpdater.UpdateRating(900m);
            }
        }

    }
}
