namespace CSharpStudy.Tests.CSharp3
{
  /**
  * Lambda expressions are anonymous functions and methods that provide a concise way to define a method.
  * Lambda expressions are used extensively in LINQ and in other technologies where methods are passed as parameters.
  * They are used in LINQ queries, event handlers and functional programming.
  obs: a method is a function, a function is not necessarily a method
  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
  **/
  public class LambdaExpressionsTest
  {
    [Fact]
    public void Example()
    {
      Func<int, int> square = x => x * x;
      int result = square(5); // Output: 25
      Console.WriteLine(result);
    }

    [Fact]
    public void OtherExpressions()
    {
      var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

      //IEnumerable<int>
      var numbersBellowFour = numbers.Where(n => n < 4);

      //IOrderedEnumerable<int>
      var numbersBellowFour2 = numbers.OrderByDescending(n => n < 4);

      //IEnumerable<string>
      var numbersBellowFour3 = numbers.Where(n => n < 4).Select(n => "The number bellow is " + n);

      //int
      var numbersBellowFour4 = numbers.Count(n => n < 4);

      //IEnumerable<<anonymous type: string Type, int Value>>
      var numbersBellowFour5 = numbers.Where(n => n < 4).Select(n =>
                                                                     new
                                                                     {
                                                                       Type = "Number",
                                                                       Value = n
                                                                     });
    }
  }
}
