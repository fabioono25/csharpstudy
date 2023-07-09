namespace CSharpStudy.CSharp1
{
    public class ValueTypesExample
    {
        //a variable of a value type contains a value of the type. A value has its values allocated on the stack
        //value types can be created at compile time and stored in stack memory (garbage collector can't access the stack)
        //you cannot derive a new type from a value type. But structs can implement interfaces (like ref types)

        //Value types includes:
        //Integral Types: sbyte, byte, short, ushort, int, uint, long, ulong
        //Floating-point numeric types: float, double, decimal
        //bool
        //structs, enumerations
        //value types have default values: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/default-values-table

        public static void ExecuteExample()
        {
            Console.WriteLine("C# 1.0 - Value Types Examples");

            //you cannot use it before initilize it
            //int myInt;
            //Console.WriteLine(myInt);
            //int myInt = new int();  //equals myInt = 0
            //Console.WriteLine(myInt);

            //attribution doesn't change the value
            int? x = 1;
            int? y = x;
            y += 10;
            Console.WriteLine(x);
            Console.WriteLine(y);

            //struct
            Book book1 = new Book { name = "book 1", price = 9.99M };
            Book book2 = book1;
            book2.name = "book 2";
            Console.WriteLine(book1.name); //book1
            Console.WriteLine(book2.name); //book2

            Console.WriteLine(WeekDay.Saturday);
            Console.WriteLine((int)WeekDay.Saturday);

            Console.ReadKey();
        }

        public struct Book
        {
            public decimal price;
            public string name;
        }

        enum WeekDay { Sunday, Monday, Tuesday, Wednesday, Friday, Saturday }
    }
}
