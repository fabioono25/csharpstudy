using System.Numerics;

namespace CSharpStudy.Tests.CSharp11
{
    public class GenericMath
    {
        // Generic math allows defining algorithms for any number type
        public T Add<T>(T a, T b) where T : INumber<T>
        {
            return a + b;
        }

        [Fact]
        public void GenericMath_Example()
        {
            Assert.Equal(3, Add(1, 2));
            Assert.Equal(3.5, Add(1.5, 2.0));
            Assert.Equal(3.5m, Add(1.5m, 2.0m));
        }
    }
}
