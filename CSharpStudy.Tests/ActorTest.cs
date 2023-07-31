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

            var currentActor = new Actor("John") { ActorAge = 22 };

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


        [Fact]
        public void TestGetAgency() //object needed once
        {
            //arrange
            var currentActor = new Actor();
            var expected = "Prestige Talent";

            //act
            var result = currentActor.GetAgency();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetAgencyByProp() //object needed always
        {
            //arrange
            var currentActor = new Actor();
            var expected = "Prestige Talent";

            //act
            var result = currentActor.GetAgencyByProp();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetAgencySometimes() //object needed sometimes - lazy loading
        {
            //arrange
            var currentActor = new Actor();
            var expected = "Prestige Talent";

            //act
            var result = currentActor.GetAgencyByProp2();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestOpenFile()
        {

        }
    }
}
