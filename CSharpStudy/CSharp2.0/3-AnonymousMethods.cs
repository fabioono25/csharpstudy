namespace CSharpStudy.CSharp2_0
{
    public class AnonymousMethods
    {
        public delegate void PrintHelloMessage(string name);

        public static void ExecuteExample()
        {
            //Using anonymous method to acces variables
            PrintHelloMessage print = delegate (string name)
            {
                Console.WriteLine("Hello {0}", name);
            };

            print("John");

            //converting anonymous method into a delegate type with a list of parameters
            Action<int, double> introduce = delegate { Console.WriteLine("hi"); };
            introduce(12, 12.32);

            new TestEvent().ImplementBehavior();
        }
    }

    public class TestEvent
    {

        public event EventHandler PrintMessageEvent;
        public void ImplementBehavior()
        {
            PrintMessageEvent += delegate (object sender, EventArgs e) { Console.Write("Hi"); };
        }
    }
}