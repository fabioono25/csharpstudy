namespace CSharpStudy.Tests.CSharp2
{
    /**
    * interfaces in C# 2.0 can include static methods, properties, and indexers.
    It enables you to define a common behavior or utility methods within an interface without requiring and implementing class.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
    **/
    public class StaticInterfacesTest
    {
        [Fact]
        public void StaticClassesExample()
        {
            double resultF = TemperatureConverter.CelsiusToFahrenheit("123.12");
        }

        [Fact]
        public void StaticPropertyInterface()
        {
            // Usage of static member in interface
            ILogger logger = ILogger.DefaultLogger;
            logger.Log("Hello, World!");
        }

        protected interface ILogger
        {
            void Log(string message);

            static ILogger DefaultLogger
            {
                get { return new ConsoleLogger(); }
            }
        }

        protected class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("Logging: " + message);
            }

            public static void Test()
            {
                Console.WriteLine("test");
            }
        }

        // static classes provide a way to define classes that can't be instantiated and can only contain static members such as properties, methods and fields.
        // they are commonly used to group related utility or helper methods or to provide a conventien way to access shared resources.
        protected static class TemperatureConverter
        {
            public static double CelsiusToFahrenheit(string temperatureCelsius)
            {
                // Convert argument to double for calculations.
                double celsius = Double.Parse(temperatureCelsius);

                // Convert Celsius to Fahrenheit.
                double fahrenheit = (celsius * 9 / 5) + 32;

                return fahrenheit;
            }

            public static double FahrenheitToCelsius(string temperatureFahrenheit)
            {
                // Convert argument to double for calculations.
                double fahrenheit = Double.Parse(temperatureFahrenheit);

                // Convert Fahrenheit to Celsius.
                double celsius = (fahrenheit - 32) * 5 / 9;

                return celsius;
            }
        }
    }

}
