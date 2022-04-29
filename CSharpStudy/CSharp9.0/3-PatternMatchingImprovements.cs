namespace CSharpStudy.CSharp9
{
    public class PatternMatchingImprovements
    {
        public static void ExecuteExample()
        {
            var phrase = "3xampl3";

            if (phrase is not null)
            { // new syntax for null checking
                // pattern-matching improvement
                var firstLetterIsLetter =
                    phrase[0] is (>= 'a' and <= 'z')
                    or (>= 'A' and <= 'Z');
            }
        }
    }
}
