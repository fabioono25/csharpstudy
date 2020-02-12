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

        [Fact]
        public void TestBookActor()
        {
            //arrange
            var details = "Booking can change";
            
            var currentActor = new Actor("John");

            var expected = "Actor John is booked. Details: " + details;

            //act
            var result = currentActor.BookActor();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestBookActorWithParameter()
        {
            //arrange
            var details = "Booking can change";

            var currentActor = new Actor("John");

            var expected = "Actor John is booked on " + DateTime.Today.ToShortDateString() + ". Details: " + details;

            //act
            var result = currentActor.BookActor(DateTime.Today.ToShortDateString());

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestFormatingOnSetterForBookActor()
        {
            //arrange
            var details = "Booking can change";

            var currentActor = new Actor("John");

            var expected = "Actor John is booked on " + DateTime.Today.ToShortDateString() + ". Details: " + details;

            //act
            var result = currentActor.BookActor(DateTime.Today.ToShortDateString());

            //assert
            Assert.Equal(expected, result);
        }
    }
}
