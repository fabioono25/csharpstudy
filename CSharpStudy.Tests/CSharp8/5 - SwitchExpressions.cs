namespace CSharpStudy.Tests.CSharp8
{
    /**
    * switch expressions are a new kind of expression that work like switch statements, but they evaluate to a value.
    * It makes the code more consise and readable.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions
    **/
    public class SwitchExpressions
    {
        internal enum Color { Red, Green, Blue }

        [Fact]
        public void Example()
        {
            string GetColorName(Color color) =>
                color switch
                {
                    Color.Red => "Red",
                    Color.Green => "Green",
                    Color.Blue => "Blue",
                    _ => throw new ArgumentException("Invalid color"),
                };

            Console.WriteLine(GetColorName(Color.Red));
        }
    }
}
