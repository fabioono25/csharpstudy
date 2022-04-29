namespace CSharpStudy.Polymorphism.Runtime
{
    // Base Class
    public class Users
    {
        public virtual void GetInfo()
        {
            Console.WriteLine("Base Class");
        }
    }

    // Derived Class
    public class Details : Users
    {
        public override void GetInfo()
        {
            Console.WriteLine("Derived Class");
        }
    }

    public class RuntimePolymorphismExample
    {
        public static void Execute()
        {
            var details = new Details();
            details.GetInfo();

            var user = new Users();
            user.GetInfo();
        }
    }
}
