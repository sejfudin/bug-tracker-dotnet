namespace bug_tracker.Dtos.Bug
{
    public class GetBugDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Steps { get; set; } = string.Empty;
        public BugPriority Priority { get; set; }
        public string Version { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
    }
}
