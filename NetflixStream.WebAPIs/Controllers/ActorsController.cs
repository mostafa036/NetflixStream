using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;

namespace NetflixStream.WebAPIs.Controllers
{
    public class ActorsController : BaseApiController
    {
        private readonly IVideosRespositores<Actor> _actorrespositores;

        public ActorsController(IVideosRespositores<Actor> actorrespositores)
        {
            _actorrespositores = actorrespositores;
        }


    }
}
