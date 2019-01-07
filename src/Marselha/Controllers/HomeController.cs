using Microsoft.AspNetCore.Mvc;

namespace Marselha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new
            {
                Message = "Marselha Api",
                Version = "1.0.0"
            });
        }
    }
}
