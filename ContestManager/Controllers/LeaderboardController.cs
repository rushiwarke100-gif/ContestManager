using ContestManager.Data;
using ContestManager.Dto_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContestManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : Controller
    {
        private readonly AppDbContext _context;

        public LeaderboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{contestId}")]
        public async Task<IActionResult> GetLeaderboard(int contestId)
        {
            
            var contestExists = await _context.Contests.AnyAsync(c => c.Id == contestId);
            if (!contestExists)
            {
                return NotFound("Contest not found.");
            }
            var submissions = await _context.UserContests
                .Include(uc => uc.User) 
                .Where(uc => uc.ContestId == contestId && uc.IsSubmitted)
                .OrderByDescending(uc => uc.Score)
                .ToListAsync();

            if (!submissions.Any())
            {
                return Ok(new { Message = "No submissions yet for this contest.", Leaderboard = new List<LeaderboardEntryDto>() });
            }
            var leaderboard = new List<LeaderboardEntryDto>();
            int currentRank = 1;

            for (int i = 0; i < submissions.Count; i++)
            {
                
                if (i > 0 && submissions[i].Score < submissions[i - 1].Score)
                {
                    currentRank = i + 1;
                }

                leaderboard.Add(new LeaderboardEntryDto
                {
                    Rank = currentRank,
                    Username = submissions[i].User.Username,
                    Score = submissions[i].Score
                });
            }

            return Ok(leaderboard);
        }
    }

}
