// Progress:
// Phase 1: Player, enemy creation, and combat system (TakeDamage, Heal (*Removed), Attack, and IsAlive). Done!

// Phase 2: Save/high-score system - saves results to highscores.csv (List <GameResult>, File Input/Output, constructor overloading for saved dates), loads history on startup, and calculates a leaderboard (best run). Done!

// Phase 3: Wrapped game logic in an ASP.NET Core Web API (BattleController exposes GET /api/battle via BattleSimulator.RunBattle()), added Swagger UI for testing endpoints (an endpoint is just a URL the API responds to, e.g. /api/battle) in the browser,
// converted GameResult fields to properties (get; set;) so the API could convert it to JSON, and fixed console app + API sharing the same highscores.csv (CsvPath uses a fixed path so both projects read/write one file instead of two separate ones). Done! 

// Phase 4: Added a simple web frontend (plain HTML/JS in wwwroot/index.html) - Hildr! (Battle) button calls GET /api/battle via fetch and displays winner, rounds survived, date, and best run. Also showed the existing leaderboard history via
// + GET /api/leaderboard endpoint, with a Leaderboard button that lists all past battle results, each with its date. Done!

// Phase 5 (Last phase!): Packaged the WebAPI (plus its console-project dependency) with Docker - wrote a multi-stage Dockerfile (SDK image builds/publishes, smaller aspnet runtime image just runs it), built and ran the image locally, inside the container.
// Fixed a real cross-environment bug along the way (DateTime.Parse relied on the system's regional settings, which differ inside the container - switched to ParseExact with a fixed format + InvariantCulture). Also set ASPNETCORE_ENVIRONMENT=Development in the
// Dockerfile so Swagger UI works too. Docker terminology recap: an image is a built snapshot/blueprint of the app, a container is a running instance of that image. Done!

// OOP pillars (Done: Encapsulation -> Inheritance -> Polymorphism -> Abstraction):
// Phase 1: Encapsulation (Moved to Combatant in Phase 3!), keeping an object's data protected, only changed through controlled methods (Which means, Health only changes through methods like TakeDamage, not set directly from outside):
// Here, Player/Enemy control their own state - Health only changes through TakeDamage, and damage rolls happen inside Attack using each object's own MinDamage/MaxDamage

// Phase 2: No new OOP pillars introduced here - focused on save/load functionality (List<GameResult> (a list holding all game results (loaded from file + this run, used to calculate the leaderboard)), file Input/Output to highscores.csv,
// constructor overloading for loading saved dates, and calculating the leaderboard (finding the best run)

// Phase 3: Inheritance, reusing a base class's fields/methods in a subclass instead of rewriting them:
// Here, Troll: Enemy inherits fields (Name, Health, MinDamage, MaxDamage) and methods (TakeDamage, IsAlive Attack) without redefining them
// Also, Polymorphism, the same method behaving differently depending on which class runs it:
// Here, Troll overrides Enemy's virtual Attack method to add its own message before calling base.Attack(target)
// Also, Abstraction, pulling shared structure into one common base class: 
// Here, Combatant is an abstract class holding fields/methods common to Player and Enemy, so they don't duplicate code

// Phase 4: No new OOP pillars introduced here either - focused on the web frontend (plain HTML/JS calling the API via fetch) and showing the leaderboard through a new GET /api/leaderboard endpoint. Done!

// Phase 5 (Last phase!): No new OOP pillars introduced here either - Docker isn't C#/OOP related, it's a separate tool for packaging the app itself. Done!

class Program
{
    static void Main(string[] args)
    {
        // BattleSimulator now handles the fight, saving to csv, and finding the best run
        BattleOutcome outcome = BattleSimulator.RunBattle();
        Console.WriteLine(outcome.Result.WinnerName + " wins!");
        Console.WriteLine($"{outcome.Result.WinnerName} survived {outcome.Result.RoundsSurvived} rounds this run!");
        Console.WriteLine($"Best run: {outcome.BestRun.WinnerName} survived {outcome.BestRun.RoundsSurvived} rounds!");
    }
}
