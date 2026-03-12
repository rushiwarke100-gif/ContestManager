using ContestManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContestManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContestsController : Controller
    {
        private readonly AppDbContext _context;

        public ContestsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetContests(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return NotFound("User not found");

            if (user.Role == "VIP" || user.Role == "Admin")
            {
             
                return Ok(await _context.Contests.ToListAsync());
            }
            else if (user.Role == "Normal")
            {
               
                return Ok(await _context.Contests.Where(c => c.AccessLevel == "Normal").ToListAsync());
            }

            return Unauthorized("Guest users cannot view contests. Please sign up.");
        }
    }
}
