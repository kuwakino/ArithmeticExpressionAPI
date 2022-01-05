# Arithmetic Expression API
Exercise:
> Provide two Web API endpoints for evaluating very basic arithmetic expressions: you need to support only subtraction (-) and addition (+). 
> One endpoint should refuse to operate on negative numbers in the expression, the other doesn’t have this restriction.
>
> Prove that your code works with unit tests. Document the design choices you make during the process (or anything else you see worthwhile).
>
> The submission should be a git repository containing the solution written in C#.

The solution `ArithmeticAPI.sln` contains two projects:
1. Arithmetic Expression API Project - Web API;
2. Arithmetic Expression API Test Project - Unit Tests;

## Arithmetic Expression API Project
Project contains the ASP.NET Core web API.
Structured in three layers:
1. Controllers - presentation layer;
2. Core - core business rules (use cases) for the solution;
3. Services - contains services shared among other layers;

## Arithmetic Expression API Test Project
Project contains unit tests for Arithmetic API Project. 
- The objective is to get feedback from implemented code as fast as possible;
- Should cover the most significant code for the solution - mostly use cases;
- Unit tests written on TDD aproach (Red, Green, Refactor);
    - to focus on code design (and refactoring) more than code coverage;
- Test structure:
    - Test Classes - targeting a specific class on the main project (Arithmetic API Project);
    - Test Methods - test cases named on BDD (Given, When, Then) notation;
        - AAA (Arrange, Act, Assert) internal structure on each test case;

## Local environment
Developed on VS 2022:
1. Git Clone this project;
2. Open the solution `ArithmeticAPI.sln` file on VS 2022;
3. Start Debug - Debug > Start Debugging;
4. The development execution supports [OpenAPI/Swagger](https://swagger.io/docs/specification/about/);