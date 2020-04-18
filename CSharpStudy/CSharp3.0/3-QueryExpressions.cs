using System.Collections.Generic;
using System.Linq;

namespace CSharpStudy.CSharp3_0
{
    public class QueryExpressionsTests
    {
        public static void ExecuteExample()
        {
            //basic example
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6};

            //IEnumerable<int>
            var numbersBellowFour = 
                from number in numbers
                where number < 4
                select number;

            //IOrderedEnumerable<int>
            var numbersBellowFour2 = 
                from number in numbers
                where number < 4
                orderby number descending
                select number;                

            //IEnumerable<string>
            var numbersBellowFour3 = 
                from number in numbers
                where number < 4
                select "The number bellow is " + number;            

            //int
            var numbersBellowFour4 = 
                (from number in numbers
                 where number < 4
                 select number)
                 .Count();                            

            //IEnumerable<<anonymous type: string Type, int Value>>
            var numbersBellowFour5 = 
                from number in numbers
                where number < 4
                select new { Type="Number", Value = number };            
        }        
    }
}