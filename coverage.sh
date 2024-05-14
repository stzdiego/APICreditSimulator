#!/bin/bash
rm -rf ApiCreditSimulator.Tests/TestResults
dotnet test ApiCreditSimulator.Tests --collect:"XPlat Code Coverage"
coverlet ApiCreditSimulator.Tests/bin/Debug/net9.0/ApiCreditSimulator.Tests.dll --target "dotnet" --targetargs "test ApiCreditSimulator.Tests --no-build" --format cobertura --output .ApiCreditSimulator.Tests/TestResults/
reportgenerator "-reports:ApiCreditSimulator.Tests/TestResults/**/*.cobertura.xml" "-targetdir:Reports" -reporttypes:Html
open Reports/index.html