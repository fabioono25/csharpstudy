namespace CSharpStudy.Tests.CSharp8
{
    /**
    * Null-coalescing assignment allows you to assign the value of a variable only if that variable is null.
    * Introduces the ??= operator to simplify checking for null and assigning a default value in a single expression.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#null-coalescing-assignment
    **/
    public class NullCoalescingAssignment
    {
        [Fact]
        public void Example()
        {
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17
        }
    }
}
