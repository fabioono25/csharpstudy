using System.Globalization;
using Xunit;

public class MyTestClass
{
  [Fact]
  public void StringComparisonTest()
  {
    // compare foo with FOO using case-insensitive comparison
    Assert.True("foo".Equals("FOO", System.StringComparison.OrdinalIgnoreCase));

    // compare foo with FOO using case-sensitive comparison
    Assert.False("foo".Equals("FOO", System.StringComparison.Ordinal));

    // compare "ṻ" with "ǖ" using case-insensitive comparison
    Assert.False("ṻ".Equals("ǖ", System.StringComparison.OrdinalIgnoreCase));

    // compare "ṻ" with "ǖ" using case-sensitive comparison
    Assert.False("ṻ".Equals("ǖ", System.StringComparison.Ordinal));
  }

  [Fact]
  public void CompareToTest() {
    Console.WriteLine ("Boston".CompareTo ("Austin"));    // 1
    Console.WriteLine ("Boston".CompareTo ("Boston"));    // 0
    Console.WriteLine ("Boston".CompareTo ("Chicago"));   // -1
    Console.WriteLine ("ṻ".CompareTo ("ǖ"));              // 1
    Console.WriteLine ("foo".CompareTo ("FOO"));          // -1
  }

  [Fact]
  public void FormattingInvariantCulture(){
    var us = CultureInfo.GetCultureInfo("en-US");
    var invariant = CultureInfo.InvariantCulture;

    Assert.Equal("1,234.56", 1234.56.ToString("N", us));
    Assert.Equal("1234.56", 1234.56.ToString("N", invariant));

    // dates
    var date = new DateTime(2017, 1, 1, 12, 34, 56);
    Assert.Equal("1/1/2017 12:34:56 PM", date.ToString("G", us));
    Assert.Equal("01/01/2017 12:34:56", date.ToString("G", invariant));
  }

  [Fact]
  public void FormattingWithCultureInfo() {
    var uk = CultureInfo.GetCultureInfo("en-GB");
    var jp = CultureInfo.GetCultureInfo("ja-JP");
    var us = CultureInfo.GetCultureInfo("en-US");

    Assert.Equal("£1,234.56", 1234.56.ToString("C", uk));
    Assert.Equal("￥1,235", 1234.56.ToString("C", jp));
    Assert.Equal("$1,234.56", 1234.56.ToString("C", us));
  }
}
