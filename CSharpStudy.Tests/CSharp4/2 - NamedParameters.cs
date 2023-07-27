namespace CSharpStudy.Tests.CSharp4
{
  /**
  * named parameters allow you to specify an argument for a particular parameter by associating the argument with the parameter's name rather than with the parameter's position in the parameter list.
  * it enhances the readability of your code by identifying what each argument represents.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
  **/
  public class NamedParametersTest
  {
    [Fact]
    public void Example()
    {
      // Normal order
      Method1("param1", "param2", 3);

      // It's possible to use the named parameters
      Method1(parameter1: "param1", parameter2: "param2", age: 3);

      // Even inverting the order
      Method1(age: 3, parameter2: "param2", parameter1: "parameter1");

      // some parameters can have the inverted order, but the unnamed parameters must be before the named parameters
      Method1("param1", age: 3, parameter2: "param2");

      // They are strongly typed, returning exeption at compile-time
      // Method1(age: "asdasdasd", parameter2: 222, parameter1: "parameter1");

      // Even in different order, you should provide all parameters
      // Method1(age: 3, parameter2: "param2");
    }

    public static void Method1(string parameter1, string parameter2, int age)
    {
    }
  }
}
