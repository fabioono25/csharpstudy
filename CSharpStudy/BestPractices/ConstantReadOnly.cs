namespace CSharpStudy.BestPractices
{
    public class ConstantReadOnly
    {
        public const int ConstantVariable = 100;
        public static readonly int ReadOnlyVariable = 0;

        public ConstantReadOnly()
        {
            //ConstantVariable = 2; //IMPOSSIBLE
            //ReadOnlyVariable = 3; //POSSIBLE TO REASSIGN JUST IN A STATIC CONSTRUCTOR
        }

        public void Method()
        {
            //ConstantVariable = 2; //IMPOSSIBLE
            //ReadOnlyVariable = 3; //IMPOSSIBLE: only in constructor

            Console.WriteLine(ConstantVariable);
            Console.WriteLine(ReadOnlyVariable);
        }
    }
}
