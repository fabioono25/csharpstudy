namespace CSharpStudy.Tests.CSharp4
{
  /**
  * there is the aility to specify a method parameter as an option array of variable length. 
  * this enables the calling code to pass in any number of arguments for the parameter.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/optional-argument-arrays
  **/
  public class OptionalParameterArraysTest
  {
    [Fact]
    public void Example()
    {
      // Calling the method with multiple arguments
      PrintNumbers(1, 2, 3);
      PrintNumbers(4, 5, 6, 7, 8);
    }

    void PrintNumbers(params int[] numbers)
    {
      foreach (int number in numbers)
      {
        Console.WriteLine(number);
      }
    }
  }
}
