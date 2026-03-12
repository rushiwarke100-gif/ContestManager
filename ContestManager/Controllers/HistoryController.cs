using ContestManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContestManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : Controller
    {
        private readonly AppDbContext _context;

        public HistoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserHistory(int userId)
        {
            // 1. Verify the user exists
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
            {
                return NotFound("User not found.");
            }
            var userContests = await _context.UserContests
                .Include(uc => uc.Contest)
                .Where(uc => uc.UserId == userId)
                .ToListAsync();

            var completedContests = userContests
                .Where(uc => uc.IsSubmitted)
                .Select(uc => new
                {
                    ContestName = uc.Contest.Name,
                    Score = uc.Score,
                    // Simple prize logic: You can expand this later based on ranking!
                    PrizeWon = uc.Score > 0 ? "Participant Badge" : "No Prize"
                })
                .ToList();
            var inProgressContests = userContests
                .Where(uc => !uc.IsSubmitted)
                .Select(uc => new
                {
                    ContestName = uc.Contest.Name,
                    EndsAt = uc.Contest.EndTime
                })
                .ToList();
            return Ok(new
            {
                UserId = userId,
                TotalCompleted = completedContests.Count,
                CompletedContests = completedContests,
                InProgressContests = inProgressContests
            });
        }
    }
}
