# Get the absolute path to the solution folder based on script location
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$solutionDir = Resolve-Path "$scriptPath\.."

dotnet test $solutionDir/SauceDemo.Tests.sln --configuration Release --no-build --logger "trx;LogFileName=test-results.trx" --filter "TestCategory!=wip"
if ($LASTEXITCODE -ne 0) { throw "dotnet test failed." }