namespace CSharpStudy.Tests.CSharp7
{
  /**
  * digit binary separator allows you to use the underscore character as a digit separator in numeric literals to improve readability.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#digit-separators
  **/
  public class DigitBinarySeparator
  {
    [Fact]
    public void Example()
    {
      //representing a binary value
      int binaryOldWay = 0b101010111100110111101111;
      int binaryNewWay = 0b1010_1011_1100_1101_1110_1111;

      //representing digits
      long billingsOfThings = 234_000_000_000;
      double doubleValue = 9.933_412_123_134;
      decimal decimalValue = 9.933_412_123_134M;
    }
  }
}
