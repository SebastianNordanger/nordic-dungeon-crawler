public static class BattleSimulator 
{
    // Fixed path so console app and API share the same CSV file
    // readonly: Value can only be set once, value gets assigned here, and stays fixed
    private static readonly string CsvPath = Path.Combine(
        AppContext.BaseDirectory, "..", "..", "..", "..", "highscores.csv"); 

    // Loads all saved battle results from the CSV file
    private static List<GameResult> LoadHistory()
    {
        // Save game results to a list
        List<GameResult> history = new List<GameResult>();

        // Condition to check if highscore file exists
        if (File.Exists(CsvPath))
        {
            string[] lines = File.ReadAllLines(CsvPath);

            // Loop by splting the lines and saving the winner and amountt of rounds
            foreach (string line in lines)
            {
                // Avoid error related to blank lines in csv file
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                
                // Splits one CSV line into its values and rebuilds a GameResult from them, then adds it to history
                string[] parts = line.Split(',');
                string savedWinner = parts[0];
                int savedRounds = int.Parse(parts[1]);
                // ParseExact with fixed format + InvariantCulture, so date parsing doesn't depend on the computer's regional settings (this broke in Docker, since the container's default settings read data differently than the dev PC)
                DateTime savedDate = DateTime.ParseExact(parts[2], "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                GameResult savedResult = new GameResult(savedWinner, savedRounds, savedDate);
                history.Add(savedResult);
            }
        }
        return history;

    }

    // Returns the full battle history as JSON for the leaderboard endpoint in BattleController in the WebAPI
    public static List<GameResult> GetHistory()
    {
        return LoadHistory();
    }

    public static BattleOutcome RunBattle()
    {
        // Create a new character for players and enemies with battle logic
        // Shows: Name, Health, Minimal damage, and Maximal damage
        Player hero = new Player("Loki", 100, 20, 30);
        Troll troll = new Troll("Tuss", 100, 20, 30);

        // Keep track of the rounds of battle
        int rounds = 0;

        // Attack loop
        while (hero.IsAlive() && troll.IsAlive())
        {
            rounds += 1;
            hero.Attack(troll);
            if (troll.Health > 0)
            {
                troll.Attack(hero);
            }
        }

        // Condition check of who won
        string winnerName;
        if (hero.Health > 0)
        {
            winnerName = hero.Name;
        }
        else
        {
            winnerName = troll.Name;
        }

        GameResult result = new GameResult(winnerName, rounds);

        List<GameResult> history = LoadHistory();
        history.Add(result);
        // Save it in CSV format
        File.AppendAllText(CsvPath, $"{result.WinnerName},{result.RoundsSurvived},{result.FormattedDate}\n");

        // Loop to get the best result (highest number of rounds survived)
        GameResult bestRound = history[0];
        foreach (GameResult entry in history)
        {
            // Condition check of highest round achieved
            if (entry.RoundsSurvived > bestRound.RoundsSurvived)
            {
                bestRound = entry;
            }
        }
        // Packages this battle's result together with the current bst run, so both come back in one piece
            return new BattleOutcome
            {
                Result = result,
                BestRun = bestRound
            };
        }
}
