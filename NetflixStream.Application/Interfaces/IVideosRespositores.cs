using NetflixStream.Domain.Entities;
using NetflixStream.Domain.Specifications;

using System.Linq.Expressions;


namespace NetflixStream.Application.Interfaces
{
    public interface IVideosRespositores<T> where T : BaseEntity
    {
        Task<T> SearchByGenre(string GenreName);
        Task<TimeSpan?> GetLastWatchedPositionAsync(string userEmail, int movieId);
        Task<bool> HandleMovieWatchingAsync(string userEmail, int movieId, TimeSpan? lastWatchedPosition);
        Task<bool> HandleEpisodeWatchingAsync(string userEmail, int episodeId, TimeSpan? lastWatchedPosition);
    }
}
