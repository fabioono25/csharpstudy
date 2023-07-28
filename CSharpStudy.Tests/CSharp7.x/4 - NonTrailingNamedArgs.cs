namespace CSharpStudy.Tests.CSharp7
{
  /**
  * C# 7.2 - non-trailing named arguments allows arguments to be specified by parameter name, rather than by position.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-2#non-trailing-named-arguments
  **/
  public class NonTrailingNamedArgs
  {
    [Fact]
    public void Example()
    {
      // if the order is ok, you can send a un
      Print("message", name: "John", 10);

      //another example
      Print("message", age: 10, name: "John");

      // inverting positions
      Print(age: 10, name: "John", message: "message");
    }

    private static void Print(string message, string name, int age)
    {
      Console.WriteLine($"Message: {message} - Name: {name} - Age: {age}.");
    }
  }
}
