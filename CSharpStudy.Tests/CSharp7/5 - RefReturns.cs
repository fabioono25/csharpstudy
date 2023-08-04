namespace CSharpStudy.Tests.CSharp7
{
    /**
    * ref returns and locals allow methods to return references to variables and store references locally, enabling efficient and direct manipulation of data.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#ref-returns-and-locals
    **/
    public class RefReturns
    {
        [Fact]
        public void Example()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            var itemInLocation = FindItemInArray(3, items);
            itemInLocation = 18;

            //[1, 2, 3, 4, 5, 6, 7, 8, 9, 0]
            Console.WriteLine("[{0}]", string.Join(", ", items));

            ref int itemInLocation2 = ref FindItemInArray(3, items);
            itemInLocation2 = 19;

            //the array is now: [1, 2, 18, 4, 5, 6, 7, 8, 9, 0]
            Console.WriteLine("[{0}]", string.Join(", ", items));
        }

        [Fact]
        public void ExampleRefLocal()
        {
            int x = 10;
            ref int y = ref x; // y is a reference to x
            y = 20; // Changes the value of x to 20
            Assert.Equal(20, x);
        }

        internal static ref int FindItemInArray(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    //storage location
                    return ref numbers[i];
                }
            }

            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }
    }
}
