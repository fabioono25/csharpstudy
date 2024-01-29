using System.Threading;

public class ThreadSafe
{
  static List<string> _list = new List<string>();

  [Fact]
  public void ThreadSafeTest()
  {
    new Thread(AddItem).Start();
    new Thread(AddItem).Start();
  }

  [Fact]
  public void AddItem()
  {
    // lock is a monitor. The idea is that only one thread can enter the lock at a time.
    lock (_list) _list.Add("Item");

    string[] items;
    lock (_list) items = _list.ToArray(); // lock is a monitor. The idea is that only one thread can enter the lock at a time.

    foreach (var item in items)
    {
      Console.WriteLine(item);
    }
  }
}