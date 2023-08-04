namespace CSharpStudy.Tests.CSharp8
{
    /**
    * PatternMatchingExpressions allow you to combine a switch expression with a property pattern, tuple pattern, or positional pattern.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#pattern-matching-extensions
    **/
    public class PatternMatchingExpressions
    {
        internal enum Color { Red, Green, Blue }

        // switch expressions are a new kind of expression that work like switch statements, but they evaluate to a value.
        // * It makes the code more consise and readable.
        [Fact]
        public void ExampleSwitchExpressions()
        {
            static string GetColorName(Color color) =>
                color switch
                {
                    Color.Red => "Red",
                    Color.Green => "Green",
                    Color.Blue => "Blue",
                    _ => throw new ArgumentException("Invalid color"),
                };

            Console.WriteLine(GetColorName(Color.Red));
        }

        // property patterns allow you to check whether an object has a property with a specified value.
        [Fact]
        public void ExamplePropertyPatterns()
        {
            static string GetColorName(Color color) =>
                color switch
                {
                    Color.Red => "Red",
                    Color.Green => "Green",
                    Color.Blue => "Blue",
                    _ => throw new ArgumentException("Invalid color"),
                };

            Console.WriteLine(GetColorName(Color.Red));
        }

        // tuple patterns allow you to check whether an object is a tuple with specified values.
        [Fact]
        public void ExampleTuplePatterns()
        {
            static string RockPaperScissors(string first, string second) =>
                (first, second) switch
                {
                    ("rock", "paper") => "rock is covered by paper. Paper wins.",
                    ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                    ("paper", "rock") => "paper covers rock. Paper wins.",
                    ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                    ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                    ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                    (_, _) => "tie",
                };

            Console.WriteLine(RockPaperScissors("rock", "paper"));
        }

        // positional patterns allow you to check whether an object is a tuple with specified values.
        [Fact]
        public void ExamplePositionalPatterns()
        {
            static string RockPaperScissors(string first, string second) =>
                (first, second) switch
                {
                    ("rock", "paper") => "rock is covered by paper. Paper wins.",
                    ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                    ("paper", "rock") => "paper covers rock. Paper wins.",
                    ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                    ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                    ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                    (_, _) => "tie",
                };

            Console.WriteLine(RockPaperScissors("rock", "paper"));
        }

        // relational patterns allow you to check whether an object is greater than, less than, greater than or equal, or less than or equal to a specified value.
        // logical patterns allow you to combine patterns with logical operators &&, ||, and !.
        [Fact]
        public void ExampleRelationalPatterns()
        {
            static string Classify(double length) =>
                length switch
                {
                    < 0.0 => "Negative",
                    > 0.0 and < 100.0 => "Positive but short",
                    >= 100.0 => "Positive and long",
                };

            Console.WriteLine(Classify(50));
        }

    }
}
