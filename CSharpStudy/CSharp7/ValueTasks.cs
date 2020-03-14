using System.Threading.Tasks;
/// <summary>
/// Methods may return an instance of this value type when it's likely that the result of their operations will be available 
/// synchronously and when the method is 
/// expected to be invoked so frequently that the cost of allocating a new Task<TResult> for each call will be prohibitive.
//There are tradeoffs to using a ValueTask<TResult> instead of a Task<TResult>.
//For example, while a ValueTask<TResult> can help avoid an allocation in the case where the successful result is available synchronously, 
//    it also contains two fields whereas a Task<TResult> as a reference type is a single field.
//    This means that a method call ends up returning two fields worth of data instead of one, which is more data to 
//    copy. It also means that if a method that returns one of these is awaited within an async method, the state 
//    machine for that async method will be larger due to needing to store the struct that's two fields 
//instead of a single reference.
//Further, for uses other than consuming the result of an asynchronous operation via await, ValueTask<TResult> 
//can lead to a more convoluted programming model, which can in turn actually lead to more allocations.
//    For example, consider a method that could return either a Task<TResult> with a cached task as a common result 
//    or a ValueTask<TResult>. If the consumer of the result wants to use it as a Task<TResult>, such as to use with 
//    in methods like Task.WhenAll and Task.WhenAny, the ValueTask<TResult> would first need to be converted into a 
//    Task<TResult> using AsTask, which leads to an allocation that would have been avoided if a cached Task<TResult> 
//    had been used in the first place.
//As such, the default choice for any asynchronous method should be to return a Task or Task<TResult>.
//Only if performance analysis proves it worthwhile should a ValueTask<TResult> be used instead of Task<TResult>.
/// </summary>
namespace CSharpStudy.CSharp7
{
    public class ValueTasks
    {
        public static void ExecuteExample()
        {

        }

        //using in places where Task would be used before (Task is reference type)
        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }

        private bool cache = false;
        private int cacheResult;

        public ValueTask<int> CachedFunc()
        {
            return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCacheAsync());
        }

        private async Task<int> LoadCacheAsync()
        {
            //simulate async work
            await Task.Delay(100);
            cacheResult = 100;
            cache = true;
            return cacheResult;
        }
    }
}
