using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;

namespace NetflixStream.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly IVideosRespositores<Genre> _genreRespositores;

        public GenresController(IVideosRespositores<Genre> genreRespositores)
        {
            _genreRespositores = genreRespositores;
        }




    }
}
