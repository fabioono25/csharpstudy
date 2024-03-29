namespace CSharpStudy.Tests.CSharp9
{
    /**
    * Pattern-matching improvements in C# 9.0 (https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements)
    **/
    public static class PatternMatchingEnhancements
    {
        [Fact]
        public static void Example()
        {
            var phrase = "3xampl3";

            if (phrase is not null)
            { // new syntax for null checking
                // pattern-matching improvement
                var firstLetterIsLetter =
                    phrase[0] is (>= 'a' and <= 'z')
                    or (>= 'A' and <= 'Z');
            }
        }

        [Fact]
        public static void Example2()
        {
            var obj = new object();

            // old way
            if (obj is int && (int)obj > 10)
            {
                // do something with obj
            }

            // new way
            if (obj is int i && i > 10)
            {
                // do something with i
            }
        }

        [Fact]
        public static void Example3()
        {
            var obj = new object();

            if (obj is not null)
            {
                // do something with obj
            }
        }

        [Fact]
        public static void Example4()
        {
            var value = new object();

            if (value is 0 or 1)
            {
                // do something
            }

            if (value is > 10)
            {
                // do something
            }
        }

        [Fact]
        public static void Example5()
        {
            int? nullableValue = 42;
            string result = nullableValue switch
            {
                null => "Value is null",
                > 0 => "Value is positive",
                < 0 => "Value is negative",
                _ => "Value is zero"
            };
        }

        public static bool IsLetter(this char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        public static bool IsLetterOrSeparator(this char c) =>
            c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';

    }
}
