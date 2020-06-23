//adding static
using static System.Math;
using static System.Console;

namespace CSharpStudy.CSharp6
{
    public class UsingStatic
    {
        public static void ExecuteExample()
        {
            var result = Pow(5, 2);

            Write($"Five squared is {result}.");
        }
    }
}