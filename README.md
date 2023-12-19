# Name Picker

This is a console application that reads a JSON input of people and their partners, and assigns each person to someone other than their partner.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them:

- .NET 8.0 or later

### Installing

A step by step series of examples that tell you how to get a development environment running:

1. Clone the repository
2. Open the solution in Visual Studio
3. Restore the NuGet packages
4. Build the solution

## Running the Application

To run the application, you can use the `dotnet run` command in the terminal. The application expects a JSON input in the following format:

```json
[
    { "Name": "Alice", "Partner": "Bob" },
    { "Name": "Bob", "Partner": "Alice" },
    ...
]
```

For example:
```
echo names.json | dotnet run
```

