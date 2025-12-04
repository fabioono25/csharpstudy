namespace CSharpStudy.Tests.CSharp13
{
    public class ParamsCollections
    {
        // C# 13 allows params with any collection type
        public void Print(params IEnumerable<string> items) 
        {
            Assert.NotNull(items);
            Assert.NotEmpty(items);
        }

        public void PrintList(params List<string> items)
        {
             Assert.NotNull(items);
        }

        [Fact]
        public void ParamsCollections_Example()
        {
            // Passing individual arguments
            Print("A", "B", "C");

            // Passing a collection
            Print(new List<string> { "A", "B" });
            
            // Passing to List params
            PrintList("X", "Y");
        }
    }
}
