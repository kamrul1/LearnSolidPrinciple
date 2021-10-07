using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating
{
    public class PolicyRaterFactory
    {
        public PolicyRaterAbstract Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (PolicyRaterAbstract)Activator.CreateInstance(
                    Type.GetType($"LearnSolidPrinciple.Rating.{policy.Type}PolicyRater"),
                        new object[] { engine, engine.Logger });
            }
            catch
            {
                return null;
            }
        }
    }
}
