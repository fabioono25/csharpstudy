using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public static class AsyncStreams
    {
        public static async Task ExecuteExample()
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