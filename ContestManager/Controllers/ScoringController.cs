using ContestManager.Data;
using ContestManager.Dto_s;
using ContestManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContestManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoringController : Controller
    {
        private readonly AppDbContext _context;

        public ScoringController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitContest([FromBody] SubmitContestDto submission)
        {
           
            var questions = await _context.Questions
                .Include(q => q.Options)
                .Where(q => q.ContestId == submission.ContestId)
                .ToListAsync();

            if (!questions.Any()) return NotFound("Contest or questions not found.");

            int totalScore = 0;
            int pointsPerQuestion = 10;
            foreach (var answer in submission.Answers)
            {
                var dbQuestion = questions.FirstOrDefault(q => q.Id == answer.QuestionId);
                if (dbQuestion == null) continue;

            
                var correctOptionIds = dbQuestion.Options
                    .Where(o => o.IsCorrect)
                    .Select(o => o.Id)
                    .ToList();

           
                bool isCorrect = false;
                if (dbQuestion.Type == "Multi")
                {
                    
                    isCorrect = correctOptionIds.Count == answer.SelectedOptionIds.Count &&
                                correctOptionIds.All(answer.SelectedOptionIds.Contains);
                }
                else
                {
                    
                    isCorrect = answer.SelectedOptionIds.Count == 1 &&
                                correctOptionIds.Contains(answer.SelectedOptionIds.First());
                }
                if (isCorrect)
                {
                    totalScore += pointsPerQuestion;
                }
            }

            
            var userContestRecord = new UserContest
            {
                UserId = submission.UserId,
                ContestId = submission.ContestId,
                Score = totalScore,
                IsSubmitted = true
            };
            _context.UserContests.Add(userContestRecord);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Contest submitted successfully!", Score = totalScore });
        }
    }
}
