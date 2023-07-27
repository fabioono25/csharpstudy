namespace CSharpStudy.Tests.CSharp6
{
  /**
  * exception filters allow you to filter exceptions that are caught in a catch block
  * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch#exception-filters
  **/
  public class ExceptionFilters
  {
    [Fact]
    public void Example()
    {
      Test test = null;

      try
      {
        var x = test.Property;
      }
      catch (Exception e) when (e.Message.Contains("Object reference"))
      {
        Console.WriteLine("You can use NullReferenceException, but it's just an example");
      }
    }


    internal class Test
    {
      public int Property { get; set; }
    }
  }
}
