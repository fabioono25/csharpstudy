namespace CSharpStudy.Tests.CSharp2
{
    /**
    * access modifiers can be applied separately to the get and set accessor of a property. 
    It allows fine-grained control of the accessibility of the property itself and its accessors.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
    * https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
     **/
    public class AccessModifiersAcessorsTest
  {
    [Fact]
    public void ExecuteExample()
    {
      Person instance = new Person();
        instance.Name = "John"; // Compilation error: Setter is not accessible
        instance.Age = 20; // Compilation error: Setter is not accessible
    Console.WriteLine(instance.Name); // Output: The value of Name property
    }

    protected class Person
    {
      private string _name;
      private int _age;

      public string Name
      {
        get { return _name; }
         set { _name = value; }
      }

      public int Age
      {
        get { return _age; }
        internal set { _age = value; }
      }
    }
  }

}
