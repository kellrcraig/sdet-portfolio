param(
    [string]$TestFilter = ""
)

# Get solution folder based on script location
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$solutionDir = Resolve-Path "$scriptPath\.."

# Run dotnet test with passed-in filter
dotnet test "$solutionDir/SauceDemo.Tests.sln" `
  --configuration Release `
  --no-build `
  --logger "trx;LogFileName=test-results.trx" `
  --filter $TestFilter

if ($LASTEXITCODE -ne 0) {
    throw "dotnet test failed."
}
