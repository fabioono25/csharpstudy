using System.Collections;

namespace CSharpStudy.Tests.CSharp2
{
  /**
  * Iterators provide a simplified way to implement custom iterators using yield keyword.
  * The yield keyword signals to the compiler that the method in which it appears is an iterator block.
  * The compiler generates a class to implement the behavior that is expressed in the iterator block.
  * In the iterator block, the yield keyword is used together with the return keyword to provide a value to the enumerator object.
  * This is the value that is returned, for example, in each loop of a foreach statement.
  * The yield keyword is also used with break and continue to provide a way to exit the iterator block or to skip an iteration.
  * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
  **/
  public class IteratorsTest
  {
    [Fact]
    public void ExecuteExample()
    {
      foreach (int number in GenerateSequence(10))
      {
        Console.WriteLine(number);
      }
    }

    [Fact]
    public void ExecuteExample2()
    {
      DaysOfTheWeek days = new DaysOfTheWeek();

      foreach (string day in days)
      {
        Console.Write(day + " ");
      }
    }


    [Fact]
    public void UsingYieldBreakExample()
    {
      var result1 = UsingYieldBreak();    //0 - 9
    }


    [Fact]
    public void WithoutUsingBreakExample()
    {
      var result2 = WithoutUsingBreak(); //0 - 10
    }

    public static IEnumerable<int> GenerateSequence(int n)
    {
      int a = 0;
      int b = 1;

      for (int i = 0; i < n; i++)
      {
        yield return a;
        int temp = a;
        a = b;
        b = temp + b;
      }
    }


    internal class DaysOfTheWeek : IEnumerable
    {
      private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

      public IEnumerator GetEnumerator()
      {
        for (int index = 0; index < days.Length; index++)
        {
          // Yield each day of the week.
          yield return days[index];
        }
      }
    }

    public static IEnumerable<int> UsingYieldBreak()
    {
      for (int i = 0; ; i++)
      {
        if (i < 10)
        {
          yield return i;
        }
        else
        {
          // Indicates that the iteration has ended, everything 
          // from this line on will be ignored
          yield break;
        }
      }
      //yield return 10; // This will never get executed
    }


    public static IEnumerable<int> WithoutUsingBreak()
    {
      for (int i = 0; ; i++)
      {
        if (i < 10)
        {
          // Yields a number
          yield return i;
        }
        else
        {
          // Terminates just the loop
          break;
        }
      }
      yield return 10; //this code will be executed
    }
  }

}
