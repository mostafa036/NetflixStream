using NetflixStream.Application.DTOs.Movies;
using NetflixStream.Application.DTOs.Payments;
using NetflixStream.Application.DTOs.Series;
using NetflixStream.Application.DTOs.Users;


namespace NetflixStream.WebAPIs.Controllers
{
    [Authorize]
    public class FilesController :BaseApiController
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private readonly ILogger<FilesController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _movieFilesBasePath;
        private readonly string _EpisodeFilesBasePath;

        public FilesController(IUnitOfWork unitOfWork, IFileStorageService fileStorageService, IMapper mapper , ILogger<FilesController> logger)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
            _logger = logger;
            _movieFilesBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Movies");
            _EpisodeFilesBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Episode");
        }


        [HttpGet("Get-Movies-Poster/{MovieId}")]
        public async Task<ActionResult<MoviePosterReturnDTO>> GetMoviesPoster(int MovieId)
        {
            var movie = await _unitOfWork.baseRepository<Movies>().GetByIdAsync(MovieId);

            if (movie == null) return NotFound(new ApiResponse(404, "Movie not found."));

            if (string.IsNullOrEmpty(movie.PosterPath))
                return NotFound(new ApiResponse(404, "No poster is associated with this movie."));

            var moviePosterDto = _mapper.Map<MoviePosterReturnDTO>(movie);

            return Ok(moviePosterDto);
        }


        [HttpGet("Get-Episode-Poster/{episodeid}")] 
        public async Task<ActionResult> GetSeriesPoster(int episodeid)
        {
            var episode = await _unitOfWork.baseRepository<Episode>().GetByIdAsync(episodeid);

            if (episode == null) return NotFound(new ApiResponse(404, "Episode not found."));

            if (string.IsNullOrEmpty(episode.FilePath))
                return NotFound(new ApiResponse(404, "No poster is associated with this episode."));

            var episodePosterDto = _mapper.Map<EpisodePosterReturnDTO>(episode);

            return Ok(episodePosterDto);
        }


        [HttpPost("Upload-Movie-Poster")]
        public async Task<ActionResult> UploadOrUpdateMoviePoster([FromForm] UploadFile uploadFiele)
        {
            if (uploadFiele.files == null || uploadFiele.files.Length == 0)
                return BadRequest(new ApiResponse(400, "No file was uploaded."));

            var movie = await _unitOfWork.baseRepository<Movies>().GetByIdAsync(uploadFiele.entityIdId);

            if (movie == null) return NotFound(new ApiResponse(404, "Movie not found."));

            if (!string.IsNullOrEmpty(movie.PosterPath))
            {
                var existingPosterPath = Path.Combine(_movieFilesBasePath, movie.PosterPath);

                if (System.IO.File.Exists(existingPosterPath))
                {
                    System.IO.File.Delete(existingPosterPath);
                }
            }
            var uniqueFileName = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}_{uploadFiele.files.FileName}";

            var posterPath = await _fileStorageService.SaveFileAsync(uploadFiele.files, Path.Combine(_movieFilesBasePath, "Posters"), uniqueFileName);

            movie.PosterName = uploadFiele.files.FileName;

            movie.PosterPath = $"Movies/Posters/{posterPath}";

            await _unitOfWork.baseRepository<Movies>().UpdateAsync(movie);

            await _unitOfWork.Commit();

            var fullPosterUrl = Url.Content($"~/Movies/Posters/{posterPath}");

            return Ok(new { PosterPath = fullPosterUrl });
        }


        [HttpPost("Upload-Episode-Poster")]
        public async Task<ActionResult> UploadSeriesPoster([FromForm] UploadFile uploadFiele)
        {
            if (uploadFiele.files == null || uploadFiele.files.Length == 0)
                return BadRequest(new ApiResponse(400, "No file was uploaded."));

            var Episode = await _unitOfWork.baseRepository<Episode>().GetByIdAsync(uploadFiele.entityIdId);

            if (Episode == null) return NotFound(new ApiResponse(404, "Episode not found."));

            if (!string.IsNullOrEmpty(Episode.FilePath))
            {
                var existingPosterPath = Path.Combine(_EpisodeFilesBasePath, Episode.FilePath);

                if (System.IO.File.Exists(existingPosterPath))
                {
                    System.IO.File.Delete(existingPosterPath);
                }
            }

            var uniqueFileName = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}_{uploadFiele.files.FileName}";

            var posterPath = await _fileStorageService.SaveFileAsync(uploadFiele.files, Path.Combine(_EpisodeFilesBasePath, "Posters"), uniqueFileName);


            Episode.FilePath = $"Episode/Posters/{posterPath}";

            await _unitOfWork.baseRepository<Episode>().UpdateAsync(Episode);

            await _unitOfWork.Commit();

            var episodePosterResolver = _mapper.Map<EpisodePosterReturnDTO>(Episode);

            return Ok();
        }


        [HttpDelete("Delete-Movie-Poster/{movieId}")]
        public async Task<ActionResult> DeleteMoviePoster(int movieId)
        {
            var movie = await _unitOfWork.baseRepository<Movies>().GetByIdAsync(movieId);

            if (movie == null) return NotFound(new ApiResponse(404, "Movie not found."));

            if (!string.IsNullOrEmpty(movie.PosterPath))
            {
                var existingPosterPath = Path.Combine("wwwroot", movie.PosterPath);

                if (System.IO.File.Exists(existingPosterPath))
                {
                    System.IO.File.Delete(existingPosterPath);

                    movie.PosterPath = null;
                    movie.PosterName = null;

                    await _unitOfWork.baseRepository<Movies>().UpdateAsync(movie);
                    await _unitOfWork.Commit();

                    return Ok("Poster deleted successfully.");
                }
                else
                {
                    return NotFound(new ApiResponse(404, "Poster file not found on server."));
                }
            }
            else
            {
                return NotFound(new ApiResponse(404, "No poster is associated with this movie."));
            }
        }


        [HttpPost("Upload-Movie-Trailer")]
        [RequestSizeLimit(10 * 1024 * 1024)] 
        public async Task<ActionResult>UploadMovieTrailer([FromForm] UploadFile uploadFile)
        {
            if (uploadFile.files == null || uploadFile.files.Length == 0)
                return BadRequest(new ApiResponse(400, "No file was uploaded."));

            var timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            var randomFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            var originalFileName = Path.GetFileName(uploadFile.files.FileName);

            var uniqueFileName = $"{timestamp}_{randomFileName}_{originalFileName}";

            try
            {
                var moviestore = await _unitOfWork.baseRepository<Movies>().GetByIdAsync(uploadFile.entityIdId);
                if (moviestore == null) return NotFound(new ApiResponse(404, "Movie not found."));

                var existingTrailer = await _unitOfWork.baseRepository<MovieStore>()
                       .GetFirstOrDefaultAsync(ms => ms.MoviesId == uploadFile.entityIdId && ms.TrailerPath != null);

                if (existingTrailer != null)
                    return BadRequest(new ApiResponse(400, "A trailer for this movie already exists."));


                var trailerFileName = await _fileStorageService.SaveFileAsync(uploadFile.files, Path.Combine(_movieFilesBasePath, "Trailer"), uniqueFileName);
                if (trailerFileName == null) return BadRequest(new ApiResponse(400, "Failed to save the trailer file."));

                var movieTrailer = new MovieStore()
                {
                    MoviesId = moviestore.ID,
                    TrailerPath = $"Movies/Trailer/{trailerFileName}",
                };

                await _unitOfWork.baseRepository<MovieStore>().AddAsync(movieTrailer);
                await _unitOfWork.Commit();

                var movieTrailerDto = _mapper.Map<MovieTrailerReturnDTO>(movieTrailer);

                return Ok(movieTrailerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while uploading the trailer.");

                var savedFilePath = Path.Combine(_movieFilesBasePath, "Trailer", uniqueFileName);

                if (System.IO.File.Exists(savedFilePath))
                {
                    System.IO.File.Delete(savedFilePath);
                }

                return StatusCode(500, new ApiResponse(500, "An error occurred while uploading the trailer."));
            }

        }


    }
}