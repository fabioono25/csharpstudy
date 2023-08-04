namespace CSharpStudy.Tests.CSharp8
{
    /**
    * Nullable reference types allows you to specify nullable reference types using annotations to help prevent null reference exceptions and improve code safety.
    * https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
    * it is possible to disable the warning for the entire project by adding the following property to the project file:
    * <Nullable>enable</Nullable>
    **/
    public class NullableRefTypes
    {
        [Fact]
        public void Example()
        {
            string? name = null;  // compile will show a warning here
            Console.WriteLine(name.Length);

            string surName = null; // No warning
            Console.WriteLine(surName);
            
            #nullable enable
            string? nickName = null; // no warning
            Console.WriteLine(nickName);

            #nullable disable
            string? address = null; // warning again
            Console.Write(address);
        }
    }
}
