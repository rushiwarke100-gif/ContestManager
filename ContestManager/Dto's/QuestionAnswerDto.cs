namespace ContestManager.Dto_s
{
    public class QuestionAnswerDto
    {
        public int QuestionId { get; set; }
       
        public List<int> SelectedOptionIds { get; set; } = new();
    }
}
