namespace CSharpStudy.CSharp3_0
{
    public class ImplicitTypedLocalVariablesTest
    {
        public static void ExecuteExample()
        {
            var number = 10; //implicit typed
            int number2 = 10;//explicit typed

            var x = new ClassTest(); //x is an instance of ClassTest
        }        
    }

    internal class ClassTest {

    }
}