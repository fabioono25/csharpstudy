namespace CSharpStudy.CSharp4_0
{
    public class NamedArgumentsTest
    {
        public static void ExecuteExample()
        {
            // Normal order
            Method1("param1", "param2", 3);

            // It's possible to use the named parameters
            Method1(parameter1: "param1", parameter2: "param2", parameter3: 3);

            // Even inverting the order
            Method1(parameter3: 3, parameter2: "param2", parameter1: "parameter1");

            // They are strongly typed, returning exeption at compile-time
            //Method1(parameter3: "asdasdasd", parameter2: 222, parameter1: "parameter1");

            // Even in different order, you should provide all parameters
            //Method1(parameter3: 3, parameter2: "param2");
        }

        public static void Method1(string parameter1, string parameter2, int parameter3)
        {
        }
    }
}
