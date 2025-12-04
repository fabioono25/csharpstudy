namespace CSharpStudy.Tests.CSharp13
{
    /**
     * New locking object introduced in C# 13 for better thread synchronization.
     * Uses System.Threading.Lock instead of traditional Monitor-based locking.
     * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock
     **/
    public class NewLockingObject
    {
        private readonly Lock _lock = new Lock();
        private int _counter = 0;

        [Fact]
        public void NewLock_ThreadSafety()
        {
            var tasks = new List<Task>();
            
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    lock (_lock)
                    {
                        _counter++;
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Assert.Equal(10, _counter);
        }
    }
}
