using LearnSolidPrinciple.Rating.Core.Interfaces;

namespace LearnSolidPrinciple.Rating
{
    public class NullLogger : ILogger
    {
        public void Log(string message)
        {
            //do nothing;
        }
    }
}