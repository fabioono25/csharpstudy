namespace CSharpStudy.CSharp1_2
{
    public class UnsafeTest
    {
        public unsafe static void ExecuteExample()
        {
            int var = 20;
            int* p = &var;

            Console.WriteLine("Data is: {0} ", var);        //20
            Console.WriteLine("Address is: {0}", (int)p);   //-428064772 (changes each execution)
        }
    }
}