namespace CSharpStudy.Tests.CSharp4
{
  /**
  * optional parameters are parameters that can be omitted when calling methods or constructors.
  * it enhances the readability and flexibility of code by enabling you to define a single method that can be called with different arguments.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
  **/
  public class OptionalParametersTest
  {
    [Fact]
    public void Example()
    {
      // Only parameter 1 is called. However, parameter2 and age have the default values
      Method1("param1");

      // Now we have a different set of values
      Method1("param1", "param2 new value", 333);

      // In this case we used named arguments. parameter2 is still fullfiled with the default value
      Method1("parameter1", parameter3: 1);
    }

    public static void Method1(string parameter1, string parameter2 = "abc", int parameter3 = 3)
    {
    }
  }
}
