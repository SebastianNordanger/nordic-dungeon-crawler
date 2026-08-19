# Full .NET SDK image for the build stage - need the compiler and everything to actually build the project (not just run it)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copying only the .csproj files first (from both projects) and restoring - Docker remembers this step's result (skips redoing it) as long as the csprojs haven't changed, 
# so it only reruns restore when dependencies change, not every single time a .cs file gets edited (saves rebuild time)
COPY NordicDungeonCrawler_CSharpProject1/*.csproj NordicDungeonCrawler_CSharpProject1/
COPY NordicDungeonCrawler_CSharpProject1_WebAPI/*.csproj NordicDungeonCrawler_CSharpProject1_WebAPI/
RUN dotnet restore NordicDungeonCrawler_CSharpProject1_WebAPI/NordicDungeonCrawler_CSharpProject1_WebAPI.csproj

# Now copying the rest of the project files and publishing a release build into /App
COPY . . 
RUN dotnet publish NordicDungeonCrawler_CSharpProject1_WebAPI/NordicDungeonCrawler_CSharpProject1_WebAPI.csproj -c Release -o /app

# Second image is just for running the app, not building it - a lot smaller since it doesn't need the SDK/compiler at all
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Runs in Development mode so Swagger UI is available at /swagger
ENV ASPNETCORE_ENVIRONMENT=Development

# Grabbing just the published output from the build step above, not the whole source
COPY --from=build /app .

# Command that actually runs when the container starts - samee as running "dotnet [name].dll" normally
ENTRYPOINT ["dotnet", "NordicDungeonCrawler_CSharpProject1_WebAPI.dll"]
