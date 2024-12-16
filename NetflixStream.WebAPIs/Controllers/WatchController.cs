using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace NetflixStream.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _movieFilesBasePath;
        private readonly string _episodeFilesBasePath;

        public WatchController(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
            _movieFilesBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Movies", "Files");
            _episodeFilesBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Episode", "Files");
        }

        [Authorize]
        [HttpGet("WatchMovie/{Id}")]
        [Produces("application/octet-stream")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> WatchMovie(int Id)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized(new ApiResponse(401, "User not authenticated"));

            var movie = await _unitOfWork.baseRepository<MovieStore>().GetByIdAsync(Id);
            if (movie == null) return NotFound(new ApiResponse(404, "Not Found Movie"));

            var filePath = Path.Combine(_movieFilesBasePath, "File", movie.FilePath);

            if (!System.IO.File.Exists(filePath))
                return NotFound(new ApiResponse(404, "File not found"));

            await using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var contentType = GetContentTypeServices.GetContentType(movie.FilePath) ?? "application/octet-stream";

            var lastWatchedPositionforuserbefore = await _unitOfWork.VideosRespositores<MovieWatchingHistory>().GetLastWatchedPositionAsync(userEmail , movie.ID);

            var result = await _unitOfWork.VideosRespositores<MovieWatchingHistory>().HandleMovieWatchingAsync(userEmail, movie.ID ,null);

            return File(stream, contentType, enableRangeProcessing: true);
        }

        [HttpGet("WatchEpisod/{EpisodId}")]
        [Produces("application/octet-stream")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> WatchEpisod(int EpisodId)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized(new ApiResponse(401, "User not authenticated"));

            var Episod = await _unitOfWork.baseRepository<EpisodStore>().GetByIdAsync(EpisodId);

            if (Episod == null)
                return NotFound(new ApiResponse(404, "Not Found Episod"));

            var filePath = Path.Combine(_episodeFilesBasePath, "File", Episod.FilePath);

            if (!System.IO.File.Exists(filePath))
                return NotFound(new ApiResponse(404, "File not found"));

            await using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var contentType = GetContentTypeServices.GetContentType(Episod.FilePath) ?? "application/octet-stream";

            var lastWatchedPositionforuserbefore = await _unitOfWork.VideosRespositores<MovieWatchingHistory>().GetLastWatchedPositionAsync(userEmail, Episod.ID);

            var result = await _unitOfWork.VideosRespositores<MovieWatchingHistory>().HandleMovieWatchingAsync(userEmail, Episod.ID, null);

            return File(stream, contentType, enableRangeProcessing: true);
        }













    }
}
