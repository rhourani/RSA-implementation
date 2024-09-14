using ExpressEncription;
using System.Diagnostics;
namespace RSA;

public static class InfoSec
{
    public static string GenerateKey(string keyName)
    {
        string location = "C:\\Users\\Admin\\source\\repos\\RSA\\";
        RSAEncription.MakeKey($@"{location}{keyName}_Public_Key", $@"{location}{keyName}_Private_Key");

        return location;
    }

    public static (string cipher, int time) Encrypt(string plainText, string keyName)
    {
        string location = "C:\\Users\\Admin\\source\\repos\\RSA\\";

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        

        var cipherText = RSAEncription.EncryptString(plainText, $@"{location}{keyName}_Public_Key");
     
        var timeElapsed = stopWatch.Elapsed.Microseconds;
        return (cipherText, timeElapsed);
    }

    public static (string plainText, int time) Decrypt(string cipherText, string keyName)
    {
        string location = "C:\\Users\\Admin\\source\\repos\\RSA\\";

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var decryptText = RSAEncription.DecryptString(cipherText, $@"{location}{keyName}_Private_Key");

        var timeElapsed = stopWatch.Elapsed.Microseconds;
        return (decryptText.ToString().TrimEnd(new char[] { '\0' }), timeElapsed);
    }
}