namespace CSharpStudy.Tests.CSharp7
{
    /**
    * digit binary separator allows you to use the underscore character as a digit separator in numeric literals to improve readability.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#digit-separators
    **/
    public class DigitBinarySeparator
    {
        [Fact]
        public void BinaryLiterals_Example()
        {
            // Binary literals with 0b prefix
            int binary = 0b1010_1010;
            Assert.Equal(170, binary);
            
            // Hex with separators
            int hex = 0x00_FF_00_FF;
            Assert.Equal(16711935, hex);
        }

        [Fact]
        public void DigitSeparators_Example()
        {
            // Improve readability of large numbers
            long population = 7_800_000_000;
            decimal amount = 1_234_567.89m;
            
            Assert.Equal(7800000000, population);
            Assert.Equal(1234567.89m, amount);
        }
    }
}
