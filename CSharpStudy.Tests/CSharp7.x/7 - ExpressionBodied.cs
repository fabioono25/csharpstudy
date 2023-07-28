namespace CSharpStudy.Tests.CSharp7
{
  /**
  * expression-bodied members allow methods, properties, constructors and finalizers to have bodies as expressions instead of statements.
  * It reduces the boilerplate for simple constructor or destructor definitions.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#expression-bodied-members
  **/
  public class ExpressionBodied
  {
    [Fact]
    public void Example()
    {
      var p1 = new Person("John");
      Console.WriteLine(p1.Name);
    }
  }

  internal class Person
  {
    private string name;
    public Person(string name) => this.name = name;
    ~Person() => Console.WriteLine($"Destructor called for {name}");

    // Expression-bodied get / set accessors.
    public string Name
    {
      get => name;
      set => this.name = value ?? "Default label";
    }
  }
}
