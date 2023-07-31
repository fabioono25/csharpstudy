namespace CSharpStudy.Tests.CSharp7
{
    /**
    * C# 7.3 - in parameters allows you to pass an argument to a method by reference rather than by value.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#in-parameters
    **/
    public class InParameters
    {
        [Fact]
        public void Example()
        {
            int number = 42;
            Process(in number); // Pass 'number' as a read-only in parameter
        }

        static void Process(in int value)
        {
            // value++; // Error: Cannot modify in parameter
            Console.WriteLine(value);
        }
    }
}
