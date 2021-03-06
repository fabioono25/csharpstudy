using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public class AsyncMain
    {
        public async Task ExecuteExample()
        {
            await Task.Run(() =>
            {
                Task.Delay(3000).Wait();
                Console.WriteLine("End of execution");
            });
        }
    }
}