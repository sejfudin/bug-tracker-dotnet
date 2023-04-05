﻿namespace bug_tracker.Dtos.Bug
{
    public class UpdateBugDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Steps { get; set; }
        public BugVersion Version { get; set; }
        public string Priority { get; set; }
        public string Time { get; set; }
    }
}