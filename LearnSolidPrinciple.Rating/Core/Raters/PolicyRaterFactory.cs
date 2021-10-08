using LearnSolidPrinciple.Rating.Core.Interfaces;
using LearnSolidPrinciple.Rating.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating
{
    public class PolicyRaterFactory
    {
        private readonly ILogger logger;

        public PolicyRaterFactory(ILogger logger)
        {
            this.logger = logger;
        }
        public PolicyRaterAbstract Create(Policy policy)
        {


            try
            {
                return (PolicyRaterAbstract)Activator.CreateInstance(
                    Type.GetType($"LearnSolidPrinciple.Rating.{policy.Type}PolicyRater"),
                        new object[] { logger });
            }
            catch
            {
                return new UnknownPolicyRater(logger);
            }
        }
    }
}
