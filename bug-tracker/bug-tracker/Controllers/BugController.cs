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
        public async Task<ActionResult<ServiceResponse<List<GetBugDto>>>> Get()
        {
            return Ok(await _bugService.GetAllBugs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBugDto>>> GetSingle(int id)
        {
            return Ok(await _bugService.GetBugById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetBugDto>>>> AddBug([FromBody] AddBugDto newBug)
        {
            return Ok(await _bugService.AddBug(newBug));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetBugDto>>> UpdateBug(UpdateBugDto updatedBug)
        {
            var response = await _bugService.UpdateBug(updatedBug);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetBugDto>>> DeleteBug(int id)
        {
            var response = await _bugService.DeleteBug(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
