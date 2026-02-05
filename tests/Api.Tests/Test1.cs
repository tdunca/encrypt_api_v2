using Core;
using Xunit;

namespace Api.Tests;

public class CaesarEncryptorTests
{
    private readonly Encryptor _encryptor= new CaesarEncryptor();

    [Fact]
    public void Encrypt_Then_Decrypt_Returns_Original()
    {
        var text = "Hello World!";
        var shift = 3;

        var encrypted = _encryptor.Encrypt(text, shift);
        var decrypted = _encryptor.Decrypt(encrypted, shift);

        Assert.Equal(text, decrypted);
    }

    [Fact]
    public void Encrypt_Hello_Shift3_Is_Khoor()
    {
        Assert.Equal("Khoor", _encryptor.Encrypt("Hello", 3));
    }
}
