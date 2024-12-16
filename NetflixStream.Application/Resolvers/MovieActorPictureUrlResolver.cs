using AutoMapper;
using Microsoft.Extensions.Configuration;
using NetflixStream.Application.DTOs.Actors;
using NetflixStream.Domain.Entities;

namespace NetflixStream.Application.Resolvers
{
    public class MovieActorPictureUrlResolver : IValueResolver<Actor, MovieActorDto, string>
    {
        public IConfiguration Configuration { get; }
        public MovieActorPictureUrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string Resolve(Actor source, MovieActorDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PhotoPath))
                return $"{Configuration["BaseApiURL"]}{source.PhotoPath}";

            return null;
        }

    }
}
