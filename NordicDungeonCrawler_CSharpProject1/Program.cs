// Starts the console version - runs one battle and prints the results
class Program
{
    static void Main(string[] args)
    {
        // BattleSimulator now handles the fight, saving to csv, and finding the best run
        BattleOutcome outcome = BattleSimulator.RunBattle();

        Console.WriteLine();  // Blank line to separate the combat log from the results summary
        Console.WriteLine(outcome.Result.WinnerName + " wins!");
        Console.WriteLine($"{outcome.Result.WinnerName} survived {outcome.Result.RoundsSurvived} rounds this run!");
        Console.WriteLine($"Best run: {outcome.BestRun.WinnerName} survived {outcome.BestRun.RoundsSurvived} rounds!");
    }
}
