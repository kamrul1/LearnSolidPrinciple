using LearnSolidPrinciple.Rating.Core.Interfaces;
using LearnSolidPrinciple.Rating.Core.Model;
using System;

namespace LearnSolidPrinciple.Rating
{


    /// <summary>
    /// The RatingEngine reads the policy application details from a file and 
    /// produces a numeric rating value based on the details
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger logger;
        private readonly IPolicySource policySource;
        private readonly IPolicySerializer policySerializer;
        private readonly PolicyRaterFactory raterFactory;

        public decimal Rating { get; set; }

        public RatingEngine(ILogger logger,
            IPolicySource policySource,
            IPolicySerializer policySerializer,
            PolicyRaterFactory raterFactory)
        {
            this.logger = logger;
            this.policySource = policySource;
            this.policySerializer = policySerializer;
            this.raterFactory = raterFactory;
        }


        public void Rate()
        {

            logger.Log("Starting rate.");

            logger.Log("Loading policy.");

            //load policy - open file policy.json
            string policyJson = policySource.GetPolicyFromSource();
            Policy policy = policySerializer.GetPolicyFromString(policyJson);

            var policyRaterAbstract = raterFactory.Create(policy);
            policyRaterAbstract.Rate(policy);

            logger.Log("Rating completed.");

        }
    }
}