using System;

namespace LearnSolidPrinciple.Rating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var engine = new RatingEngine();
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating:{engine.Rating}"); ;
            } 
            else
            {
                Console.WriteLine("No rating produced");
            }
        }
    }
}
