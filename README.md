# Console-Based Number Card Game

A small C# console game where a player competes against a computer-controlled opponent over three rounds. Each player holds two numbered cards and tries to finish with the smallest difference between them by choosing whether to keep or swap cards.

The project focuses on object-oriented design, game-state management, input validation, simple bot decision-making, and file-based activity logging.

## Features

- Human vs. computer gameplay
- Three-round match flow
- Random card values from 1 to 8
- Stick or swap decisions each round
- Choice of which card to replace
- Computer opponent with a simple decision strategy
- Hidden opponent cards until the final result
- Input validation for menu choices and Yes/No prompts
- Winner calculation with a tie-break rule
- Optional timestamped game log
- Replay support without restarting the application

## How the Game Works

Each player starts with two randomly generated cards.

During each of the three rounds, the player can:

1. **Stick** — keep both current cards.
2. **Swap** — replace either the first or second card with a new random value.

The computer makes its own decision using a basic strategy that considers the difference between its cards and their values.

### Scoring

The primary score is the absolute difference between the two cards:

```text
score = |card 1 - card 2|
```

The player with the **lower score** wins.

If both players have the same score, the player with the **lower total card value** wins. If both the score and total are equal, the match ends in a tie.

## Tech Stack

- **C#**
- **.NET 10**
- Console application
- `System.IO` for game-log persistence

## Project Structure

```text
.
├── Game.cs                         # Main game loop, rounds and winner logic
├── Player.cs                       # Player model, card logic and bot strategy
├── ConsoleUI.cs                    # Console input/output and validation
├── GameLog.cs                      # Timestamped file-based game logging
└── Console Based Card Game.csproj  # .NET project configuration
```

## Getting Started

### Prerequisites

Install the **.NET 10 SDK** and verify it is available:

```bash
dotnet --version
```

### Run the project

Clone the repository:

```bash
git clone https://github.com/abhishekldev07/Password-checking-system.git
cd Password-checking-system
```

Run the game:

```bash
dotnet run --project "Console Based Card Game.csproj"
```

Then follow the prompts in the terminal.

## Game Logs

A log file is created for each match session in:

```text
Documents/CSharpGameLogs/
```

Logs include round-by-round card states, player actions, timestamps, final cards, and the match result. At the end of a game, the log can also be displayed directly in the console.

## Concepts Demonstrated

- Object-oriented programming
- Inheritance and method overriding
- Enums and game-state modeling
- Encapsulation
- Console input validation
- Basic decision-making logic
- File and directory handling
- Separation of game logic, UI, player behavior, and logging
