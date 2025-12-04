using System.Runtime.CompilerServices;

namespace CSharpStudy.Tests.CSharp13
{
    /**
     * Overload Resolution Priority allows specifying which overload the compiler should prefer.
     * Useful for performance when you want to favor Span<T> over IEnumerable<T>.
     * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-13.0/overload-resolution-priority
     **/
    public class OverloadResolutionPriority
    {
        [Fact]
        public void OverloadResolution_Example()
        {
            var items = new[] { 1, 2, 3 };
            var result = Process(items);
            
            // Should call the Span overload due to priority
            Assert.Equal("Span", result);
        }

        [OverloadResolutionPriority(1)]
        public string Process(ReadOnlySpan<int> items) => "Span";

        [OverloadResolutionPriority(0)]
        public string Process(IEnumerable<int> items) => "IEnumerable";
    }
}
