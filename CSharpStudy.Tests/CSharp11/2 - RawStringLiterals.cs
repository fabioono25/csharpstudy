namespace CSharpStudy.Tests.CSharp11
{
    /**
    * 
    **/
    public class RawStringLiterals
    {
        [Fact]
        public void RawStringLiterals_Example()
        {
            string json = """
            {
                "name": "Alice",
                "age": 30
            }
            """;

            string expected = "{\r\n    \"name\": \"Alice\",\r\n    \"age\": 30\r\n}";
            // Normalize line endings for cross-platform test stability
            Assert.Equal(expected.Replace("\r\n", "\n"), json.Replace("\r\n", "\n"));
        }
    }
}
