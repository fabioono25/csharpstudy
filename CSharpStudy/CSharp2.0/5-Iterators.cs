using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpStudy.CSharp2_0
{
    public class Iterators
    {
        public static void ExecuteExample()
        {
            DaysOfTheWeek days = new DaysOfTheWeek();

            foreach (string day in days)
            {
                Console.Write(day + " ");
            }

            var result1 = UsingYieldBreak();    //0 - 9
            var result2 = WithoutUsingBreak(); //0 - 10
        }

        public static IEnumerable<int> UsingYieldBreak()
        {
            for (int i = 0; ; i++)
            {
                if (i < 10)
                {
                    yield return i;
                }
                else
                {
                    // Indicates that the iteration has ended, everything 
                    // from this line on will be ignored
                    yield break;
                }
            }
            yield return 10; // This will never get executed
        }
        
        public static IEnumerable<int> WithoutUsingBreak()
        {
            for (int i = 0; ; i++)
            {
                if (i < 10)
                {
                    // Yields a number
                    yield return i;
                }
                else
                {
                    // Terminates just the loop
                    break;
                }
            }
            yield return 10; //this code will be executed
        }                
    }

    internal class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < days.Length; index++)
            {
                // Yield each day of the week.
                yield return days[index];
            }
        }
    }      
}