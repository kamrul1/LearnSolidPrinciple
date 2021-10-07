using System;

namespace LearnSolidPrinciple.Rating
{


    /// <summary>
    /// The RatingEngine reads the policy application details from a file and 
    /// produces a numeric rating value based on the details
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        //
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();

        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public void Rate()
        {

            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            //load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource();
            Policy policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new PolicyRaterFactory();

            var policyRaterAbstract = factory.Create(policy, this);
            policyRaterAbstract?.Rate(policy);

            Logger.Log("Rating completed.");

        }
    }
}