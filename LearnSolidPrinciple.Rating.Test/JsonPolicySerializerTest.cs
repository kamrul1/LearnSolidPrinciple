using System;
using Xunit;

namespace LearnSolidPrinciple.Rating.Test
{
    public class JsonPolicySerializerTest
    {
        [Fact]
        public void ShouldReturnDefaultPolicyFromEmptyJsonString()
        {
            //Arrange
            var inputJson = "{}";
            var serializer = new JsonPolicySerializer();

            //Act
            var result = serializer.GetPolicyFromJsonString(inputJson);

            //Assert
            var policy = new Policy();
            Assert.Equal(policy.Address, result.Address);
            Assert.Equal(policy.Amount, result.Amount);
            Assert.Equal(policy.BondAmount, result.BondAmount);
            Assert.Equal(policy.DateOfBirth, result.DateOfBirth);
            Assert.Equal(policy.Deductible, result.Deductible);
            Assert.Equal(policy.FullName, result.FullName);
            Assert.Equal(policy.IsSmoker, result.IsSmoker);
            Assert.Equal(policy.Make, result.Make);
            Assert.Equal(policy.Miles, result.Miles);
            Assert.Equal(policy.Model, result.Model);
            Assert.Equal(policy.Type, result.Type);
            Assert.Equal(policy.Valuation, result.Valuation);
            Assert.Equal(policy.Year, result.Year);
        }
    }
}
