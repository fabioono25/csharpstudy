namespace CSharpStudy.Tests.CSharp7
{
    /**
    * pattern matching enhances the switch statement so that you can easily branch based on a type,
    * and extract values from members of that type.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#pattern-matching
    **/
    public class PatternMatching
    {

        [Fact]
        public void Example1()
        {
            object obj = 123;

            switch (obj)
            {
                case string text:
                    Console.WriteLine($"String length: {text.Length}");
                    break;
                case int number when number > 0:
                    Console.WriteLine($"Positive number: {number}");
                    break;
                default:
                    Console.WriteLine("Unknown type");
                    break;
            }
        }

        [Fact]
        public void Example2()
        {
            //is pattern
            object input = 12;

            if (input is int count)
                Console.WriteLine(count);

            ClassTest classTest = null;

            if (classTest is null)
            {
                classTest = new ClassTest();
                Console.WriteLine("ClassTest is not null anymore");
            }

            //case pattern, with input of type int = 12
            switch (input)
            {
                case int n when n > 100:
                    Console.WriteLine("Value of n is more than 100.");
                    break;

                case int n when n <= 100:
                    Console.WriteLine("Value of n is less than 100.");
                    break;

                default:
                    Console.WriteLine("value not found");
                    break;
            }
        }

    }

    internal class ClassTest
    {

    }
}
