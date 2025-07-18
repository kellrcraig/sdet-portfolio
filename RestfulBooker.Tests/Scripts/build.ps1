# Get the absolute path to the solution folder based on script location
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$solutionDir = Resolve-Path "$scriptPath\.."

dotnet clean $solutionDir/RestfulBooker.Tests.sln
if ($LASTEXITCODE -ne 0) { throw "dotnet clean failed." }

dotnet restore $solutionDir/RestfulBooker.Tests.sln
if ($LASTEXITCODE -ne 0) { throw "dotnet restore failed." }

dotnet build $solutionDir/RestfulBooker.Tests.sln --configuration Release --no-restore
if ($LASTEXITCODE -ne 0) { throw "dotnet build failed." }