using System.Threading.Tasks;

namespace CSharpStudy.Tests.CSharp8
{
    /**
    * async stream allows you to return a sequence of values from an async method.
    * Enables the use of IAsyncEnumerable<T> to define and consume asynchronous streams of data, making asynchronous data processing more natural.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#asynchronous-streams
    **/
    public class AsyncStream
    {
        [Fact]
        public async Task Example()
        {
            await foreach (var item in GenerateOrder())
            {
                Console.WriteLine(item);
            }
        }

        internal static async IAsyncEnumerable<int> GenerateOrder()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
    }
}
