namespace CSharpStudy.Tests.CSharp2
{
  /**
  * Anonymous methods provide a technique to pass a code block as a delegate parameter.
  It allows you to define inline methods without explicitly declaring a separate method. Short-lived scenarios can be handled more elegantly.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-methods
  **/
  public class AnonymousMethodsTest
  {
    public delegate void PrintHelloMessage(string name);

    [Fact]
    public void ExecuteExample()
    {
      List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

      // Using an anonymous method with List<T>.ForEach method
      numbers.ForEach(delegate (int number)
      {
        Console.WriteLine(number * 2);
      });
    }

    [Fact]
    public void ExecuteExample2()
    {
      //Using anonymous method to acces variables
      PrintHelloMessage print = delegate (string name)
      {
        Console.WriteLine("Hello {0}", name);
      };

      print("John");

      //converting anonymous method into a delegate type with a list of parameters
      Action<int, double> introduce = delegate { Console.WriteLine("hi"); };
      introduce(12, 12.32);

      new TestEvent().ImplementBehavior();
    }

    protected class TestEvent
    {

      public event EventHandler PrintMessageEvent;
      public void ImplementBehavior()
      {
        PrintMessageEvent += delegate (object sender, EventArgs e) { Console.Write("Hi"); };
      }
    }
  }




}

