# Arcane Assistant Application

A C# console application for tabletop role-playing game utilities. Arcane Assistant combines dice rolling, character generation, character save slots, jokes, and a themed console interface inspired by a fantasy assistant.

> **Portfolio project**  
> This application was created in 2025 as part of my vocational retraining as an IT specialist for application development. It is intended to demonstrate practical C# programming, object-oriented design, input validation, file handling, and the development of a complete console application.

## Project Information

- **Project:** Arcane Assistant Application
- **Created:** 2025, as part of my vocational retraining as an IT specialist for application development
- **Technology:** C#
- **Application type:** Windows console application
- **Framework:** .NET Framework 4.8
- **Build system:** MSBuild / Visual Studio
- **Platform:** Windows
- **Author:** Toni Dietzel

## Features

### Dice Roller

- Roll D4, D6, D8, D10, D12, and D20 dice
- Choose how many dice to roll
- Calculate and display the total result
- Reroll directly from the result screen
- Validate numeric input and return safely to the menu

### Character Management

- Generate fantasy characters from predefined data collections
- Use ancestries, professions, deities, alignments, motivations, talents, flaws, and heritages
- Display generated character details in the console
- Save characters in up to nine slots
- Load and overwrite saved character slots
- Store character data locally for later sessions

### User Experience

- Themed fantasy dialogue and console presentation
- Personalized greeting using a stored user name
- Random fantasy-themed jokes
- Credits screen
- Maximized console window on startup

## Requirements

- Windows 10 or later
- .NET Framework 4.8
- Visual Studio 2022 with the .NET desktop development workload, or a compatible MSBuild installation

The project is intentionally kept simple and does not require NuGet packages, Maven, Gradle, or an external database.

## Installation and Usage

1. Download or clone this repository.
2. Open `ArcaneAssistantApplication.sln` in Visual Studio 2022.
3. Build the solution in Debug or Release configuration.
4. Start the application with `Ctrl+F5` or by running the generated executable.

The compiled executable is created in one of these directories:

```text
ArcaneAssistantApplication/bin/Debug/
ArcaneAssistantApplication/bin/Release/
```

Alternatively, build the solution from a Developer PowerShell or Developer Command Prompt:

```bat
msbuild ArcaneAssistantApplication.sln /t:Build /p:Configuration=Release
```

Then start the application with:

```bat
ArcaneAssistantApplication\bin\Release\ArcaneAssistantApplication.exe
```

## Project Structure

```text
ArcaneAssistantApplication/
├── ArcaneAssistantApplication.sln       Visual Studio solution
├── ArcaneAssistantApplication/
│   ├── Program.cs                       Application entry point and application logic
│   ├── App.config                       .NET Framework startup configuration
│   ├── ArcaneAssistantApplication.csproj Project and build configuration
│   └── Properties/
│       └── AssemblyInfo.cs              Assembly metadata
└── README.md                            Project documentation
```

The `bin` and `obj` directories are generated during the build and should not be published as source files.

## Architecture

The application uses a compact object-oriented structure:

- `Program` contains the application entry point and coordinates the console menus.
- `Deity`, `Ancestry`, `Profession`, and `Character` are the data model classes.
- `DeityDatabase`, `AncestryDatabase`, and `ProfessionDatabase` provide predefined fantasy data.
- Menu methods handle navigation, user input, dice rolling, jokes, character generation, and credits.
- Character serialization methods convert character data to and from a simple text-based format.
- `App.config` defines the supported .NET Framework runtime.

The current implementation keeps the application logic in `Program.cs`. This makes the project easy to run and understand while leaving room for future separation into dedicated model, service, and UI classes.

## Data Storage

The application stores user-specific data in the following Windows directory:

```text
%LocalAppData%\ArcaneAssistant\
```

The directory contains:

- `user.txt` for the selected user name
- `savedcharacters.txt` for the nine character save slots

Using `%LocalAppData%` prevents the application from requiring administrator rights when it is installed in a protected directory such as `C:\Program Files`.

## Usage

### First Start

On the first start, enter a user name when prompted. The name is stored locally and used for future greetings.

### Main Menu

The main menu provides the following options:

```text
[1] Roll dice
[2] Open character menu
[3] Tell a joke
[9] Show credits
[0] Exit
```

### Dice Roller

1. Choose a die type from D4 to D20.
2. Enter the number of dice to roll.
3. Review the total result.
4. Reroll or return to the dice menu.

### Character Menu

Use the character menu to generate a character, inspect the result, and save it to one of the nine available slots. Saved characters can be loaded in later sessions from `%LocalAppData%\ArcaneAssistant\savedcharacters.txt`.

## Development Notes

The project demonstrates the following practical skills:

- C# classes, properties, constructors, and collections
- Object-oriented modeling of domain data
- Console application design and menu navigation
- Input validation with `TryParse` and custom validation methods
- Random number generation for dice and character generation
- File reading and writing with `System.IO`
- Serialization of structured data into a text file
- Use of Win32 APIs for console window handling
- .NET Framework project configuration with MSBuild
- Separation of data models, predefined data, and application workflows

## Known Limitations and Possible Extensions

- The application currently targets Windows and .NET Framework 4.8.
- The user interface is console-based rather than graphical.
- Character data is stored in a simple delimiter-based text format.
- There are no automated unit or UI tests yet.
- The predefined fantasy data is maintained directly in the source code.

Possible next steps include moving the models and services into separate files, introducing JSON serialization, adding automated tests, supporting configurable data sets, creating a graphical user interface, and migrating to modern .NET.

## Publishing on GitHub

For the first publication, create an empty repository on [GitHub](https://github.com). Then publish the project from its root folder using Git:

```bat
git init
git add .
git commit -m "Initial version of the Arcane Assistant application"
git branch -M main
git remote add origin https://github.com/YOUR-USERNAME/ArcaneAssistantApplication.git
git push -u origin main
```

Replace `YOUR-USERNAME` and the repository name with your own values. When creating the GitHub repository, do not automatically add another README or license so that the existing files can be uploaded without a conflict.

Before publishing, make sure that generated build output such as `bin`, `obj`, and Visual Studio user settings are excluded with a `.gitignore` file.

## License

This project was created for learning and demonstration purposes. A license can be added once the conditions for reusing the source code have been decided.
