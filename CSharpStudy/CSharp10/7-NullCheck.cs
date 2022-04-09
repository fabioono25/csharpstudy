namespace CSharpStudy.CSharp10;

public class NullCheck
{
    public static void ExecuteExample() {

        object message = null;

        // old-way:
        if (message == null)
            throw new ArgumentNullException(nameof(message));

        // refactory old-way:
        var x = message ?? throw new ArgumentNullException(nameof(message));

        // C# 9.0 way:
        if (message is null)
            throw new ArgumentNullException(nameof(message));
        
        // C# 10 way:
        ArgumentNullException.ThrowIfNull(nameof(message));
    }
}