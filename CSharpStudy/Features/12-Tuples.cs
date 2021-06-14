using System;

namespace CSharpStudy.CSharp9.Features
{
    public class Tuples
    {
        public static void ExecuteExample()
        {
            /*
             * var now = DateTime.Now;
var tuple = (now.Day, now.Month, now.Year);
Console.WriteLine (tuple.Day);               // OK
             */

            var t1 = Tuple.Create(1);
            var x = t1.Item1;

            var t2 = ValueTuple.Create(1);
            var y = t2.Item1;
        }
    }
}
