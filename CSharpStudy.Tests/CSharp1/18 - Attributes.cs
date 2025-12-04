using System.Reflection;

namespace CSharpStudy.Tests.CSharp1
{
    [Serializable]
    public class User
    {
        [Obsolete("Use FullName instead")]
        public string Name { get; set; }

        [Custom("Metadata value")]
        public void Save() { }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CustomAttribute : Attribute
    {
        public string Info { get; }
        public CustomAttribute(string info) => Info = info;
    }

    public class AttributeExample
    {
        [Fact]
        public void Attribute_CanBeRetrievedViaReflection()
        {
            var method = typeof(User).GetMethod("Save");
            var attr = method.GetCustomAttribute<CustomAttribute>();

            Assert.Equal("Metadata value", attr.Info);
        }

        [Fact]
        public void ObsoleteAttribute_IsPresent()
        {
            var prop = typeof(User).GetProperty("Name");
            var attr = prop.GetCustomAttribute<ObsoleteAttribute>();

            Assert.NotNull(attr);
            Assert.Equal("Use FullName instead", attr.Message);
        }
    }
}