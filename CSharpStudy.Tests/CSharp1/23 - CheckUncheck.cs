/**
  * The checked and unchecked keywords in C# are used to control the behavior of arithmetic operations involving integer types (byte, sbyte, short, ushort, int, uint, long, ulong) and floating-point types (float, double).
  * The checked keyword is used to explicitly enable overflow checking for integral-type arithmetic operations and conversions.
  * The unchecked keyword is used to suppress overflow-checking for integral-type arithmetic operations and conversions.
  * https://www.tutorialsteacher.com/csharp/csharp-checked-and-unchecked
  * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/language#checkforoverflowunderflow
  **/

namespace CSharpStudy.Tests.CSharp1
{
    public class CheckUncheckTest
    {
        [Fact]
        public void ExecuteExample()
        {
            byte number = 255;

            Console.WriteLine(byte.MaxValue); //255

            number += 1;
            Console.WriteLine(number); //0

            number += 1;
            Console.WriteLine(number); //1

            try
            {
                unchecked
                {
                    number = byte.MaxValue;
                    number += 1; //0
                }

            }
            catch (OverflowException)
            {
                Console.WriteLine("This exception will not be thrown");
            }

            try
            {
                checked
                {
                    number = byte.MaxValue;
                    number += 1; //0
                }

            }
            catch (OverflowException)
            {
                Console.WriteLine("An overflow exception was just ocurred!");
            }
        }
    }
}