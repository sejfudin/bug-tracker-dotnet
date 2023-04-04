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
        public ActionResult<List<GetBugDto>> Get()
        {
            return Ok(_bugService.GetAllBugs()); 
        }

        [HttpGet("{id}")]
        public ActionResult<GetBugDto> GetSingle(int id)
        {
            return Ok(_bugService.GetBugById(id));
        }

        [HttpPost]
        public ActionResult<List<GetBugDto>> AddBug(AddBugDto newBug)
        {
            return Ok(_bugService.AddBug(newBug));
        }

    }
}
