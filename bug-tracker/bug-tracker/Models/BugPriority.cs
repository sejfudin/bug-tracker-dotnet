using System.Text.Json.Serialization;

namespace bug_tracker.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BugPriority
    {
        Low,
        Medium,
        High
    }
}
