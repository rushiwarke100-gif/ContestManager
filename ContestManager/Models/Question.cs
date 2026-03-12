namespace ContestManager.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int ContestId { get; set; }
        public string Text { get; set; }
      
        public string Type { get; set; }
        public List<Option> Options { get; set; } = new();
    }
}
