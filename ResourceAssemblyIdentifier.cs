using DevToys.Api;
using System.ComponentModel.Composition;
namespace DevToys.UniversalEncoding;
[Export(typeof(IResourceAssemblyIdentifier))]
[Name(nameof(UniversalEncodingResourceAssemblyIdentifier))]
internal sealed class UniversalEncodingResourceAssemblyIdentifier : IResourceAssemblyIdentifier
{
    public ValueTask<FontDefinition[]> GetFontDefinitionsAsync() => ValueTask.FromResult(Array.Empty<FontDefinition>());
}
