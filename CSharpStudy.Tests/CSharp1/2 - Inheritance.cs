namespace CSharpStudy.Tests.CSharp1
{
    /**
    * Inheritance allows you to create a new class (derived class) from an existing class (base class)
    * adding new members to derived class or modifying existing members from the base one.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/inheritance
    **/
    public class Base
    {
        public virtual string Show() => "Base";
    }

    public class Derived : Base
    {
        public override string Show() => "Derived";
    }

    public class HidingDerived : Base
    {
        // Hides base method, not overrides it
        public new string Show() => "HidingDerived";
    }

    public class InheritanceTest
    {
        [Fact]
        public void DerivedOverridesBase_Show_ReturnsDerived()
        {
            Base subject = new Derived();
            Assert.Equal("Derived", subject.Show());
        }

        [Fact]
        public void HidingDerived_Show_ReturnsBase_WhenCastToBase()
        {
            Base subject = new HidingDerived();
            Assert.Equal("Base", subject.Show());
        }

        [Fact]
        public void HidingDerived_Show_ReturnsHidingDerived_WhenDirectlyAccessed()
        {
            HidingDerived subject = new HidingDerived();
            Assert.Equal("HidingDerived", subject.Show());
        }
    }
}
