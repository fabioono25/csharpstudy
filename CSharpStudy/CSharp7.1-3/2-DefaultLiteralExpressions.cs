namespace CSharpStudy.CSharp7123
{
    public static class DefaultLiteralExpressions
    {
        public static void ExecuteExample()
        {
            var value1 = default(int); // old implementation for default value expressions
            int value2 = default;      // new implementation for default value expressions
            Console.WriteLine(SumValues(value1, value2));

            Console.WriteLine(SumValues());
        }

        //defining a method with the default expression, so it can be executed withoud passing parameters
        private static int SumValues(int val1 = default(int), int val2 = default) => val1 + val2;
    }
}