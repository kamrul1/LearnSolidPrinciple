using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating
{
    public class PolicyRaterFactory
    {
        public PolicyRaterAbstract Create(Policy policy, IRatingContext context)
        {
            try
            {
                return (PolicyRaterAbstract)Activator.CreateInstance(
                    Type.GetType($"LearnSolidPrinciple.Rating.{policy.Type}PolicyRater"),
                        new object[] { new RatingUpdater(context.Engine) });
            }
            catch
            {
                return new UnknownPolicyRater(new RatingUpdater(context.Engine));
            }
        }
    }
}
