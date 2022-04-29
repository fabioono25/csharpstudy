namespace CSharpStudy.CSharp7123
{
    public static class IndicesRanges
    {
        public static void ExecuteExample()
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