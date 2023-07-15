namespace CSharpStudy.Tests.CSharp3
{
  /**
  * anonymous types allow creating objects without writing a class definition for the data type.
  they are useful for storing data temporarily.
  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types
  **/
  public class AnonymousTypesTest
  {
    [Fact]
    public void Example()
    {
      var person = new { Name = "John", Surname = "Nash", Age = 30 };

      // person.Age = 23; //it's readonly property

      Console.WriteLine(person.Name);
    }

    [Fact]
    public void ExampleWithCollections()
    {

      //the objects inside of an array must have the same properties and property-types
      var prodArray = new[] {
                                new { Id = 1, Name = "Pen" },
                                new { Id = 2, Name = "Pencil" }
                            };

      foreach (var item in prodArray)
      {
        Console.WriteLine(item.Name);
      }
    }
  }
}
