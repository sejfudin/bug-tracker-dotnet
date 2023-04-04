
namespace bug_tracker.Services.BugService
{
    public interface IBugService
    {
        List<GetBugDto> GetAllBugs();
        GetBugDto GetBugById(int id);

        List<GetBugDto> AddBug(AddBugDto newBug);

    }
}
