namespace CSharpStudy.Tests.CSharp1
{
  /// <summary>
  /// In c#, events are used to enable a class or object to notify other classes or objects about the action that is going to happen. 
  /// Events enable the implementation of the observer pattern and allow objects to communicate with each other.
  /// To declare an event, we need to use event keyword with delegate type. Before raising an event, we need to check whether an event is subscribed or not.
  /// https://docs.microsoft.com/en-us/dotnet/csharp/events-overview
  /// </summary>
  /// <param name="str"></param>
  /// <returns></returns>
  public delegate void MyDel(string str);
  public class EventExample
  {
    event MyDel MyEvent;

    public EventExample()
    {
      this.MyEvent += new MyDel(this.WelcomeUser);
      this.MyEvent += new MyDel(this.SayHi);
    }

    private void WelcomeUser(string userName)
    {
      Console.WriteLine("Welcome " + userName + "!");
    }

    private void SayHi(string userName)
    {
      Console.WriteLine("And hi " + userName + "!");
    }

    [Fact]
    public void ExecuteExample()
    {
      Console.WriteLine("C# 1.0 - Event Handler Example");

      var obj1 = new EventExample();
      obj1.MyEvent("Tutorials Point");


      MyPublisher publisher = new MyPublisher();
      MySubscriber subscriber = new MySubscriber();

      publisher.MyEvent += subscriber.HandleEvent; // Subscribing to the event
      publisher.OnMyEvent(EventArgs.Empty); // Raising the event
    }
  }

  public class MyPublisher
  {
    public event EventHandler MyEvent;

    internal virtual void OnMyEvent(EventArgs e)
    {
      MyEvent?.Invoke(this, e);
    }
  }

  public class MySubscriber
  {
    public void HandleEvent(object sender, EventArgs e)
    {
      // Event handling code
      Console.WriteLine("Event fired");
    }
  }
}