using System.Runtime.CompilerServices;

namespace CSharpStudy.CSharp5_0
{
    public class CallerInfoAttributesTest
    {
        public static void ExecuteExample()
        {
            SomeExecutionMethod();
        }

        static void SomeExecutionMethod([CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            Log(callerMemberName, callerFilePath, callerLineNumber);
        }

        static void Log(string method, string path, int lineNumber)
        {
            Console.WriteLine($"Some information about the execution\n\n\n  : " +
                $"Caller Method: {method} \n" +
                $"Caller Source Code File: {path} \n" +
                $"Line Number of caller: {lineNumber} \n" +
                $"Executed at: {DateTime.Now}.");
        }
    }
}
