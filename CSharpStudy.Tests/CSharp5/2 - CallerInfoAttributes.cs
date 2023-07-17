using System.Runtime.CompilerServices;

/**
* Caller Info attributes are used to obtain information about the caller to a method at compile-time (file name, line number, etc.).
* https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/caller-information
**/
public class CallerInfoAttributesTest
{
  [Fact]
  public void Example()
  {
    SomeExecutionMethod();
  }

  protected static void SomeExecutionMethod([CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
  {
    Log(callerMemberName, callerFilePath, callerLineNumber);
  }

  protected static void Log(string method, string path, int lineNumber)
  {
    Console.WriteLine($"Some information about the execution\n\n\n  : " +
        $"Caller Method: {method} \n" +
        $"Caller Source Code File: {path} \n" +
        $"Line Number of caller: {lineNumber} \n" +
        $"Executed at: {DateTime.Now}.");
  }
}

