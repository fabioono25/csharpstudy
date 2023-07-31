namespace CSharpStudy.Tests.CSharp7
{
    /**
    * C# 7.2 - Ref conditional allows a conditional expression to be used with the ref keyword.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-2#ref-conditional
    **/
    public class RefConditional
    {
        [Fact]
        public void Example()
        {
            var array1 = new int[] { 1, 3, 5, 7, 9 };
            var array2 = new int[] { 1, 3, 5, 7, 9 };

            ref var ret = ref (array1 != null ? ref array1[0] : ref array2[0]);
        }

        [Fact]
        //another example
        public void Example2()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int index = 2;

            // Use the ref conditional operator to conditionally modify an array element
            ref int elementToModify = ref GetElementToModify(numbers, index);

            // Modify the value of the element using the reference
            elementToModify = 100;

            Console.WriteLine("Modified array:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

        }

        private ref int GetElementToModify(int[] array, int index)
        {
            if (index < array.Length)
            {
                return ref array[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }
    }
}
