namespace CSharpStudy.Tests.CSharp11
{
    /**
    * 
    **/
    public class RequiredMembers
    {
        public class Person
        {
            public required string Name { get; init; }
            public int Age { get; set; }
        }

        [Fact]
        public void RequiredMembers_Example()
        {
            var p = new Person { Name = "Alice" };
            Assert.Equal("Alice", p.Name);

            // Compilation Error if Name is not set:
            // var p2 = new Person(); 
        }
    }
}
