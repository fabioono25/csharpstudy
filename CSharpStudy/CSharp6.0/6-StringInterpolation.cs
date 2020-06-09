using static System.Console;

namespace CSharpStudy.CSharp6
{
    public class StringInterpolation
    {
        public static void ExecuteExample()
        {
            var author = "John Nash";
            var salary = 32.246423;

            WriteLine($"The author is: {author}. His age is: {calculateAge()}");
            WriteLine($"The salary average is {salary:F2}");
        }

        internal static int calculateAge() => 26;
    }
}