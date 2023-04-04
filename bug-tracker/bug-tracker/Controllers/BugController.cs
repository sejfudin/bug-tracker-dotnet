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
        public ActionResult<List<Bug>> Get()
        {
            return Ok(_bugService.GetAllBugs()); 
        }

        [HttpGet("{id}")]
        public ActionResult<Bug> GetSingle(int id)
        {
            return Ok(_bugService.GetBugById(id));
        }

        [HttpPost]
        public ActionResult<List<Bug>> AddBug(Bug newBug)
        {
            return Ok(_bugService.AddBug(newBug));
        }

    }
}
