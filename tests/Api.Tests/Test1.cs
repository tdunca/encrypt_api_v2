using Core;
using Xunit;

namespace Api.Tests;

public class CaesarEncryptorTests
{
    private readonly Encryptor _encryptor = new CaesarEncryptor();

    [Fact]
    public void Encrypt_Then_Decrypt_Returns_Original()
    {
        var text = "Hello World!";
        var shift = 3;

        var encrypted = _encryptor.Encrypt(text, shift);
        var decrypted = _encryptor.Decrypt(encrypted, shift);

        Assert.Equal(text, decrypted);
    }

    [Theory]
    [InlineData("Hello", 3, "Khoor")]
    [InlineData("abc", 1, "bcd")]
    [InlineData("XYZ", 2, "ZAB")]
    public void Encrypt_Known_Cases(string input, int shift, string expected)
    {
        var encrypted = _encryptor.Encrypt(input, shift);
        Assert.Equal(expected, encrypted);
    }

    [Fact]
    public void Encrypt_Shift_0_Returns_Same_Text()
    {
        var text = "NoChange!";
        var encrypted = _encryptor.Encrypt(text, 0);

        Assert.Equal(text, encrypted);
    }
}
