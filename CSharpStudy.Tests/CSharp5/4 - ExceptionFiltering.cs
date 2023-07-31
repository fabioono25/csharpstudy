namespace CSharpStudy.Tests.CSharp5
{
    /**
    * exception filtering allows you to catch specific exceptions based on a condition using the when keyword (more fine-graned exception handling).
    * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch
    **/
    public class ExceptionFilteringTest
    {
        [Fact]
        public void Example()
        {
            try
            {
                //TODO
            }
            catch (Exception ex) when (ex.Message.Contains("Critical"))
            {

                throw;
            }
        }

        [Fact]
        public void Example2()
        {
            try
            {
                int result = Divide(10, 0);
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is DivideByZeroException)
            {
                Console.WriteLine("Handled ArgumentException or DivideByZeroException or OverflowException");
            }
            catch (Exception ex) when (ex is OverflowException)
            {
                Console.WriteLine("Handled OverflowException");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Handled ArgumentException", ex.Message);
            }
            catch
            {
                Console.WriteLine("Unhandled Exception");
            }
            finally
            {
                Console.WriteLine("Done.");
            }
        }

        [Fact]
        public void HandledExceptionTest()
        {
            try
            {
                int result = Divide(10, 0);
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex) when (HandleException(ex))
            {
                Console.WriteLine("Handled Exception");
            }
        }

        protected static int Divide(int dividend, int divisor)
        {
            return dividend / divisor;
        }

        protected static bool HandleException(Exception ex)
        {
            Console.WriteLine("Exception handled: " + ex.Message);
            return true;
        }
    }
}
