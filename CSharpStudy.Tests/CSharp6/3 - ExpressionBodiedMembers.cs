namespace CSharpStudy.Tests.CSharp6
{
    /**
    * Expression-bodied members allows you to write concise methods, properties, indexers and accessors.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6#expression-bodied-members
    **/
    public class ExpressionBodiedMembers
    {
        public string Name { get; set; } = "John Nash";
        public int Age { get; set; } = 32;

        [Fact]
        public void Example()
        {
            var x = this.ToString();
            Console.WriteLine(x);
        }

        public override string ToString() => $"{Name} {Age}".Trim();
    }
}
