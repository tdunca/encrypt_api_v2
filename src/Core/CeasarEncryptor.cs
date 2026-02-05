using System;
using System.Text;

namespace Core;

public sealed class CaesarEncryptor : Encryptor
{
    public string Encrypt(string text, int shift) => Shift(text, shift);

    public string Decrypt(string text, int shift) => Shift(text, -shift);

    private static string Shift(string text, int shift)
    {
        if (text is null) throw new ArgumentNullException(nameof(text));
        shift %= 26;

        var sb = new StringBuilder(text.Length);

        foreach (var ch in text)
        {
            if (char.IsLetter(ch))
            {
                var offset = char.IsUpper(ch) ? 'A' : 'a';
                var normalized = ch - offset;
                var shifted = (normalized + shift) % 26;
                if (shifted < 0) shifted += 26;

                sb.Append((char)(offset + shifted));
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }
}
