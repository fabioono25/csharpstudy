namespace CSharpStudy.CSharp3_0
{
    public class ObjectsCollectionsInitializersTest
    {
        public static void ExecuteExample()
        {
            var book1 = new Book();

            var book2 = new Book("George Orwel")
            {
                Title = "1984"
            };

            var book3 = new Book
            {
                Title = "1984",
                Year = 1949
            };

            book3.Author = "George Orwel";
        }
    }

    internal class Book
    {

        public Book()
        {
        }

        public Book(string author)
        {
            Author = author;
        }

        public int Year { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
    }
}