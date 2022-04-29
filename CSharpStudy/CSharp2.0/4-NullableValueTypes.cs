namespace CSharpStudy.CSharp2_0
{
    public class NullableValueTypes
    {
        public static void ExecuteExample()
        {
            int? b = 10;

            if (b.HasValue)
            {
                Console.WriteLine($"b is {b.Value}");
            }
            else
            {
                Console.WriteLine("b does not have a value");
            }

            int? c = 28;
            int d = c ?? -1;
            Console.WriteLine($"d is {d}");  // output: d is 28

            int? e = null;
            int f = e ?? -1;
            Console.WriteLine($"f is {f}");  // output: f is -1

            // int? g;
            // int h = g ?? -1; //Use of unassigned local variable 'g' - compile-time error
            // Console.WriteLine($"h is {h}");  // output: f is -1            
        }
    }
}