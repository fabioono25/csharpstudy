namespace CSharpStudy.Tests.CSharp1
{

    /**
    * Enums are used to create named constants.
    * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/enum
    **/

    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class EnumsTest
    {
        [Fact]
        public void ExecuteExample()
        {
            DayOfWeek today = DayOfWeek.Wednesday;

            Console.WriteLine("Today is " + today);

            if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
            {
                Console.WriteLine("It's the weekend!");
            }
            else
            {
                Console.WriteLine("It's a weekday.");
            }
        }
    }
}
