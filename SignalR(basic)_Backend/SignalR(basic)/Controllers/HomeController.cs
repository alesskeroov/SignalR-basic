using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_basic_.Business;

namespace SignalR_basic_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyBusiness _business;
        public HomeController(MyBusiness business)
        {
            _business = business;
        }
        [HttpGet("{Message}")]
        public async Task<ActionResult> Index(string message)
        {
            await _business.Message(message);
            return Ok();
        }
    }
}
