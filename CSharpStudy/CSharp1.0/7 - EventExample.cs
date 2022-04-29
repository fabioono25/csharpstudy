namespace CSharpStudy.CSharp1
{
    /// <summary>
    /// In c#, events are used to enable a class or object to notify other classes or objects about the action that is going to happen. 
    /// To declare an event, we need to use event keyword with delegate type. Before raising an event, we need to check whether an event is subscribed or not.
    /// https://docs.microsoft.com/en-us/dotnet/csharp/events-overview
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public delegate string MyDel(string str);
    public class EventExample
    {
        event MyDel MyEvent;

        public EventExample()
        {
            this.MyEvent += new MyDel(this.WelcomeUser);
        }

        private string WelcomeUser(string userName)
        {
            return "Welcome " + userName + "!";
        }
        public static void ExecuteExample()
        {
            Console.WriteLine("C# 1.0 - Event Handler Example");

            var obj1 = new EventExample();
            var result = obj1.MyEvent("Tutorials Point");
            Console.WriteLine(result);
        }
    }
}