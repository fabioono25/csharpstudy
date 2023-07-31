namespace CSharpStudy.Tests.CSharp2
{
    /**
    * Nullable Value Types allow you to assign null to value type variables (int, bool, double, etc.).
    It provides better handling of database queries where a field value is not assigned.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/nullable-types/
    **/
    public class NullableValueTest
    {
        [Fact]
        public void ExecuteExample()
        {
            int? nullableInt = null;

            if (nullableInt.HasValue)
            {
                int value = nullableInt.Value;
                Console.WriteLine("Value: " + value);
            }
            else
            {
                Console.WriteLine("Nullable value is null");
            }
        }

        [Fact]
        public void ExecuteExample2()
        {
            int? nullableInt = null;

            // null coalescing operator
            int value = nullableInt ?? 0;
            Console.WriteLine("Value: " + value);
        }

        [Fact]
        public void ExecuteExample3()
        {
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
