using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating
{
    public class LandPolicyRater : PolicyRaterAbstract
    {
        public LandPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate(Policy policy)
        {
            logger.Log("Rating LAND policy...");
            logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }

            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                logger.Log("Insufficient bond amount");
                return;
            }

            engine.Rating = policy.BondAmount * 0.5m;
        }
    }
}
