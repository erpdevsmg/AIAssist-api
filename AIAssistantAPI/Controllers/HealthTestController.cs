using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIAssistantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthTestController : ControllerBase
    {
        [HttpGet]
        [Route("HealthCheck")]
        public IActionResult HealthCheck()
        {
            var dtfrom = DateTime.Now;
           
            // This endpoint is used to check the health of the API
            return Ok(new { status = "Welcome to AI API V.0.0.1" });
        }
    }
}
