dotnet clean ./SauceDemo.Tests.csproj
if ($LASTEXITCODE -ne 0) { throw "dotnet clean failed." }

dotnet restore ./SauceDemo.Tests.csproj
if ($LASTEXITCODE -ne 0) { throw "dotnet restore failed." }

dotnet build ./SauceDemo.Tests.csproj --configuration Release --no-restore
if ($LASTEXITCODE -ne 0) { throw "dotnet build failed." }