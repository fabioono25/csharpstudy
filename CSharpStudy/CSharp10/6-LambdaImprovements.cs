namespace CSharpStudy.CSharp10;

public class LambdaImprovements
{
    public static void ExecuteExample()
    {

        Func<string, int> parsed = (string s) => int.Parse(s); // old way to resolve the parse

        var parsedNew = (string s) => int.Parse(s); // new way, now using var

        // var parseError = s => int.Parse(s); // error: the delegade type could not be inferred

        // var choose = (bool b) => b ? 1 : "two"; // ERROR: Can't infer return type       

        var chooseOk = object (bool b) => b ? 1 : "two"; // Correctly solved
    }
}