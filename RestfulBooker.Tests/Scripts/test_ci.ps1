# Get the absolute path to the folder this script is in
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition

# Build full path to test_base.ps1
$testBasePath = Join-Path $scriptDir 'test_base.ps1'

# Call test_base.ps1 with the filter
& $testBasePath