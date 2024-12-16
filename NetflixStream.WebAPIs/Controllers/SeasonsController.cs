using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetflixStream.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> get()
        {
            return null;
        }
    }
}
