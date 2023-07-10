namespace CSharpStudy.CSharp1
{

  /**
  * Exception handling is a mechanism to handle errors and exceptions in a program.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/
  **/

  public class ExceptionHandlingTest
  {
    public static void ExecuteExample()
    {
      try
      {
        // Code that might throw an exception
        int result = Divide(10, 0);
        Console.WriteLine("Result: " + result);
      }
      catch (DivideByZeroException ex)
      {
        Console.WriteLine("Error: Cannot divide by zero.", ex.Message);
      }
      catch (CustomException ex) {
        Console.WriteLine("Error: Custom exception.", ex.Message);
      }
      catch (Exception ex)
      {
        Console.WriteLine("An error occurred: " + ex.Message);
      }
      finally
      {
        // Optional: Code that always executes, regardless of whether an exception occurred or not
        Console.WriteLine("End of exception handling.");
      }
    }

    public static int Divide(int x, int y)
    {
      return x / y;
    }

    public class CustomException : Exception
    {
      public CustomException(string message) : base(message)
      {
      }
    }
  }
}
