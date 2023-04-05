using Microsoft.AspNetCore.Mvc;

namespace bug_tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugController : ControllerBase
    {
        private readonly IBugService _bugService;

        public BugController(IBugService bugService)
        {
            _bugService = bugService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetBugDto>>> Get()
        {
            return Ok(await _bugService.GetAllBugs()); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBugDto>> GetSingle(int id)
        {
            return Ok(await _bugService.GetBugById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<GetBugDto>>> AddBug(AddBugDto newBug)
        {
            return Ok(await _bugService.AddBug(newBug));
        }

        [HttpPut]
        public async Task<ActionResult<GetBugDto>> UpdateBug(UpdateBugDto updatedBug)
        {
            return Ok(await _bugService.UpdateBug(updatedBug));
        }

        [HttpDelete]
        public async Task<ActionResult<GetBugDto>> DeleteBug(int id)
        {
            return Ok(await _bugService.DeleteBug(id));
        }

    }
}
