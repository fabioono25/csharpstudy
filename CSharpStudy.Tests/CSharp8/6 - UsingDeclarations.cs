namespace CSharpStudy.Tests.CSharp8
{
    /**
    * using declarations allow you to declare a disposable variable and have it automatically disposed when the scope ends.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations
    **/
    public class UsingDeclarations
    {
        [Fact]
        public void Example()
        {
            using var stream1 = new StreamReader(Path.GetTempFileName());
            using var stream2 = new StreamReader(Path.GetTempFileName());
        }
    }
}
