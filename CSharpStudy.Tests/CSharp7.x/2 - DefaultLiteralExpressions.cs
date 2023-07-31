namespace CSharpStudy.Tests.CSharp7
{
    /**
    * C# 7.1 - Default Literal Expressions provides a concise way to initialize variables with default values.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1#default-literal-expressions
    **/
    public class DefaultLiteralExpressions
    {

        [Fact]
        public void Example1()
        {
            var value1 = default(int); // old implementation for default value expressions
            int value2 = default;      // new implementation for default value expressions
            Console.WriteLine(SumValues(value1, value2));

            Console.WriteLine(SumValues());
        }

        //defining a method with the default expression, so it can be executed withoud passing parameters
        private static int SumValues(int val1 = default, int val2 = default) => val1 + val2;
    }
}
