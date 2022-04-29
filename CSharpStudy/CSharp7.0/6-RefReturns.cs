namespace CSharpStudy.CSharp7
{
    public class RefReturns
    {
        public static void ExecuteExample()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            var itemInLocation = FindItemInArray(3, items);
            itemInLocation = 18;

            //[1, 2, 3, 4, 5, 6, 7, 8, 9, 0]
            Console.WriteLine("[{0}]", string.Join(", ", items));

            ref int itemInLocation2 = ref FindItemInArray(3, items);
            itemInLocation2 = 18;

            //the array is now: [1, 2, 18, 4, 5, 6, 7, 8, 9, 0]
            Console.WriteLine("[{0}]", string.Join(", ", items));
        }

        public static ref int FindItemInArray(int number, int[] numbers)
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