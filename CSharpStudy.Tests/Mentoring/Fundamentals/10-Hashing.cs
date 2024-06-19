using System.Security.Cryptography;

public class Hashing
{
    [Fact]
    public void Test()
    {
        List<object> names = new List<object>();
        names.Add("Bob");

        foreach (var item in names)
        {
            // item = "asas";
        }
        

        var singleName = names.SingleOrDefault(n => n == "Bobd");

        Console.WriteLine(singleName);
    }


  [Fact]
  public void HashingTest()
  {
    byte[] hash;

    using var fs = File.OpenRead("../../../Mentoring/Fundamentals/9-Dynamic.cs");
    hash = MD5.Create().ComputeHash(fs); // very poor hashing algorithm. Do not use in production. Hash length: 16 bytes

    // SHA1:
    hash = SHA1.Create().ComputeHash(fs); // poor hashing algorithm. Do not use in production. Hash length: 20 bytes

    // SHA256:
    hash = SHA256.Create().ComputeHash(fs); // good hashing algorithm. Hash length: 32 bytes

    // SHA512:
    hash = SHA512.Create().ComputeHash(fs); // good hashing algorithm. Hash length: 64 bytes

    // HMACSHA256:
    using var hmac = new HMACSHA256();
    hash = hmac.ComputeHash(fs); // good hashing algorithm. Hash length: 32 bytes
  }
}