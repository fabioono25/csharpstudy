namespace CSharpStudy.CSharp9.Features
{
    public class IndexesRanges
    {
        public static void ExecuteExample()
        {
            // indexes types can be used to index a collection
            Index first = 0;
            var last = ^1;
            const string phrase = "0123456";

            Console.WriteLine(phrase);

            Console.WriteLine(phrase[first]);
            Console.WriteLine(phrase[last]);
            Console.WriteLine(phrase[^2]);

            // using range, it's possible to slice an array
            Range lastTwo = ^2..;
            Console.WriteLine(phrase[lastTwo]);
            Console.WriteLine(phrase[^2..]);
            Console.WriteLine(phrase[2..]);
            Console.WriteLine(phrase[1..3]);
        }
    }
}
