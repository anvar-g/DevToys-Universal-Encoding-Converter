using System.Text;
namespace DevToys.UniversalEncoding;
public static class EncodingCatalog
{
    static EncodingCatalog() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    public static string[] Names => Encoding.GetEncodings().Select(x => x.Name).Distinct().OrderBy(x => x).ToArray();
    public static Encoding Strict(string name) => Encoding.GetEncoding(name, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
}
