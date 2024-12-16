using AutoMapper;
using Microsoft.Extensions.Configuration;
using NetflixStream.Application.DTOs.Series;
using NetflixStream.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.Resolvers
{
    public class EpisodePosterResolver : IValueResolver<Episode, EpisodePosterReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public EpisodePosterResolver(IConfiguration configuration )
        {
            _configuration = configuration;
        }

        public string Resolve(Episode source, EpisodePosterReturnDTO destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.FilePath))
                return $"{_configuration["BaseApiURL"]}{source.FilePath}";

            return null;
        }
    }
}
