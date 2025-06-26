# Get solution folder based on script location
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$solutionDir = Resolve-Path "$scriptPath\.."

# Run dotnet test with passed-in filter
dotnet test "$solutionDir/RestfulBooker.Tests.sln" `
  --configuration Release `
  --no-build `
  --logger "trx;LogFileName=test-results.trx" `

if ($LASTEXITCODE -ne 0) {
    throw "dotnet test failed."
}
