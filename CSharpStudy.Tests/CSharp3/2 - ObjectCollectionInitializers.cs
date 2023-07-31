namespace CSharpStudy.Tests.CSharp3
{
    /**
    * Object and Collection Initializers provide a shorthand way to initialize objects and collections.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
    **/
    public class ObjectCollectionInitializersTest
    {
        [Fact]
        public void ObjectInitializerTest()
        {
            var person1 = new Person();

            var person2 = new Person("John");

            var person3 = new Person
            {
                Name = "John",
                Age = 30
            };
        }

        [Fact]
        public void CollectionInitializerTest()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        protected class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person()
            {
            }

            public Person(string name)
            {
                Name = name;
            }
        }
    }
}
