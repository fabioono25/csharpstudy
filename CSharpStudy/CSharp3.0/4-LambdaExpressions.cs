using System.Collections.Generic;
using System.Linq;

namespace CSharpStudy.CSharp3_0
{
    public class LambdaExpressionsTest
    {
        public static void ExecuteExample()
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5)); //25

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            //IEnumerable<int>
            var numbersBellowFour = numbers.Where(n => n < 4);

            //IOrderedEnumerable<int>
            var numbersBellowFour2 = numbers.OrderByDescending(n => n < 4);

            //IEnumerable<string>
            var numbersBellowFour3 = numbers.Where(n => n < 4).Select(n => "The number bellow is " + n);

            //int
            var numbersBellowFour4 = numbers.Count(n => n < 4);

            //IEnumerable<<anonymous type: string Type, int Value>>
            var numbersBellowFour5 = numbers.Where(n => n < 4).Select(n =>
                                                                           new
                                                                           {
                                                                               Type = "Number",
                                                                               Value = n
                                                                           });
        }
    }
}