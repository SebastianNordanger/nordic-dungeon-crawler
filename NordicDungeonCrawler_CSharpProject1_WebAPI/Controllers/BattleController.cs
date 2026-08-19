using Microsoft.AspNetCore.Mvc;

namespace NordicDungeonCrawler_CSharpProject1_WebAPI.Controllers
{
    // Marks this as a controller that handles web requests, turns on things like auto validation
    [ApiController]
    // Sets the URL - [controller] auto-fills with class name minus "Controller", so this becomes api/battle
    [Route("api/[controller]")]
    public class BattleController : ControllerBase
    {
        // Runs when someone visits api/battle with a GET request (e.g. just opening the URL in a browser)
        [HttpGet]
        public BattleOutcome Get()
        {
            // Reusees the existing battle logic from the econsole project, returned as JSON automatically
            return BattleSimulator.RunBattle();
        }
        // Runs when someone visits api/leaderboard with a GET request, returns full battle history for the leaderboard
        [HttpGet("/api/leaderboard")]
        public ActionResult<List<GameResult>> GetLeaderboard()
        {
            return BattleSimulator.GetHistory();
        }
    }
}
