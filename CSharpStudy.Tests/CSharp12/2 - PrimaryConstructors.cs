namespace CSharpStudy.Tests.CSharp12
{
    /**
    * PrimaryConstructors
    **/
    public class PrimaryConstructorsTest
    {
        public class Person(string name, int age)
        {
            public string Name { get; } = name;
            public int Age { get; } = age;

            public override string ToString() => $"{Name} ({Age})";
        }

        [Fact]
        public void PrimaryConstructors_Example()
        {
            var p = new Person("Alice", 30);
            Assert.Equal("Alice", p.Name);
            Assert.Equal(30, p.Age);
        }
    }
}
