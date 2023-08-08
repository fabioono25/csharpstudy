namespace CSharpStudy.Tests.CSharp9
{
    /**
    * init only properties allows properties to be set only during object initialization and not modified afterward. 
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#init-only-properties-and-fields
    **/
    public class InitOnly
    {
        [Fact]
        public void Example()
        {
            var p = new Person { FirstName = "John", LastName = "Doe" };
            // p.FirstName = "Jane"; // Error: cannot assign to property 'FirstName' in object of type 'Person' because it is read-only
        }

        internal record Person
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
        }
    }
}
