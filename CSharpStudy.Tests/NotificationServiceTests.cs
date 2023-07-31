using CSharpStudy.Common;

namespace CSharpStudy.Tests
{
    public class NotificationServiceTests
    {
        [Fact]
        public void TestNotifyTalent()
        {
            //arrange
            var expected = "Notifying talent: Rey";

            //act
            var actual = NotificationService.NotifyTalent("Rey");

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
