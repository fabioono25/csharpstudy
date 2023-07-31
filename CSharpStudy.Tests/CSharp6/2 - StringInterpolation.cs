namespace CSharpStudy.Tests.CSharp6
{
    /**
    * string interpolation is a way to construct a new string value from a mix of constants, variables, literals, and expressions by including the expressions prefixed with the $ symbol inside a string literal.
    * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
    **/
    public class StringInterpolation
    {
        [Fact]
        public void Example()
        {
            var author = "John Nash";
            var salary = 32.246423;

            Console.WriteLine($"The author is: {author}. His age is: {CalculateAge()}");
            Console.WriteLine($"The salary average is {salary:F2}");
        }

        internal static int CalculateAge() => 26;

    }
}
