namespace CSharpStudy.CSharp2_0
{
    public class DelegateInference
    {
        delegate string StrMod(string str);

        public static void ExecuteExample()
        {
            //previous version 2.0
            StrMod strOp = new StrMod(removeSpaces);

            //new using the inference
            strOp = removeNewLines;
        }       

        private static string removeSpaces(string name) { return string.Empty; }

        private static string removeNewLines(string name) { return string.Empty; }
    }
}