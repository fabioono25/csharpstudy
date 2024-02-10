using System.Threading.Tasks;

public class DateTimeTest
{
  [Fact]
  public void DateTimeNowUtcNow()
  {
    // DateTime.Now: Gets a DateTime object that is set to the current date and time on this computer, expressed as the local time.
    var local = DateTime.Now;
    Assert.Equal(DateTimeKind.Local, local.Kind);

    // DateTime.UtcNow: Gets a DateTime object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
    var utc = DateTime.UtcNow;
    Assert.Equal(DateTimeKind.Utc, utc.Kind);
  }
}
