namespace CSharpStudy.Tests.CSharp7
{
    /**
    * C# 7.2 - Private Protected Access Modifier allows a class member to be accessed by containing class or derived classes that are in the same assembly.
    * protected will make the member visible only to subclasses, but they could be in any assembly. There will be no restriction that they have to be placed in the same assembly.
    * internal will restrict the visibility of the member to the same assembly, but all classes in that assembly will be able to access it, not only the subclasses of the base class declaring it.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-2#private-protected-access-modifier
    **/
    public class PrivateProtected
    {
        [Fact]
        public void Example()
        {
            var person = new Person
            {
                Name = "James",
                //Age = 20 //'PrivateProtected.Person.Age' is inaccessible due to its protection level
            };

            var person2 = new Person2
            {
                Name = "Josh",
            };
            person2.MyAge = 12; //accessible 
        }

        private class Person
        {
            public string Name { get; set; }
            private protected int Age { get; set; }
        }

        private class Person2 : Person
        {
            public int MyAge
            {
                get { return Age; } //property accessible
                set { Age = value; }
            }
        }
    }
}
