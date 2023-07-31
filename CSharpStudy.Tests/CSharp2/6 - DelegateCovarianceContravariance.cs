namespace CSharpStudy.Tests.CSharp2
{
    /**
    * Covariance and contravariance are terms that refer to the ability to use a less derived (less specific) or more derived type (more specific) than originally specified.
      Covariance preserves assignment compatibility and contravariance reverses it.
      Covariance enables you to assing a delegate to another delegate that has a more derived return type (more specific).
      Contravariance enables you to assign a delegate to another delegate that has a less derived parameter type (less specific).
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/
    **/
    public class DelegateCovarianceContravarianceTest
    {
        // delegate with return type as base class
        delegate Animal AnimalFactory();

        // delegate with return type as derived class
        //delegate which take one mammal argument and return nothing 
        delegate void CopyState(Mammal a);

        void copyMammalState(Mammal mammal)
        {
        }

        void copyAnimalState(Animal mammal)
        {
        }

        void CopyGiraffeSate(Giraffe giraffe)
        {
        }

        static Animal CreateAnimal()
        {
            Console.WriteLine("Creating an animal.");
            return new Animal();
        }

        static Mammal CreateMammal()
        {
            Console.WriteLine("Creating a mammal.");
            return new Mammal();
        }

        [Fact]
        public void SimpleExample()
        {
            // example of covariance supported by C# 1.0
            Animal[] animals = new Mammal[10]; // mammals can be stored in an array of animals (true for reference types)
        }

        [Fact]
        public void TestingCovariance()
        {
            // an assignment statement where covariant occurs by allowing Mammal return type in place of Animal return type
            AnimalFactory animalFactory = CreateMammal;
            // Calling the delegate
            Animal animal = animalFactory();
        }

        [Fact]
        public void TestingContravariance()
        {
            // an assignment statement where contravariance occurs by allowing Animal parameter type in place of Mammal parameter type
            CopyState cs1 = copyAnimalState; // contravariance
            cs1(new Mammal());
            // But the following code will not be supported as covariance is not supported in parameters.
            // CopyState cs2 = CopyGiraffeSate; 
            // If covariance would support here, then the above statement would generate an exception as cs2 can handle Giraffe but not Tiger.
            // CopyState cs2 = CopyGiraffeSate;
            // Tiger tiger = new Tiger();
            // cs2(tiger);
        }

        public static void Example2()
        {
            //covariance: object of a more derived type is assigned to an object of a less derived type
            string str = "asd";
            object obj = str;
            IEnumerable<string> strings = new List<string>();

            //covariance in arrays occurs since version 1.0, but it's not safe
            object[] array = new String[10];

            //contravariance: An object that is instantiated with a less derived type argument
            // is assigned to an object instantiated with a more derived type argument.
            // Assignment compatibility is reversed
            Action<object> actObject = SetObject;
            Action<string> actString = actObject;
        }

        static void SetObject(object o) { }

        protected class Animal { }
        protected class Mammal : Animal { }
        protected class Giraffe : Mammal { }
    }

}
