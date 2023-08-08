namespace CSharpStudy.Tests.CSharp9
{
    /**
    * IntPtr Type is a new type that represents a pointer or a handle.
    * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/intptr
    **/
    public class IntPtrType
    {
        [Fact]
        public void Example()
        {
            nint x = 123;
            nint y = 234;
            nint product = x * y;

            IntPtr pt = x;
            pt += 1;
            Console.WriteLine($"x: {x} - pt: {pt}."); // x: 123 - pt: 124.        }
        }
    }
}
