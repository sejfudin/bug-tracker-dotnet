
namespace bug_tracker.Services.BugService
{
    public class BugService : IBugService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public BugService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetBugDto>> AddBug(AddBugDto newBug)
        {
            var bug = _mapper.Map<Bug>(newBug);
            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();

            var response = await _context.Bugs.Select(b => _mapper.Map<GetBugDto>(b)).ToListAsync();
            return response;
        }

        public async Task<List<GetBugDto>> GetAllBugs()
        {
            var bugs = await _context.Bugs.ToListAsync();
            var response = bugs.Select(b => _mapper.Map<GetBugDto>(b)).ToList();
            return response;
        }

        public async Task<GetBugDto> GetBugById(int id)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(b => b.Id == id);
            
                var response = _mapper.Map<GetBugDto>(bug);
                return response;
        }
    }
}
