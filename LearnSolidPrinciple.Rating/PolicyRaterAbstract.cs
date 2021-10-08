namespace LearnSolidPrinciple.Rating
{
    public abstract class PolicyRaterAbstract
    {

        protected readonly IRatingUpdater ratingUpdater;
        public ILogger logger { get; set; } = new ConsoleLogger();

        public PolicyRaterAbstract(IRatingUpdater ratingUpdater)
        {

            this.ratingUpdater = ratingUpdater;
        }

        public abstract void Rate(Policy policy);
    }
}