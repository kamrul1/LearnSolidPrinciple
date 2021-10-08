using LearnSolidPrinciple.Rating.Infrastructure.Serializers;
using System;

namespace LearnSolidPrinciple.Rating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");
            var logger = new FileLogger();

            var engine = new RatingEngine(logger,
                new FilePolicySource(),
                new JsonPolicySerializer(),
                new PolicyRaterFactory(logger));

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }
        }
    }
}
