namespace CSharpStudy.Tests.CSharp3
{
    /**
    * LINQ (Language Integrated Query) query expressions provide a language-integrated way to write queries in C#.
    * Based on the query expression, the compiler generates the appropriate method calls for the LINQ operators.
    * it is powerful for querying collections, databases and other sources.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-expression-basics
    **/
    public class QueryExpressionsTest
    {
        [Fact]
        public void Example()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            //IEnumerable<int>
            var evenNumbers = from num in numbers
                              where num % 2 == 0
                              select num;

            //IEnumerable<int>
            var numbersBellowFour =
                from number in numbers
                where number < 4
                select number;

            //IOrderedEnumerable<int>
            var numbersBellowFour2 =
                from number in numbers
                where number < 4
                orderby number descending
                select number;

            //IEnumerable<string>
            var numbersBellowFour3 =
                from number in numbers
                where number < 4
                select "The number bellow is " + number;

            //int
            var numbersBellowFour4 =
                (from number in numbers
                 where number < 4
                 select number)
                 .Count();

            //IEnumerable<<anonymous type: string Type, int Value>>
            var numbersBellowFour5 =
                from number in numbers
                where number < 4
                select new { Type = "Number", Value = number };

        }
    }
}
