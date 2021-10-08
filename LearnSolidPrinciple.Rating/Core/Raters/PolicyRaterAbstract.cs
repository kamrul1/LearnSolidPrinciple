using LearnSolidPrinciple.Rating.Core.Interfaces;
using LearnSolidPrinciple.Rating.Core.Model;

namespace LearnSolidPrinciple.Rating
{
    public abstract class PolicyRaterAbstract
    {
        public ILogger Logger;

        public PolicyRaterAbstract(ILogger logger)
        {
            this.Logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}