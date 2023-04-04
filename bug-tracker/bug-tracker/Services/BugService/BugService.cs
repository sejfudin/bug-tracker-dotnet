
namespace bug_tracker.Services.BugService
{
    public class BugService : IBugService
    {
        private readonly IMapper _mapper;
        public BugService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<GetBugDto> AddBug(AddBugDto newBug)
        {
            return null;
        }

        public List<GetBugDto> GetAllBugs()
        {
            return null;
        }

        public GetBugDto GetBugById(int id)
        {
            return null;
        }
    }
}
