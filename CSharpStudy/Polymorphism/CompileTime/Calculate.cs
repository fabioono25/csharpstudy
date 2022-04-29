namespace CSharpStudy.Polymorphism.CompileTime
{
    //compile time polymorphism, using method overloading (ealy binding/static binding)
    public class Calculate
    {
        public void AddNumbers(int a, int b)
        {
            Console.WriteLine("a + b = {0}", a + b);
        }

        public void AddNumbers(int a, int b, int c)
        {
            Console.WriteLine("a + b + c = {0}", a + b + c);
        }
    }

    public class CompileTimePolymorphismExample
    {
        public static void Execute()
        {
            var c = new Calculate();
            c.AddNumbers(1, 2);
            c.AddNumbers(3, 4, 5);
        }
    }
}
