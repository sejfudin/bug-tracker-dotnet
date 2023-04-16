namespace bug_tracker.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Steps { get; set; }
        public BugPriority Priority { get; set; }
        public string Version { get; set; }
        public string Time { get; set; }
        public User? User { get; set; }

    }
}
