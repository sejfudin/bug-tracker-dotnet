
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

        public async Task<List<GetBugDto>> DeleteBug(int id)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(c => c.Id == id);
            if(bug is null)
            {
                throw new Exception($"Bug with Id '{id}' not found.");
            }
            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();

            var response= await _context.Bugs.Select(b=>_mapper.Map<GetBugDto>(b)).ToListAsync();
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

        public async Task<GetBugDto> UpdateBug(UpdateBugDto updatedBug)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(b => b.Id == updatedBug.Id);

            bug.Name = updatedBug.Name;
            bug.Steps = updatedBug.Steps;
            bug.Details = updatedBug.Details;
            bug.Version = updatedBug.Version;
            bug.Priority = updatedBug.Priority;
            bug.Time = updatedBug.Time;

            await _context.SaveChangesAsync();

            var response = _mapper.Map<GetBugDto>(bug);
            return response;
        }
    }
}
