using AutoMapper;
using Microsoft.Extensions.Configuration;
using NetflixStream.Application.DTOs.Movies;
using NetflixStream.Domain.Entities;

namespace NetflixStream.Application.Resolvers
{
    public class PosterUrlResolver : IValueResolver<Movies, MoviePosterReturnDTO, string>
    {
        public IConfiguration Configuration { get; }
        public PosterUrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string Resolve(Movies source, MoviePosterReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PosterPath))
                return $"{Configuration["BaseApiURL"]}{source.PosterPath}";

            return null;
        }
    }
}
