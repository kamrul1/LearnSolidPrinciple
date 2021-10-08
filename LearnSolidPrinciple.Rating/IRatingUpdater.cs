using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSolidPrinciple.Rating
{
    public interface IRatingUpdater
    {
        void UpdateRating(decimal rating);
    }
}
