namespace CSharpStudy.Tests.CSharp7
{
  /**
  * local functions allow you to define functions within a method, encapsulating logic and improving code organization and reusability.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#local-functions
  **/
  public class LocalFunctions
  {
    [Fact]
    public void Example()
    {
      var x = Multiply(2, 3);
      Assert.Equal(6, x);
    }

    [Fact]
    public void Example2()
    {
      // Fibbonacci sequence: 1, 1, 2, 3, 5, 8, 13, 21, 34, 55
      var result = Fibonacci(10);
      Assert.Equal(89, result);
    }

    int Multiply(int x, int y)
    {
      return MultiplyInternal();

      int MultiplyInternal()
      {
        return x * y;
      }
    }

    public static int Fibonacci(int value)
    {
      if (value < 0) throw new ArgumentException("Invalid value", nameof(value));

      return Fib(value).current;

      (int current, int previous) Fib(int i)
      {
        if (i == 0) return (1, 0);

        var (p, pp) = Fib(i - 1);
        return (p + pp, p);
      }
    }
  }
}
