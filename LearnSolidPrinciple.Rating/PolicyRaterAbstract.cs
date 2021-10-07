namespace LearnSolidPrinciple.Rating
{
    public abstract class PolicyRaterAbstract
    {
        protected readonly RatingEngine engine;
        protected readonly ConsoleLogger logger;

        public PolicyRaterAbstract(RatingEngine engine, ConsoleLogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public abstract void Rate(Policy policy);
    }
}