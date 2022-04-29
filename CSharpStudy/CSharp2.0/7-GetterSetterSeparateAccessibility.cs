namespace CSharpStudy.CSharp2_0
{
    public class GetterSetterSeparateAccessibility
    {
        public static void ExecuteExample()
        {
            var test = new AccessibilityTest();
            Console.WriteLine(test.Name); //write "Hello"
            //The property or indexer 'AccessibilityTest.Name' cannot be used in this context 
            // because the set accessor is inaccessible
            //test.Name = "asdasd"; 
        }
    }

    public class AccessibilityTest
    {
        private string _name = "Hello";

        public string Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                _name = value;
            }
        }
    }
}