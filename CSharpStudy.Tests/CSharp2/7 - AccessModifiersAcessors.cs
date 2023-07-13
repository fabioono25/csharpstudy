namespace CSharpStudy.Tests.CSharp2
{
  /**
  * access modifiers can be applied separately to the get and set accessor of a property. 
  It allows fine-grained control of the accessibility of the property itself and its accessors.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
  **/
  public class AccessModifiersAcessorsTest
  {
    [Fact]
    public void ExecuteExample()
    {
      MyClass instance = new MyClass();
      // instance.Name = "John"; // Compilation error: Setter is not accessible
      // instance.Age = 20; // Compilation error: Setter is not accessible
      Console.WriteLine(instance.Name); // Output: The value of Name property
    }

    protected class MyClass
    {
      private string _name;
      private int _age;

      public string Name
      {
        get { return _name; }
        private set { _name = value; }
      }

      public int Age
      {
        get { return _age; }
        protected set { _age = value; }
      }
    }
  }

}
