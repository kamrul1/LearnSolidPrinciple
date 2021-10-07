using System.Text.Json;

namespace LearnSolidPrinciple.Rating
{
    public class JsonPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string policyJson)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var policy = JsonSerializer.Deserialize<Policy>(policyJson, options);
            return policy;
        }
    }
}