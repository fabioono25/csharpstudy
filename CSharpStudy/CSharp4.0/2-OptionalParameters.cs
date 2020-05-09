namespace CSharpStudy.CSharp4_0
{
    public class OptionalParametersTest
    {
        public static void ExecuteExample()
        {
            // Only parameter 1 is called. However, parameter2 and parameter3 have the default values
            Method1("param1");

            // Now we have a different set of values
            Method1("param1", "param2 new value", 333);

            // In this case we used named arguments. parameter2 is still fullfiled with the default value
            Method1("parameter1", parameter3: 1);
        }        

        public static void Method1(string parameter1, string parameter2 = "abc", int parameter3 = 3) {
        }
    }
}