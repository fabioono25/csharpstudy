namespace CSharpStudy.Tests.CSharp11
{
    /**
    * 
    **/
    public class ListPatterns
    {
        [Fact]
        public void ListPatterns_Example()
        {
            int[] numbers = { 1, 2, 3 };
            
            bool startsWithOneTwo = numbers is [1, 2, ..];
            Assert.True(startsWithOneTwo);

            bool matchSpecific = numbers is [1, _, 3];
            Assert.True(matchSpecific);

            // Capture pattern
            if (numbers is [1, .. var rest])
            {
                Assert.Equal(new[] { 2, 3 }, rest);
            }
        }
    }
}
