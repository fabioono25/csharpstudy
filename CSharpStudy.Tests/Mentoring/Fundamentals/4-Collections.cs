using System.Globalization;
using Xunit;

internal class Person
{
  public string Name { get; set; }
}

public class CollectionsTest
{
  [Fact]
  public void ShallowCloningTest()
  {
    var original = new int[] { 1, 2, 3 };
    var clone = (int[])original.Clone();

    Assert.Equal(original, clone);
    Assert.NotSame(original, clone);

    var person1 = new Person { Name = "John" };
    var person2 = original;
    var person3 = (Person)original.Clone();

    Assert.Same(person1, person2);
    Assert.NotSame(person1, person3);

    // deep cloning
    var person4 = new Person { Name = "John" };
  }

  [Fact]
  public void LinqTest()
  {
    var numbers = new int[] { 1, 2, 3, 4, 5 };

    var sum = 0;
    foreach (var number in numbers)
    {
      sum += number;
    }

    Assert.Equal(15, sum);

    var sum3 = numbers.Where(n => n % 2 == 0).Sum();
    Assert.Equal(6, sum3);

    var sum4 = numbers.Where(n => n % 2 == 0).Sum(n => n * 2);
    Assert.Equal(12, sum4);

    // fluent syntax or method syntax
    var filtered = numbers.Where(n => n % 2 == 0).ToList();

    // query syntax or query expression
    var filtered2 = (from n in numbers
                     where n % 2 == 0
                     select n).ToList();
  }

  [Fact]
  public void DeferredExecutionTest()
  {
    var numbers = new List<int> { 1, 2, 3, 4, 5 };

    var query = numbers.Where(n => n % 2 == 0); // the query is not executed yet

    numbers[0] = 10; // the query is executed here

    Assert.Equal(10, query.First()); // 10 is the first even number

    // another example, with select and ToList()
    var query2 = numbers.Select(n => n.ToString(CultureInfo.InvariantCulture)); // the query is not executed yet

    var result = query2.ToList(); // the query is executed here
    numbers.Clear(); // the query is executed again here

  }

  [Fact]
  public void SelectVsSelectManyTest()
  {
    // difference between Select and SelectMany: SelectMany flattens the result
    // SelectMany is equivalent to Select followed by SelectMany
    // Select is equivalent to SelectMany with identity function

    // using Select. Why: because the result is a list of lists
    var numbers = new List<int> { 1, 2, 3, 4, 5 };

    var query = numbers.Select(n => Enumerable.Range(1, n).ToList());
    Assert.Equal(1, query.First().First());

    // using SelectMany. Why: because the result is a list of numbers
    var query2 = numbers.SelectMany(n => Enumerable.Range(1, n));
    Assert.Equal(1, query2.First());
  }

  [Fact]
  public void ZipTest() {
    var numbers = new List<int> { 1, 2, 3, 4, 5 };
    var letters = new List<char> { 'a', 'b', 'c', 'd', 'e' };

    var query = numbers.Zip(letters, (n, l) => $"{n}{l}");
    Assert.Equal("1a", query.First());
  }
}