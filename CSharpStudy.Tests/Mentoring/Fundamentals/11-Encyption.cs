using System.IO.Compression;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Threading.Tasks;

public class Encryption
{
  [Fact]
  public async Task EncryptTest()
  {
    byte[] key = new byte[16];
    byte[] iv = new byte[16];

    var cryptoRng = RandomNumberGenerator.Create();
    cryptoRng.GetBytes(key);
    cryptoRng.GetBytes(iv);

    using (System.Security.Cryptography.Aes algorithm = System.Security.Cryptography.Aes.Create())
    {
      using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
      using (Stream f = File.Create("serious.bin"))
      using (Stream c = new CryptoStream(f, encryptor, CryptoStreamMode.Write))
      using (Stream d = new DeflateStream(c, CompressionMode.Compress))
      using (StreamWriter w = new StreamWriter(d))
        await w.WriteLineAsync("Small and secure!");

      using (ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv))
      using (Stream f = File.OpenRead("serious.bin"))
      using (Stream c = new CryptoStream(f, decryptor, CryptoStreamMode.Read))
      using (Stream d = new DeflateStream(c, CompressionMode.Decompress))
      using (StreamReader r = new StreamReader(d))
        Console.WriteLine(await r.ReadLineAsync());     // Small and secure!
    }
  }

  [Fact]
  public void RSATest()
  {
    using (RSA rsa = RSA.Create())
    {
      byte[] privateKey = rsa.ExportRSAPrivateKey();
      byte[] publicKey = rsa.ExportRSAPublicKey();

      rsa.ImportRSAPrivateKey(privateKey, out int bytesRead);
      rsa.ImportRSAPublicKey(publicKey, out bytesRead);

      byte[] data = new byte[100];
      byte[] signature = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
      bool verified = rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }
  }
}