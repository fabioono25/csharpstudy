namespace CSharpStudy.Tests.CSharp2
{
    /**
    * Delegate inference allows you to assign a method to a delegate without explicitly instantiating the delegate.
    Before delegate inference, when assigning a method to a delegate, you had to explicitly create a new delegate instance and specify the target method. 
    Delegate inference simplifies this process by inferring the delegate type from the method being assigned.
    It allows for implicit conversion between method group references and delegate types, making delegate instantiation more concise and readable.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates
    **/
    public class DelegateInferenceTest
    {
        delegate string StrMod(string str);

        private static string removeSpaces(string name) { return "test"; }
        private static string removeNewLines(string name) { return "test2"; }

        [Fact]
        public void Example()
        {
            //previous version 2.0
            StrMod strOp = new StrMod(removeSpaces);
            Console.WriteLine(strOp(""));

            //new using the inference
            strOp = removeNewLines;
            Console.WriteLine(strOp(""));
        }
    }
}
