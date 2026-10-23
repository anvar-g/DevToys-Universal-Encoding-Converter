$ErrorActionPreference = 'Stop'
dotnet restore
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
dotnet build -c Release
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
dotnet pack -c Release --no-build
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
Write-Host 'Package: bin/Release/*.nupkg'
