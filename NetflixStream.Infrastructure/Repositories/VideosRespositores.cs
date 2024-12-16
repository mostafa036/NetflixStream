using Microsoft.EntityFrameworkCore;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;
using NetflixStream.Persistence.Data.Contexts;

namespace NetflixStream.Infrastructure.Repositories
{
    public class VideosRespositores<T> : IVideosRespositores<T> where T : BaseEntity
    {

        private readonly NetflixStreamDbContext _context;

        public VideosRespositores(NetflixStreamDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HandleMovieWatchingAsync(string userEmail, int movieId, TimeSpan? lastWatchedPosition)
        {
            var now = DateTime.UtcNow;

            var movieHistory = await _context.MovieWatchingHistories.FirstOrDefaultAsync(wh => wh.UserEmail == userEmail && wh.MovieID == movieId);

            if (movieHistory == null)
            {
                movieHistory = new MovieWatchingHistory
                {
                    UserEmail = userEmail,
                    MovieID = movieId,
                    StartWatching = now,
                    LastWatchedPosition = lastWatchedPosition,
                    WatchCount = 1
                }; await _context.AddAsync(movieHistory);
            }
            else
            {
                movieHistory.StartWatching = now;
                movieHistory.LastWatchedPosition = lastWatchedPosition;
                movieHistory.WatchCount += 1;

                _context.Update(movieHistory);
            } 
            
            var result = await _context.SaveChangesAsync();

            return result > 0;

        }

        public Task<bool> HandleEpisodeWatchingAsync(string userEmail, int episodeId, TimeSpan? lastWatchedPosition)
        {
            throw new NotImplementedException();
        }

        public async Task<TimeSpan?> GetLastWatchedPositionAsync(string userEmail, int movieId)
        {
            var movieHistory = await _context.MovieWatchingHistories.LastOrDefaultAsync(wh => wh.UserEmail == userEmail && wh.MovieID == movieId);

            return movieHistory?.LastWatchedPosition;
        }
      
        public Task<T> SearchByGenre(string GenreName)
        {
            throw new NotImplementedException();
        }

    }
}