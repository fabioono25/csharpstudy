namespace CSharpStudy.Tests.CSharp4
{
    /**
    * Dynamic types are resolved at runtime, not compile time, allowing late-binding and dynamic resolution for members at runtime.
    It provides a way to interact with dynamic languages, COM objects, and other code that relies on dynamic dispatch.
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic
    **/
    public class DynamicTypingTest
    {
        [Fact]
        public void Example()
        {
            // Create the dynamic type and attribute a value
            dynamic variable1 = 1;
            Console.WriteLine(variable1.GetType().ToString()); //System.Int32

            // In this case the method will receive a dynamic type
            var dog1 = new Dog();
            var person1 = new Person();

            MakeItTalk(dog1);
            MakeItTalk(person1);

            // As you can see, it can be dangerous. You can just pass an invalid object, 
            // that will not be infered/verified at compile-time, generating an exception at runtime
            var amoeba = new Amoeba();
            MakeItTalk(amoeba); // Return a RuntimeBinderException, when calling Talk() method
        }

        public static void MakeItTalk(dynamic animal)
        {
            animal.Talk();
        }


        protected class Dog
        {
            public void Talk()
            {
                Console.WriteLine("Wolf, wolf!");
            }
        }

        protected class Person
        {
            public void Talk()
            {
                Console.WriteLine("Hey you!");
            }
        }

        protected class Amoeba { }
    }
}
