
namespace bug_tracker.Services.BugService
{
    public interface IBugService
    {
        Task<List<GetBugDto>> GetAllBugs();
        Task<GetBugDto> GetBugById(int id);

        Task<List<GetBugDto>> AddBug(AddBugDto newBug);

    }
}
