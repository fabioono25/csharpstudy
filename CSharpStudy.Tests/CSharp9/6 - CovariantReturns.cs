namespace CSharpStudy.Tests.CSharp9
{
    /**
    * covariant returns - allows overriding a method with a more specific return type
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#covariant-returns
    **/
    public class CovariantReturns
    {
        [Fact]
        public void Example()
        {
            BaseClass baseClass = new DerivedClass();
            Base b = baseClass.GetBase(); // Valid, no casting needed
            // Derived d = baseClass.GetBase(); // Error, requires casting
        }

        internal class Base {};
        internal class Derived : Base {};

        internal class BaseClass
        {
            public virtual Base GetBase() => new();
        }

        internal class DerivedClass : BaseClass
        {
            public override Derived GetBase() => new();
        }
    }
}
