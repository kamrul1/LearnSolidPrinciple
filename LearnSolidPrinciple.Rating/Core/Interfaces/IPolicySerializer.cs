using LearnSolidPrinciple.Rating.Core.Model;

namespace LearnSolidPrinciple.Rating.Core.Interfaces
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyJson);
    }
}
