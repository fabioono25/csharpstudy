namespace CSharpStudy.Tests.CSharp8
{
    /**
    * disposable ref structs allow you to declare ref structs that implement IDisposable,  allowing disposable value types for efficient resource management.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#disposable-ref-structs
    **/
    public class DisposableRefStructs
    {
        [Fact]
        public void Example()
        {
            using var disposableRefStruct = new DisposableRefStruct();
            DisposableRefStruct.DoSomething();
        }
    }

    public ref struct DisposableRefStruct
    {
        public static void DoSomething()
        {
            Console.WriteLine("Doing something...");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose method called.");
        }
    }
}
