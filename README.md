[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-orange.svg)](https://sonarcloud.io/summary/new_code?id=stzdiego_APICreditSimulator)

# ApiCreditSimulator

This project is a credit simulator API built with .NET 5.

## Project Structure

The project is divided into three main parts:

- [ApiCreditSimulator.Api](ApiCreditSimulator.Api/ApiCreditSimulator.Api.csproj): Contains the API logic and database migrations.
- [ApiCreditSimulator.Access](ApiCreditSimulator.Access/ApiCreditSimulator.Access.csproj): Contains the database access logic.
- [ApiCreditSimulator.Shared](ApiCreditSimulator.Shared/ApiCreditSimulator.Shared.csproj): Contains entities and logic shared between the other projects.

In addition, there is a test project [ApiCreditSimulator.Tests](ApiCreditSimulator.Tests/ApiCreditSimulator.Tests.csproj) that contains unit tests for the application logic.

## How to Build

To build the project, you can use the pre-commit hooks defined in [.pre-commit-config.yaml](.pre-commit-config.yaml). These hooks take care of building the projects and checking for outdated .NET dependencies before each commit.

## Code Quality

Code quality is checked with SonarCloud. You can see the current state of the code quality at the following link:

[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-orange.svg)](https://sonarcloud.io/summary/new_code?id=stzdiego_APICreditSimulator)

## License

This project is licensed under the MIT license. You can see the details in the [LICENSE](LICENSE) file.