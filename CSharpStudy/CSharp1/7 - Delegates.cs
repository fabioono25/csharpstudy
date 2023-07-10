namespace CSharpStudy.CSharp1
{
  /// <summary>
  /// Delegates allow you to define and work with references to methods, enabling event handling and callbacks.
  /// A delegate in C# is similar to function pointers of C++, but C# delegates are type safe. 
  /// Delegates are used to define callback methods and implement event handling, and they are declared using the "delegate" keyword. 
  /// You can declare a delegate that can appear on its own or even nested inside a class.
  /// https://docs.microsoft.com/en-us/dotnet/csharp/delegates-overview
  /// </summary>
  public class DelegateExample
  {
    //defining a delegate type
    public delegate void MyDelegate(string message);

    //creating a method for a delegate
    public static void DisplayMessage(string message)
    {
      Console.WriteLine(message);
    }

    public static void ProcessData(string data, MyDelegate callback)
    {
      // performing some data processing
      // invoke the callback method
      callback?.Invoke(data);
    }

    public static void ExecuteExample()
    {
      Console.WriteLine("C# 1.0 - Delegate Example");

      //instantiate the delegate
      MyDelegate handler = DisplayMessage;

      //call the delegate
      handler("hello!!");

      // another approach
      ProcessData("test", DisplayMessage);


      Calculator calculator = new Calculator();
      Calculator.Operation operation = calculator.Add;
      int result = operation.Invoke(3, 4);
    }
  }

  public class Calculator
  {
    public delegate int Operation(int x, int y);

    public int Add(int x, int y)
    {
      return x + y;
    }

    public int Multiply(int x, int y)
    {
      return x * y;
    }
  }
}