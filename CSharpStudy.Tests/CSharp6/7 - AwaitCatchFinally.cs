using System.Threading.Tasks;

namespace CSharpStudy.Tests.CSharp6
{
    /**
    * C# 6 allows the use of await within catch and finally blocks, enabling more flexible asynchronous exception handling.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6#await-in-catch-and-finally-blocks
    **/
    public class AwaitCatchFinally
    {
        [Fact]
        public async Task Example()
        {
            Test test = null;

            try
            {
                var x = test.Property;
            }
            catch (Exception)
            {
                await Logger.Error("exception logging");
            }
            finally
            {
                await Logger.Info("finish execution");
            }
        }

        internal static class Logger
        {
            // I want a static async method here
            public static async Task Error(string message)
            {
                await Task.Delay(100);
                Console.WriteLine(message);
            }
            public static async Task Info(string message)
            {
                await Task.Delay(100);
                Console.WriteLine(message);
            }
        }

        internal class Test
        {
            public int Property { get; set; }
        }
    }
}
