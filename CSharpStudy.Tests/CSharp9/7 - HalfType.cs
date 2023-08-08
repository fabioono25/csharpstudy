namespace CSharpStudy.Tests.CSharp9
{
    /**
    * Half type is a new type that represents a 16-bit floating-point number.
    * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/half-numeric-type
    **/
    public class HalfType
    {
        [Fact]
        public void Example()
        {
            Half half = Half.MaxValue; // 65500
            var max = nint.MaxValue; // 0x7fffffffffffffff

            
        }
    }
}
