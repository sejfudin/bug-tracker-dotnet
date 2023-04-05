namespace bug_tracker.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Steps { get; set; } = string.Empty;
        public BugVersion Version { get; set; } = BugVersion.Low;
        public string Priority { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;

    }
}
