using AutoMapper;
using Microsoft.Extensions.Configuration;
using NetflixStream.Application.DTOs.Payments;
using NetflixStream.Domain.Entities;


namespace NetflixStream.Application.Resolvers
{
    public class UrlResolver : IValueResolver<MovieStore, MovieTrailerReturnDTO, string>
    {
        public IConfiguration Configuration { get; }
        public UrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Resolve(MovieStore source, MovieTrailerReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.TrailerPath))
                return $"{Configuration["BaseApiURL"]}{source.TrailerPath}";

            return null;
        }

    }
}

