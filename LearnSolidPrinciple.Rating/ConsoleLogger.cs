using System;

namespace LearnSolidPrinciple.Rating
{

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}