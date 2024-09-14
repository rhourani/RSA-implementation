namespace RSA.Models;

public class SecEntity
{
    public string KeyName { get; set; }
    public string KeysLocation { get; set; }
    public string PlainText { get; set; }
    public string CipherText { get; set; }
    public string CipherToPlainText { get; set; }
    public int TimeToEncrypt { get; set; }
    public int TimeToDecrypt { get; set; }
}
