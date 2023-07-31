using System.Threading.Tasks;

namespace CSharpStudy.Tests.CSharp5
{
    /**
    * Task-based Asynchronous Pattern (TAP) is a pattern for asynchrony in the .NET Framework.
    * it makes easier to write asynchronous code using Task and Task<TResult> types.
    * https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap
    **/
    public class TaskBasedAsyncPatternTest
    {
        [Fact]
        public void Example()
        {
            var result = PerformAsyncOperation().Result;
            Console.WriteLine(result);
        }

        protected async Task<int> PerformAsyncOperation()
        {
            await Task.Delay(1000);
            return 42;
        }
    }
}
