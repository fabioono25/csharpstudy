using System.Threading.Tasks;

namespace CSharpStudy.Tests.CSharp6
{
    /**
    * C# 6 allows the use of await within using statements, making it easier to work with asynchronous resources that implement IDisposable.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6#await-in-using-statements
    **/
    public class AwaitUsing
    {
        [Fact]
        public async Task Example()
        {
            await ExecuteExampleAsync();
        }

        internal static async Task ExecuteExampleAsync()
        {
            // Example with synchronous resource cleanup (old way)
            using (var streamReader = new StreamReader("example.txt"))
            {
                // Read and process data from the file synchronously
                string content = streamReader.ReadToEnd();
                Console.WriteLine(content);
            }
            // The StreamReader will be disposed after the using block

            Console.WriteLine("Synchronous resource cleanup complete.\n");

            // Example with asynchronous resource cleanup (C# 6)
            using (var asyncStreamReader = await GetAsyncStreamReaderAsync("example.txt"))
            {
                // Read and process data from the file asynchronously
                string content = await asyncStreamReader.ReadToEndAsync();
                Console.WriteLine(content);
            }
            // The AsyncStreamReader will be disposed after the using block

            Console.WriteLine("Asynchronous resource cleanup complete.");
        }

        // Simulating asynchronous resource initialization
        internal static async Task<StreamReader> GetAsyncStreamReaderAsync(string filePath)
        {
            await Task.Delay(1000); // Simulate asynchronous initialization
            var fileStream = new FileStream(filePath, FileMode.Open);
            return new StreamReader(fileStream);
        }
    }
}
