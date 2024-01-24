

using System.Text.Json;
using Newtonsoft.Json;

internal class User
{
  public string Name { get; set; }
  public string Email { get; set; }

}

public class FilesTests
{
  [Fact]
  public void CreateWriteFileTest()
  {
    var path = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
    File.WriteAllText(path, "Hello World!");

    var text = File.ReadAllText(path);
    Assert.Equal("Hello World!", text);

    File.Delete(path);
  }

  [Fact]
  public void ManagingJsonTest()
  {
    // manage json using System.Text.Json
    var user = new User { Name = "John", Email = "test@test.com" };

    // create a json file for test
    var file = Path.Combine(Directory.GetCurrentDirectory(), "test.json");
    // using serialize method
    var jsonString = System.Text.Json.JsonSerializer.Serialize(user);
    File.WriteAllText(file, jsonString);

    var path = Path.Combine(Directory.GetCurrentDirectory(), "test.json");
    var jsonRead = File.ReadAllText(path);
    var userRet = System.Text.Json.JsonSerializer.Deserialize<User>(jsonRead);

    Assert.Equal("John", userRet.Name);
  }

  [Fact]
  public void ManagingJsonNewtonSoftTest()
  {
    // manage json using Newtonsoft.Json
    var user = new User { Name = "John", Email = "test@test.com" };
    var json = Newtonsoft.Json.JsonConvert.SerializeObject(user);

    var path = Path.Combine(Directory.GetCurrentDirectory(), "test.json");
    File.WriteAllText(path, json);

    var jsonRead = File.ReadAllText(path);
    var userRet = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(jsonRead);

    Assert.Equal("John", userRet.Name);
  }

}