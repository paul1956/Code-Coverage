echo %time%
Set MANUAL_TESTS=
Rem dotnet test --collect:"XPlat Code Coverage" --settings coverletArgs.runsettings
Rem JSON
dotnet test ./XUnitTestProject1.vbproj /p:CollectCoverage=true /p:CoverletOutputFormat=json /p:CoverletOutput=./TestResults/LastRun/Coverage.json /p:Exclude=\"[coverlet.*]*,[*]Coverlet.Core*,[xunit*]*,[Microsoft.DotNet.XUnitExtensions]*"
