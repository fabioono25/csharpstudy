using CSharpStudy.BestPractices;
using System;
using Xunit;

namespace CSharpStudy.Tests
{
    public class ActorTest
    {
        [Fact]
        public void TestGetOccupation()
        {
            //arrange
            var currentActor = new Actor();
            var expected = "Actor";

            //act
            string result = currentActor.GetOccupation();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestParameterizedConstructor()
        {
            //arrange
            var currentActor = new Actor("Johnny Boy");
            var expected = "Johnny Boy";

            //act
            var result = currentActor.ActorName;

            //assert
            Assert.Equal(expected, result);
        }
    }
}
