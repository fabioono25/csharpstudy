using System;

namespace CSharpStudy.CSharp1
{
    public delegate string MyDel(string str);
    public class EventExample
    {
        event MyDel MyEvent;

        public EventExample()
        {
            this.MyEvent += new MyDel(this.WelcomeUser);
        }

        private string WelcomeUser(string userName) => $"Welcome {userName}.";

        public static void ExecuteExample()
        {
            var obj1 = new EventExample();
            var result = obj1.MyEvent("Tutorials Point");
            Console.WriteLine(result);
        }
    }
}