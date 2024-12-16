using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetflixStream.Persistence.Data.Contexts;
using NetflixStream.Persistence.Errors;

namespace NetflixStream.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly NetflixStreamDbContext _context;

        public BuggyController(NetflixStreamDbContext context)
        {
            _context = context;
        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _context.Movies.Find(1000);

            if (product == null) return NotFound(new ApiResponse(404));

            return Ok(product);
        }


        [HttpGet("servererror")]
        public ActionResult GetServererror()
        {
            var product = _context.Movies.Find(1000);

            var production = product.ToString();

            return Ok (production);
        }

        [HttpGet("badrequest")]
        public ActionResult Getbadrequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult Getbadrequest(int id)
        {
            return Ok();
        }



    }
}
