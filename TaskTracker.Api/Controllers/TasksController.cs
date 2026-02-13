using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() { 
            return Ok("Task API is working");
        }
    }
}
