using System.Text;
namespace DevToys.UniversalEncoding;
public static class EncodingConverter
{
    public static byte[] Transcode(byte[] input, string from, string to)
    {
        string text = EncodingCatalog.Strict(from).GetString(input);
        return EncodingCatalog.Strict(to).GetBytes(text);
    }
    public static string Transform(string input, string format, string from, string to)
    {
        byte[] bytes = format switch
        {
            "HEX" => Convert.FromHexString(new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray())),
            "Base64" => Convert.FromBase64String(input),
            "Text" => EncodingCatalog.Strict(from).GetBytes(input),
            _ => throw new ArgumentException("Unknown input format")
        };
        byte[] output = Transcode(bytes, from, to);
        return format switch
        {
            "HEX" => Convert.ToHexString(output),
            "Base64" => Convert.ToBase64String(output),
            _ => EncodingCatalog.Strict(to).GetString(output)
        };
    }
}
