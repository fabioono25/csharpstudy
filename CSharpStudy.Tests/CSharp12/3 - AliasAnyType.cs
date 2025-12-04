namespace CSharpStudy.Tests.CSharp12
{
    /**
    * 
    **/
    using Point = (int X, int Y);
    using IntArray = int[];

    public class AliasAnyType
    {
        [Fact]
        public void AliasAnyType_Example()
        {
            Point p = (10, 20);
            Assert.Equal(10, p.X);
            Assert.Equal(20, p.Y);

            IntArray numbers = { 1, 2, 3 };
            Assert.Equal(3, numbers.Length);
        }
    }
}
