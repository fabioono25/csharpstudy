namespace CSharpStudy.Tests.CSharp1
{

    /**
    * Conditionals are used to execute a block of statements based on a condition.
    * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/iteration-statements
    **/


    public class ConditionalsTest
    {
        [Fact]
        public void ExecuteExample()
        {
            if (true)
            {
                // Code to be executed if the condition is true
            }
            else if (false)
            {
                // Code to be executed if the anotherCondition is true
            }
            else
            {
                // Code to be executed if none of the above conditions are true
            }

            switch (1)
            {
                case 1:
                    // Code to be executed if variable is 1
                    break;
                case 2:
                    // Code to be executed if variable is 2
                    break;
                default:
                    // Code to be executed if none of the above cases match
                    break;
            }

        }
    }
}
