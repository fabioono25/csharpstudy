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
    public void ExecuteExample3()
    {
        foreach (int i in ProduceEvenNumbers(9))
        {
            Console.Write(i);
            Console.Write(" ");
        }
        // Output: 0 2 4 6 8

        IEnumerable<int> ProduceEvenNumbers(int upto)
        {
            for (int i = 0; i <= upto; i += 2)
            {
                yield return i;
            }
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

    [Fact]
    public void ExecuteExampleWithoutIterator()
    {
      int[] numbers = { 1, 2, 3, 4, 5 };
      CustomCollection<int> collection = new CustomCollection<int>(numbers);

      foreach (int number in collection)
      {
        Console.WriteLine(number);
      }
    }

    [Fact]
    public void ExecuteExampleWithIterator()
    {
      int[] numbers = { 1, 2, 3, 4, 5 };
      CustomCollectionWithIterator<int> collection = new CustomCollectionWithIterator<int>(numbers);

      foreach (int number in collection)
      {
        Console.WriteLine(number);
      }
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

  // in the old way, it is necessary to implement a separate IEnumerable<T> and IEnumerator<T> classes
  internal class CustomCollection<T> : IEnumerable<T>
  {
    private T[] items;

    public CustomCollection(T[] items)
    {
      this.items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return new CustomCollectionEnumerator<T>(items);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }

  internal class CustomCollectionEnumerator<T> : IEnumerator<T>
  {
    private T[] items;
    private int currentIndex;

    public CustomCollectionEnumerator(T[] items)
    {
      this.items = items;
      currentIndex = -1;
    }

    public T Current => items[currentIndex];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
      currentIndex++;
      return currentIndex < items.Length;
    }

    public void Reset()
    {
      currentIndex = -1;
    }

    public void Dispose()
    {
      // Dispose resources if necessary
    }
  }

  // using iterators, the logic is simplified and the compiler generates the IEnumerator<T> class
  internal class CustomCollectionWithIterator<T> //: IEnumerable<T>
  {
    private T[] items;

    public CustomCollectionWithIterator(T[] items)
    {
      this.items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
      foreach (T item in items)
      {
        yield return item;
      }
    }

    // IEnumerator IEnumerable.GetEnumerator()
    // {
    //   return GetEnumerator();
    // }
  }

}
