using System.Globalization;
using Xunit;

internal class Person {
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
}