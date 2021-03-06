using LearnSolidPrinciple.Rating.Core.Interfaces;
using LearnSolidPrinciple.Rating.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearnSolidPrinciple.Rating.Test
{
    //Mock object would be quicker as Fake classes would not be needed.
    public class FakeLogger : ILogger
    {
        public List<string> LoggedMessages { get; } = new List<string>();
        public void Log(string message)
        {
            LoggedMessages.Add(message);
        }
    }

    public class FakeRatingUpdater 
    {
        public decimal? NewRating { get; private set; }
        public void UpdateRating(decimal rating)
        {
            NewRating = rating;
        }
    }

    public class AutoPolicyRaterRateTest
    {
        [Fact]
        public void LogsMakeRequiredMessageGivenPolicyWithoutMake()
        {
            var policy = new Policy() { Type = "Auto" };
            var logger = new FakeLogger();
            var rater = new AutoPolicyRater(null);
            rater.Logger = logger;

            rater.Rate(policy);

            Assert.Equal("Auto policy must specify Make", logger.LoggedMessages.Last());
        }

        [Fact]
        public void SetsRatingTo1000ForBMWWith250Deductible()
        {
            var policy = new Policy()
            {
                Type = "Auto",
                Make = "BMW",
                Deductible = 250m
            };
            var ratingUpdater = new FakeRatingUpdater();
            var rater = new AutoPolicyRater(new FakeLogger());

            rater.Rate(policy);

            Assert.Equal(1000m, ratingUpdater.NewRating.Value);
        }

        [Fact]
        public void SetsRatingTo900ForBMWWith500Deductible()
        {
            var policy = new Policy()
            {
                Type = "Auto",
                Make = "BMW",
                Deductible = 500m
            };
            var ratingUpdater = new FakeRatingUpdater();
            var rater = new AutoPolicyRater(new FakeLogger());

            rater.Rate(policy);

            Assert.Equal(900m, ratingUpdater.NewRating.Value);
        }

    }
}
