namespace CSharpStudy.CSharp10;

public class ConstantInterpolationString
{
    public static void ExecuteExample()
    {
        const string message = "Fixed message";
        
        const string constantWithInterpolationString = $"Now it's possible doing this with const: {message}";
    }
}