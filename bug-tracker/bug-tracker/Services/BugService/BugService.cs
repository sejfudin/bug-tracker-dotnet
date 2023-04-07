
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
        public async Task<ServiceResponse<List<GetBugDto>>> AddBug(AddBugDto newBug)
        {
            var serviceResponse = new ServiceResponse<List<GetBugDto>>();

            try
            {
                var bug = _mapper.Map<Bug>(newBug);
                _context.Bugs.Add(bug);
                await _context.SaveChangesAsync();

                var response = await _context.Bugs.ToListAsync();
                serviceResponse.Data = _mapper.Map<List<GetBugDto>>(response);
                serviceResponse.Message = "Bug successfully created.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBugDto>>> DeleteBug(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetBugDto>>();

            try
            {
                var bug = await _context.Bugs.FirstOrDefaultAsync(c => c.Id == id);
                if (bug is null)
                {
                    throw new Exception($"Bug with Id '{id}' not found.");
                }
                _context.Bugs.Remove(bug);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Bugs.Select(b => _mapper.Map<GetBugDto>(b)).ToListAsync();
                serviceResponse.Message = "Bug successfully deleted.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBugDto>>> GetAllBugs()
        {
            var serviceResponse = new ServiceResponse<List<GetBugDto>>();
            try
            {
                var bugs = await _context.Bugs.ToListAsync();
                serviceResponse.Data = bugs.Select(b => _mapper.Map<GetBugDto>(b)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBugDto>> GetBugById(int id)
        {
            var serviceResponse = new ServiceResponse<GetBugDto>();
            try
            {
                var bug = await _context.Bugs.FirstOrDefaultAsync(b => b.Id == id);

                serviceResponse.Data = _mapper.Map<GetBugDto>(bug);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBugDto>> UpdateBug(UpdateBugDto updatedBug)
        {
            var serviceResponse = new ServiceResponse<GetBugDto>();
            try
            {
                var bug = await _context.Bugs.FirstOrDefaultAsync(b => b.Id == updatedBug.Id);
                if (bug is null)
                {
                    throw new Exception($"Bug with Id '{updatedBug.Id}' not found.");
                }

                bug.Name = updatedBug.Name;
                bug.Steps = updatedBug.Steps;
                bug.Details = updatedBug.Details;
                bug.Version = updatedBug.Version;
                bug.Priority = updatedBug.Priority;
                bug.Time = updatedBug.Time;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetBugDto>(bug);
                serviceResponse.Message = "Bug successfully updated.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
