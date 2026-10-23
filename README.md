# DevToys Universal Encoding Converter

Source project for DevToys 2.x (.NET 8).

![Universal Encoding Converter](screenshots/encoding-converter.png)

## Build

```powershell
dotnet clean
dotnet restore
dotnet build -c Release
dotnet pack -c Release --no-build
```

Install the resulting `.nupkg` from DevToys > Manage extensions.

## Usage

- HEX: input and output are hexadecimal representations of bytes.
- Base64: input and output are Base64 representations of bytes.
- Text: Unicode input is encoded into the source encoding and decoded from the target; this is a round-trip and does not recover unknown original bytes.
- Strict fallback raises errors on unmappable characters.
- BOM and automatic encoding detection are not implemented.
