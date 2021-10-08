using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating
{
    public class UnknownPolicyRater : PolicyRaterAbstract
    {
        public UnknownPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater)
        {
        }

        public override void Rate(Policy policy)
        {
            logger.Log("Unknown policy type");
        }
    }
}
