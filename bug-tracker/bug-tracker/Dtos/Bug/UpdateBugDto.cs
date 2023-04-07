namespace bug_tracker.Dtos.Bug
{
    public class UpdateBugDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Steps { get; set; }
        public BugPriority Priority { get; set; }
        public string Version { get; set; }
        public string Time { get; set; }
    }
}
