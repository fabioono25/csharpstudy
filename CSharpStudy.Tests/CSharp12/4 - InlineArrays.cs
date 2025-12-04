namespace CSharpStudy.Tests.CSharp12
{
    public class InlineArrays
    {
        // Inline array using InlineArray attribute (C# 12 feature)
        [System.Runtime.CompilerServices.InlineArray(10)]
        public struct Buffer10<T>
        {
            private T _element0;
        }

        [Fact]
        public void InlineArray_Example()
        {
            Buffer10<int> buffer = default;
            
            // Access like an array
            for (int i = 0; i < 10; i++)
            {
                buffer[i] = i * 2;
            }
            
            Assert.Equal(0, buffer[0]);
            Assert.Equal(18, buffer[9]);
        }
    }
}
