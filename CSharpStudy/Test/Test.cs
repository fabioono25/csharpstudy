using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpStudy.Test
{
    public class Test
    {
        public static void Execute() {
            Console.WriteLine("Hello World");
		
		var tasks = new List<Task<int>>();
        //var newI = new List<Task<string>>();

		Func<object, int> action = (object obj) =>
        {
            int i = (int)obj;
			
			Console.WriteLine("Sta: i={0}, Task={1}, Thread={2}", i, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
			
			// Isso nao funciona ... sabe como resolver??
            var newI = Task.Run<int>(async () => await GetString(i));
			tasks.Add(newI);
            Thread.Sleep(i * 10);

            int tickCount = Environment.TickCount;
            Console.WriteLine("End: i={1}, newI={4}, Task={0}, TickCount={2}, Thread={3}", Task.CurrentId, i, tickCount, Thread.CurrentThread.ManagedThreadId, newI.Result);

            return tickCount;
        };
		
         Parallel.Invoke(() =>
                             {
                                Console.WriteLine("Begin first task...");
                                for (int i = 0; i < 14; i++)
                                {
                                    int index = i;
                                    tasks.Add(Task<int>.Factory.StartNew(action, index));
                                }                                                               
                             },  // close first Action

                             () =>
                             {
                                 Console.WriteLine("Begin second task...");
                                 tasks.Add(Task<int>.Factory.StartNew(action, 21));
                             }, //close second Action

                             () =>
                             {
                                 Console.WriteLine("Begin third task...");
                                 tasks.Add(Task<int>.Factory.StartNew(action, 22));
                             } //close third Action
                         ); //close parallel.invoke
		
		// Construct started tasks
        // for (int i = 0; i < 30; i++)
        // {
        //     int index = i;
        //     tasks.Add(Task<int>.Factory.StartNew(action, index));
        // }
		
		Task.WaitAll(tasks.ToArray());
        }

        private static async Task<int> GetString(int input) {
            //Thread.Sleep(1);
            await Task.FromResult<int>(input);
            return input;
        }   
    }
}