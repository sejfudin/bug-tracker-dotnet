
namespace bug_tracker.Services.BugService
{
    public interface IBugService
    {
        Task<ServiceResponse<List<GetBugDto>>> GetAllBugs();
        Task<ServiceResponse<GetBugDto>> GetBugById(int id);
        Task<ServiceResponse<List<GetBugDto>>> AddBug(AddBugDto newBug);
        Task<ServiceResponse<GetBugDto>> UpdateBug(UpdateBugDto updatedBug);
        Task<ServiceResponse<List<GetBugDto>>> DeleteBug(int id);

    }
}
