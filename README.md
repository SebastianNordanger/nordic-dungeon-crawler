# Nordic Dungeon Crawler
A Norwegian folklore-themed dungeon crawler built in C#, featuring a REST API (ASP.NET Core), a simple web frontend, and Docker containerization.

## Features
- Console-based combat system (OOP: encapsulation, inheritance, polymorphism, abstraction)
- Save/leaderboard system (CSV file storage)
- REST API built with ASP.NET Core (Swagger UI included)
- Dockerized (multi-stage Dockerfile)

## How to run
**Console app:**
1. Open the solution in Visual Studio
2. Right click `NordicDungeonCrawler_CSharpProject1` in Solution Explorer -> "Set as Startup Project"
3. Run (F5 or the green Run button) - a battle plays out in the console and the result is saved to `highscores.csv`

**REST API + frontend:**
1. Right click `NordicDungeonCrawler_CSharpProject1_WebAPI` in Solution Explorer -> "Set as Startup Project"
2. Run (F5 or the green Run button) - the API starts on the address shown in the terminal (e.g. `https://localhost:7208`, the port can differ depending on the machine)
3. Available endpoints:
   - `GET /api/battle` - runs a battle and returns the outcome
   - `GET /api/leaderboard` - returns the battle history for the leaderboard
4. Open `/index.html` for the frontend, or `/swagger` for the API docs
   
**With Docker:**
1. Install and start Docker Desktop
2. From the solution root, run: `docker build -t nordic-dungeon-crawler .`
3. Run: `docker run -p 8080:8080 nordic-dungeon-crawler`
4. Open `http://localhost:8080/index.html` for the frontend, or `http://localhost:8080/swagger` for the API docs

The Docker version keeps its own `highscores.csv`, so its leaderboard is separate from the local one.

**Requirements:** Visual Studio with the .NET workload for the local versions, or Docker Desktop for the Docker setup.

## Built with
C#, ASP.NET Core, Docker, HTML/JS
