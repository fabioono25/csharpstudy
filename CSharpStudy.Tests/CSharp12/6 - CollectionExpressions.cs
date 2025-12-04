namespace CSharpStudy.Tests.CSharp12
{
    public class CollectionExpressions
    {
        [Fact]
        public void CollectionExpressions_Example()
        {
            // Array
            int[] a = [1, 2, 3];
            Assert.Equal(3, a.Length);

            // List
            List<int> b = [4, 5, 6];
            Assert.Equal(3, b.Count);

            // Spread operator
            int[] c = [.. a, .. b];
            Assert.Equal(6, c.Length);
            Assert.Equal(1, c[0]);
            Assert.Equal(4, c[3]);
        }
    }
}
