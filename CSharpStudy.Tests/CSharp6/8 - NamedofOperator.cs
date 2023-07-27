namespace CSharpStudy.Tests.CSharp6
{
  /**
  * The nameof operator allows you to get the name of a variable, type, or member as a string. It helps prevent hardcoded strings and improves refactoring support.
  * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/nameof
  **/
  public class NamedofOperator
  {
    [Fact]
    public void Example()
    {
      var category1 = new Category("test");
      Console.WriteLine(nameof(category1));
      var category = new Category(null);
    }
  }

  internal class Category
  {
    private string Name { get; set; }

    public Category(string name)
    {
      //using nameof
      Name = name ?? throw new NullReferenceException(nameof(name));
    }
  }
}
