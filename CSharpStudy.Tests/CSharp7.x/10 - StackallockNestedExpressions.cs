namespace CSharpStudy.Tests.CSharp7
{
  /**
  * C# 7.3 - Allows the use of stackalloc within nested expressions, improving memory allocation for arrays in certain scenarios.
  * StackAllock is a way to allocate memory in the stack instead of the heap.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-3#stackalloc-in-nested-expressions
  **/
  public class StackallockNestedExpressions
  {
    [Fact]
    public void Example()
    {
      // Create a stack-allocated array of integers
      Span<int> numbers = stackalloc int[] { 1, 2, 3, 4, 5 };

      // Use the stack-allocated array in a nested expression
      int sum = CalculateSum(numbers);
      Console.WriteLine($"Sum of numbers: {sum}");
    }

    private static int CalculateSum(ReadOnlySpan<int> numbers)
    {
      // Using the stack-allocated array in a nested expression
      int sum = 0;
      foreach (var number in numbers)
      {
        sum += number;
      }
      return sum;
    }
  }
}
