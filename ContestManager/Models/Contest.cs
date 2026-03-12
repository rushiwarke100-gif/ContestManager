namespace ContestManager.Models
{
    public class Contest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessLevel { get; set; } // VIP, Normal
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
