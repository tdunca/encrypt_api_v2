namespace Core;

public interface Encryptor
{
    string Encrypt(string text, int shift);
    string Decrypt(string text, int shift);
}