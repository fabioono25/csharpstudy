namespace CSharpStudy.Tests.DataStructures
{
    /**
    * Arrays where introduced in version 1.0 of the .NET Framework and version 1.0 of the C# language.
    * Arrays are a collection of elements of the same type. They are fixed-size and have a zero-based index.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
    **/
    public class ArrayTest
    {
        // Single-Dimensional Array (1D Array): elements stored in a linear sequence
        [Fact]
        public void SingleDimentionalArray()
        {
            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
        }

        // Multidimensional Array (2D Array): elements stored in multiple dimensions (rows and columns)
        [Fact]
        public void MultidimentionalArray()
        {
            int[,] matrix = new int[3, 3]
            {
          { 1, 2, 3 },
          { 4, 5, 6 },
          { 7, 8, 9 }
            };

            // print the middle item of the matrix
            Console.WriteLine(matrix[1, 1]);
        }
    }
}
