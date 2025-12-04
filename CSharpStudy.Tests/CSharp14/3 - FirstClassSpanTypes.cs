namespace CSharpStudy.Tests.CSharp14
{
    /**
     * First-Class Span Types - C# 14 improvements
     * More implicit conversions make Span<T> easier to use
     * https://github.com/dotnet/csharplang/blob/main/proposals/first-class-span-types.md
     **/
    public class FirstClassSpanTypes
    {
        [Fact]
        public void Span_BasicUsage()
        {
            // Spans are high-performance, stack-allocated types
            Span<int> numbers = stackalloc int[3] { 1, 2, 3 };
            
            Assert.Equal(3, numbers.Length);
            Assert.Equal(1, numbers[0]);
        }

        [Fact]
        public void Span_FromArray()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Span<int> span = array.AsSpan();
            
            // Slice without allocation
            Span<int> slice = span.Slice(1, 3);
            Assert.Equal(3, slice.Length);
            Assert.Equal(2, slice[0]);
        }

        [Fact]
        public void ReadOnlySpan_StringOperations()
        {
            string text = "Hello, World!";
            ReadOnlySpan<char> span = text.AsSpan();
            
            // Efficient substring without allocation
            ReadOnlySpan<char> hello = span.Slice(0, 5);
            Assert.True(hello.SequenceEqual("Hello".AsSpan()));
        }

        [Fact]
        public void Span_Modifications()
        {
            Span<int> numbers = stackalloc int[5];
            
            // Fill span
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i * 2;
            }
            
            Assert.Equal(0, numbers[0]);
            Assert.Equal(8, numbers[4]);
        }

        private void ProcessData(ReadOnlySpan<byte> data)
        {
            // C# 14 makes passing spans even more natural
            // with more implicit conversions
            Assert.True(data.Length >= 0);
        }

        [Fact]
        public void Span_ImplicitConversions()
        {
            byte[] array = { 1, 2, 3 };
            
            // C# 14 improves implicit conversions for spans
            ProcessData(array); // Array to ReadOnlySpan implicit
            ProcessData(new byte[] { 4, 5 }); // Inline array to span
        }
    }
}
