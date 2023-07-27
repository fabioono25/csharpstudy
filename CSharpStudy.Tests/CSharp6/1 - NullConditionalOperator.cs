namespace CSharpStudy.Tests.CSharp6
{
  /**
  * Null-conditional operator allows you to safety access members or elements of an object without worrying about null ref exeptions.
  * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
  **/
  public class Test1
  {
    [Fact]
    public void Example()
    {
      var book = new Book();

      var bookName = book.Name ?? "--empty--";

      Console.WriteLine(bookName);
      Console.WriteLine($"Name: {book.Name}");
      Console.WriteLine($"Pages: {book.Pages}");
      Console.WriteLine($"Publisher's name: {book.Publisher?.Name}");
      Console.WriteLine($"Authors count: {book.Authors?.Length}");
      Console.WriteLine($"First Author's Name: {book.Authors?[0].Name}");
      Console.WriteLine($"First Author's Age: {book.Authors?[0].Age}");
    }

    internal class Book
    {
      public string Name { get; set; }
      public int Pages { get; set; }
      public Author[] Authors { get; set; }
      public Publisher Publisher { get; set; }
    }

    internal class Author
    {
      public string Name { get; set; }
      public int Age { get; set; }
    }

    internal class Publisher
    {
      public string Name { get; set; }
    }
  }
}
