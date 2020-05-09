using System;

namespace CSharpStudy.CSharp4_0
{
    public class DynamicTest
    {
        public static void ExecuteExample()
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

        public static void MakeItTalk(dynamic animal) {
            animal.Talk();
        }       
    }

    public class Dog {
        public void Talk() {
            Console.WriteLine("Wolf, wolf!");
        }
    }

    public class Person {
        public void Talk() {
            Console.WriteLine("Hey you!");
        }
    }    

    public class Amoeba {}
}