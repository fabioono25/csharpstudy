namespace CSharpStudy.Tests.CSharp8
{
    /**
    * static local functions allow you to declare local functions that can only be called within the containing method.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions
    **/
    public class StaticLocalFunctions
    {
        [Fact]
        public void Example()
        {
            int Calculate(int a, int b)
            {
                return Add(a, b); // Local function call

                static int Add(int x, int y) => x + y; // Static local function
            }

            Console.WriteLine(Calculate(1, 2));
        }


    }
}
