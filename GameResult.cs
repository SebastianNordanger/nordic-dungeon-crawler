using System.Text.Json.Serialization;

public class GameResult
{
    // Changed fields to properties - get returns the value, set assigns it, needed so the Web API can convert them to JSON
    public string WinnerName { get; set; }
    public int RoundsSurvived { get; set; }
    [JsonIgnore]  // Used to not display the raw Date
    public DateTime Date { get; set; }
    // Date formatted to European-style, used for display (CSV output, while also JSON)
    public string FormattedDate => Date.ToString("dd.MM.yyyy HH:mm");  // Short way (=>) to write a get-only property, just returns this one expression


    // Constructor for the result of the game
    public GameResult(string winnerName, int roundsSurvived)
    {
        WinnerName = winnerName;
        RoundsSurvived = roundsSurvived;
        Date = DateTime.Now;
    }

    // Overload constructor (same class but different parameters)
    public GameResult(string winnerName, int roundsSurvived, DateTime date)
    {
        WinnerName = winnerName;
        RoundsSurvived = roundsSurvived;
        Date = date;
    }
}
