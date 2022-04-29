namespace CSharpStudy.CSharp6
{
    public class NullConditionalOperator
    {
        public static void ExecuteExample()
        {
            var book = new Book();

            var bookName = book.Name ?? "--empty--";

            WriteLine(bookName);
            WriteLine($"Name: {book.Name}");
            WriteLine($"Pages: {book.Pages}");
            WriteLine($"Publisher's name: {book.Publisher?.Name}");
            WriteLine($"Authors count: {book.Authors?.Length}");
            WriteLine($"First Author's Name: {book.Authors?[0].Name}");
            WriteLine($"First Author's Age: {book.Authors?[0].Age}");
        }
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