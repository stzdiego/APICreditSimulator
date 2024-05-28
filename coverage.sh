#!/bin/bash
rm -rf ApiCreditSimulator.Tests/TestResults
rm -rf Reports
dotnet test ApiCreditSimulator.Tests --collect:"XPlat Code Coverage" --settings coverlet.runsettings
reportgenerator "-reports:ApiCreditSimulator.Tests/TestResults/**/*.cobertura.xml" "-targetdir:Reports" -reporttypes:"Html"
coverlet ApiCreditSimulator.Tests/bin/Debug/net8.0/ApiCreditSimulator.Tests.dll --target "dotnet" --targetargs "test ApiCreditSimulator.Tests --no-build" --output ApiCreditSimulator.Tests/TestResults/ --exclude-by-file "**/Migrations/*,**/Program.cs"
open Reports/index.html