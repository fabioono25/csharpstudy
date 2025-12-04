namespace CSharpStudy.Tests.CSharp1
{
    public class ArraysTest
    {
        [Fact]
        public void Array_BoundsChecking_ThrowsException()
        {
            int[] numbers = { 1, 2, 3 };
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var x = numbers[5]; // Access invalid index
            });
        }

        [Fact]
        public void Array_Initialization_And_Access()
        {
            // Single-dimensional
            int[] numbers = new int[3];
            numbers[0] = 10;
            numbers[1] = 20;
            numbers[2] = 30;

            Assert.Equal(20, numbers[1]);

            // Multidimensional (Matrix)
            int[,] matrix =
            {
                { 1, 2 },
                { 3, 4 }
            };
            Assert.Equal(3, matrix[1, 0]);

            // Jagged (Array of Arrays)
            int[][] jagged = new int[2][];
            jagged[0] = new int[] { 1, 2, 3 };
            jagged[1] = new int[] { 4, 5 };

            Assert.Equal(5, jagged[1][1]);
        }
    }
}
