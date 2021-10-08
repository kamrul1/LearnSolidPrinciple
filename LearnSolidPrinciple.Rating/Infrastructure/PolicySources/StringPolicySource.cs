using LearnSolidPrinciple.Rating.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating.Core.Infrastructure.PolicySources
{
    public class StringPolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = "";

        public string GetPolicyFromSource()
        {
            return PolicyString;
        }
    }
}
