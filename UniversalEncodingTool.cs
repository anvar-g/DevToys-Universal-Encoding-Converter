using DevToys.Api;
using System.ComponentModel.Composition;
using static DevToys.Api.GUI;
namespace DevToys.UniversalEncoding;
[Export(typeof(IGuiTool))]
[Name("UniversalEncodingConverter")]
[ToolDisplayInformation(
    IconFontName = "FluentSystemIcons",
    IconGlyph = '\uE670',
    ResourceManagerAssemblyIdentifier = nameof(UniversalEncodingResourceAssemblyIdentifier),
    ResourceManagerBaseName = "DevToys.UniversalEncoding.Strings",
    ShortDisplayTitleResourceName = "ShortDisplayTitle",
    LongDisplayTitleResourceName = "LongDisplayTitle",
    DescriptionResourceName = "Description",
    AccessibleNameResourceName = "AccessibleName",
    GroupName = "Converters")]
internal sealed class UniversalEncodingTool : IGuiTool
{
    private readonly IUIMultiLineTextInput _input = MultiLineTextInput();
    private readonly IUIMultiLineTextInput _output = MultiLineTextInput();
    private readonly IUISelectDropDownList _source = SelectDropDownList();
    private readonly IUISelectDropDownList _target = SelectDropDownList();
    private readonly IUISelectDropDownList _format = SelectDropDownList();
    private string _from = "windows-1251";
    private string _to = "utf-8";
    private string _mode = "HEX";
    public UniversalEncodingTool()
    {
        var names = EncodingCatalog.Names;
        _source.WithItems(names.Select(n => Item(text: n, value: n)).ToArray()).OnItemSelected(i => { if (i?.Value is string s) _from = s; });
        _target.WithItems(names.Select(n => Item(text: n, value: n)).ToArray()).OnItemSelected(i => { if (i?.Value is string s) _to = s; });
        _format.WithItems(Item(text: "HEX", value: "HEX"), Item(text: "Base64", value: "Base64"), Item(text: "Text", value: "Text"))
            .Select(0).OnItemSelected(i => { if (i?.Value is string s) _mode = s; });
    }
    public UIToolView View => new UIToolView(
        Stack().Vertical().WithChildren(
            Label().Text("Source encoding"), _source,
            Label().Text("Target encoding"), _target,
            Label().Text("Input / output format"), _format,
            _input.Title("Input"),
            Button().Text("Convert").AccentAppearance().OnClick(ConvertInput),
            _output.Title("Output").ReadOnly()));
    private void ConvertInput()
    {
        try { _output.Text(EncodingConverter.Transform(_input.Text, _mode, _from, _to)); }
        catch (Exception ex) { _output.Text("Error: " + ex.Message); }
    }
    public void OnDataReceived(string dataTypeName, object? parsedData) { }
}
