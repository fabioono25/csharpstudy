using static System.Math;
using static System.Console;

namespace CSharpStudy.Tests.CSharp6
{
  /**
  * the using static directive allows you to import static members of a single class
  * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-static
  **/
  public class UsingStatic
  {
    [Fact]
    public void Example()
    {
      var result = Pow(5, 2);

      Write($"Five squared is {result}.");
    }
  }
}
