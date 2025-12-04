namespace CSharpStudy.Tests.CSharp1
{
    public class ExceptionHandlingTest
    {
        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => Divide(10, 0));
        }

        [Fact]
        public void Divide_ValidInput_ReturnsResult()
        {
            int result = Divide(10, 2);
            Assert.Equal(5, result);
        }

        public int Divide(int x, int y)
        {
            try
            {
                return x / y;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Re-throw to let caller handle it too
            }
            finally
            {
                Console.WriteLine("Operation attempted.");
            }
        }
    }
}
