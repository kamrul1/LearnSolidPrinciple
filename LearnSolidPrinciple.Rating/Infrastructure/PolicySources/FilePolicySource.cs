using LearnSolidPrinciple.Rating.Core.Interfaces;
using System.IO;

namespace LearnSolidPrinciple.Rating
{

    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }

    
}