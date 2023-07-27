namespace CSharpStudy.Tests.CSharp7
{
  /**
  * out variables allow you to declare a variable and initialize it in the same statement.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#out-variables
  **/
  public class OutVariables
  {
    [Fact]
    public void Example()
    {
      var input = "123";

      //old way: separate the declaration of the out variable into two different statements
      int numericResult;
      if (int.TryParse(input, out numericResult))
        Console.WriteLine($"Old way: {numericResult}");
      else
        Console.Write("Could not parse input");

      //new way: declare variables in the argument list of a method call
      if (int.TryParse(input, out int numericResultNew))
        Console.WriteLine($"New Way: {numericResultNew}");
      else
        Console.Write("Could not parse input");

      //we can use implicit typed local variable
      if (int.TryParse(input, out var numericResultVar))
        Console.WriteLine($"New Way with Var: {numericResultVar}");
      else
        Console.Write("Could not parse input");

      Console.WriteLine($"Using outside local scope: {numericResultVar}");
    }
  }
}
