namespace CSharpStudy.Tests.CSharp7
{
  /**
  * Generic pattern matching allows you to use the is operator to test an object against a pattern.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-2#generic-pattern-matching
  **/
  public class GenericPatternMatching
  {
    [Fact]
    public void Example()
    {
      var person = new Person { Age = 20 };
      Print<Person>(person);
    }

    // now, it's possible to evaluate generic types via pattern matching
    private static void Print<T>(T type) where T : Person
    {
      switch (type)
      {
        case null:
          break;
        case Person person:
          Console.WriteLine(person.Age);
          break;
      }
    }

    class Person
    {
      public int Age { get; set; }
    }
  }
}

