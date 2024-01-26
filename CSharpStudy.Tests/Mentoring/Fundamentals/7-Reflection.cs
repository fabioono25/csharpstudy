
internal class Walnut
{
  private bool cracked;
  public void Crack()
  {
    cracked = true;
  }
}

public class ReflectionTest
{
  [Fact]
  public void GetProperties()
  {
    var members = typeof(Walnut).GetMembers();
    foreach (var member in members)
    {
      Console.WriteLine(member.Name);
    }

    Assert.Equal(6, members.Length);
  }
}
