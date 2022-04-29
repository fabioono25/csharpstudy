namespace CSharpStudy.CSharp7
{
    public class PatternMatching
    {
        public static void ExecuteExample()
        {
            //is pattern
            var input = 12;

            if (input is int count)
                Console.WriteLine(count);

            ClassTest classTest = null;

            if (classTest is null)
            {
                classTest = new ClassTest();
                Console.WriteLine("ClassTest is not null anymore");
            }

            //case pattern, with input of type int = 12
            switch (input)
            {
                case int n when n > 100:
                    Console.WriteLine("Value of n is more than 100.");
                    break;

                case int n when n <= 100:
                    Console.WriteLine("Value of n is less than 100.");
                    break;

                default:
                    Console.WriteLine("value not found");
                    break;
            }
        }
    }

    public class ClassTest
    {

    }
}