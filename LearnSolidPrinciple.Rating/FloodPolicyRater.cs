﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating
{
    public class FloodPolicyRater : PolicyRaterAbstract
    {
        public FloodPolicyRater(IRatingUpdater ratingUpdater)
            : base(ratingUpdater)
        {
        }

        public override void Rate(Policy policy)
        {
            logger.Log("Rating FLOOD policy...");
            logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                logger.Log("Flood policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                logger.Log("Flood policy is not available for elevations at or below sea level.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                logger.Log("Insufficient bond amount.");
                return;
            }
            decimal multiple = 1.0m;
            if (policy.ElevationAboveSeaLevelFeet < 100)
            {
                multiple = 2.0m;
            }
            else if (policy.ElevationAboveSeaLevelFeet < 500)
            {
                multiple = 1.5m;
            }
            else if (policy.ElevationAboveSeaLevelFeet < 1000)
            {
                multiple = 1.1m;
            }
            ratingUpdater.UpdateRating(policy.BondAmount * 0.05m * multiple);
        }
    }
}
