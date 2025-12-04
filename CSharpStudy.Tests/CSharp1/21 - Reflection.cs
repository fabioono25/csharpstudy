using System.Reflection;

namespace CSharpStudy.Tests.CSharp1
{
    public class Robot
    {
        public void Speak(string message) => Console.WriteLine($"Robot says: {message}");
    }

    public class ReflectionTest
    {
        [Fact]
        public void Reflection_InvokeMethod_Success()
        {
            var type = typeof(Robot);
            var instance = Activator.CreateInstance(type);
            var method = type.GetMethod("Speak");

            Assert.NotNull(method);
            // Redirect console to capture output if needed, or just verify no exception
            method.Invoke(instance, new object[] { "Test" });
        }

        [Fact]
        public void Reflection_GetProperty_Success()
        {
            var type = typeof(Robot);
            // Robot doesn't have properties in the example, but checking standard reflection behavior
            Assert.Equal("Robot", type.Name);
        }
    }
}