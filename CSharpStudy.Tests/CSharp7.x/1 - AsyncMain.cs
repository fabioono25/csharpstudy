using System.Threading.Tasks;

namespace CSharpStudy.Tests.CSharp7
{
    /**
    * as part of C# 7.1 features, Async in Main method allows the main method of a console application to be defined as async.
    * This enables the use of await in the main method.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#async-main
    **/
    public class AsyncMain
    {
        [Fact]
        public void Example()
        {
            // TODO
        }

        static async Task Main(string[] args)
        {
            await DoSomethingAsync();
        }

        private static Task DoSomethingAsync()
        {
            throw new NotImplementedException();
        }
    }
}
