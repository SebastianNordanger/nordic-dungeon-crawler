# nordic-dungeon-crawler
A Norwegian folklore-themed dungeon crawler built in C#, featuring a REST API (ASP.NET Core), a simple web frontend, and Docker containerization.

## Features
- Console-based combat system (OOP: encapsulation, inheritance, polymorphism, abstraction)
- Save/leaderboard system (CSV file storage)
- REST API built with ASP.NET Core (Swagger UI included)
- Dockerized (multi-stage Dockerfile)

## How to run
1. Make sure Docker is installed
2. From the solution root, run: 'docker build -t nordic-dungeon-crawler .'
3. Run: 'docker run -p 8080:8080 nordic-dungeon-crawler'
4. Open 'http://localhost:8080/index.html' for the frontend, or 'http://localhost:8080/swagger' for the API docs

## Built with
C#, ASP.NET Core, Docker, HTML/JS
