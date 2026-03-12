namespace ContestManager.Dto_s
{
    public class SubmitContestDto
    {
        public int UserId { get; set; }
        public int ContestId { get; set; }
        public List<QuestionAnswerDto> Answers { get; set; } = new();
    }
}
