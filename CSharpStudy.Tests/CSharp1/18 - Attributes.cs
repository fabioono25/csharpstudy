namespace CSharpStudy.Tests.CSharp1
{
    /// <summary>
    /// Attributes can be placed on most any declaration, though a specific attribute might restrict the types of declarations on which it is valid.
    /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>

    [Serializable]                  //attribute that indicates that the class can be serialized
    [Custom("Just a test name")]    //using a custom attribute    
    public class AttributeExample
    {
        [Fact]
        public void ExecuteExample()
        {
            Console.WriteLine("C# 1.0 - Atribute Example");
            CustomAttribute attrib = new CustomAttribute("name");
            OldMethod();
        }

        [Obsolete("This method is deprecated. Use NewMethod instead.")]
        public static void OldMethod()
        {
            // Method implementation...
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CustomAttribute : Attribute //define a custom atribute
    {
        private string name;

        public CustomAttribute(string name)
        {
            this.name = name;
        }
    }
}