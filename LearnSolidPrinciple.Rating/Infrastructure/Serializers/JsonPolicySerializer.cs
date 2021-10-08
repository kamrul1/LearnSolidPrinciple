using LearnSolidPrinciple.Rating.Core.Interfaces;
using LearnSolidPrinciple.Rating.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace LearnSolidPrinciple.Rating.Infrastructure.Serializers
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromString(string policyString)
        {
            return JsonConvert.DeserializeObject<Policy>(policyString,
                new StringEnumConverter());
        }
    }
}