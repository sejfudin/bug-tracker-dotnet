namespace bug_tracker.Services.BugService
{
    public interface IBugService
    {
        List<Bug> GetAllBugs();
        Bug GetBugById(int id);

        List<Bug> AddBug(Bug newBug);

    }
}
