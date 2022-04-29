//adding static
using static System.Math;

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