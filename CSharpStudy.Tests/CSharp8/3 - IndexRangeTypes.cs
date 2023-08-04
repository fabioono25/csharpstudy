namespace CSharpStudy.Tests.CSharp8
{
    /**
    * Introduces the Index and Range types to simplify working with ranges of elements in arrays and collections.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges
    **/
    public class IndexRangeTypes
    {
        [Fact]
        public void Example()
        {
            var numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine(numbers[^1]); // latest item 9

            var rangeBetween2And5 = numbers[1..6]; // returns 1,2,3,4,5

            Range rangeBetween2And5New = 1..6;
            var result = numbers[rangeBetween2And5New]; // returns 1,2,3,4,5 using Range struct

            var numbersFrom5to7 = numbers[^5..^2]; // returns numbers 5, 6, 7
        }
    }
}
