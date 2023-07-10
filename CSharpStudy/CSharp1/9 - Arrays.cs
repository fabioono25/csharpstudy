namespace CSharpStudy.CSharp1
{

  /**
  * Arrays are used to store multiple values in a single variable, instead of declaring separate variables for each value.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
  **/


  public class ArraysTest
  {
    public static void ExecuteExample()
    {
      // Declaration and initialization of a single-dimensional array
      int[] numbers = new int[5];
      numbers[0] = 1;
      numbers[1] = 2;
      numbers[2] = 3;
      numbers[3] = 4;
      numbers[4] = 5;

      // Accessing array elements
      Console.WriteLine(numbers[0]);  // Output: 1
      Console.WriteLine(numbers[2]);  // Output: 3

      // Iterating over array elements
      for (int i = 0; i < numbers.Length; i++)
      {
        Console.WriteLine(numbers[i]);
      }

      // multidimensional array:
      int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
      string[,,] cube = new string[2, 2, 2] { { { "a", "b" }, { "c", "d" } }, { { "e", "f" }, { "g", "h" } } };
      Console.WriteLine(matrix[0, 0]);  // Output: 1
      Console.WriteLine(cube[0, 0, 1]); // Output: b

      // jagged array (array of arrays):
      int[][] jaggedArray = new int[3][];
      jaggedArray[0] = new int[] { 1, 2, 3 };
      jaggedArray[1] = new int[] { 4, 5 };
      jaggedArray[2] = new int[] { 6, 7, 8, 9 };
      Console.WriteLine(jaggedArray[0][0]); // Output: 1
      Console.WriteLine(jaggedArray[1][1]); // Output: 5
    }
  }
}
