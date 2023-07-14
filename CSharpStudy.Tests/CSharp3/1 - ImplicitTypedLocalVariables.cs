namespace CSharpStudy.Tests.CSharp3
{
  /**
  * Implicit type local variables (var) allows us to declare a variable without specifying its type.
  The compiler infers the type of the variable based on the assigned value.
  https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables
  **/
  public class ImplicitTypedLocalVariablesTest
  {
    [Fact]
    public void Example()
    {
      var number = 10; //implicit typed
      int number2 = 10;//explicit typed
      Console.WriteLine(number.GetType().Name);
      Console.WriteLine(number2.GetType().Name);

      var name = "John";
      Console.WriteLine(name.GetType().Name);

      var x = new ClassTest(); //x is an instance of ClassTest
      Console.WriteLine(x.GetType().Name);
    }

    protected class ClassTest
    {
    }
  }
}
