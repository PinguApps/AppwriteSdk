dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Check if the dotnet-reportgenerator-globaltool is installed
$toolInstalled = dotnet tool list -g | Select-String -Pattern "dotnet-reportgenerator-globaltool"

if (-not $toolInstalled) {
    # Install the dotnet-reportgenerator-globaltool globally
    dotnet tool install -g dotnet-reportgenerator-globaltool
}

# Generate the report
reportgenerator -reports:coverage.opencover.xml -targetdir:coverage-report -assemblyfilters:+PinguApps.Appwrite.Server

# Open the generated report in the default browser
Start-Process "coverage-report/index.html"
