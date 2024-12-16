using NetflixStream.Application.DTOs.Movies;
using NetflixStream.Application.Filters;

namespace NetflixStream.WebAPIs.Controllers
{
    public class MoviesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MovieService _movieService;
        private readonly IMapper _mapper;
       
        public MoviesController(IUnitOfWork unitOfWork, MovieService movieService,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _movieService = movieService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("Cards")]
        public async Task<ActionResult<Pagination<MovieCardDTO>>> GetAllMovies([FromQuery] MovieFilterParams filterParams)
        {
            var spec = new MovieWithGenre(filterParams);

            var result = await _unitOfWork.specificationRepository<Movies>().GetAllWithSpecAsync(spec);

            var mappedResult = _mapper.Map<IReadOnlyList<MovieCardDTO>>(result);

            var CountSpec = new MoviesWithFiltersForCountSpecification(filterParams);

            var Count = await _unitOfWork.specificationRepository<Movies>().GetCountAsync(CountSpec);

            return Ok(new Pagination<MovieCardDTO>(filterParams.PageIndex, filterParams.PageSize, Count, mappedResult));
        }


        [Authorize]
        [HttpGet("GetMoviesById/{id}")]
        public async Task<ActionResult<MovieCardDTO>> GetMovie(int id)
        {
            var spec = new MovieWithGenre(id);

            var result = await _unitOfWork.specificationRepository<Movies>().GetEntityWithSpecAsync(spec);

            if (result == null) return NotFound(new ApiResponse(404));

            var mappedResult = _mapper.Map<MovieCardDTO>(result);

            return Ok(mappedResult);
        }


        [Authorize]
        [HttpGet("DetailsFull/{id}")]
        public async Task<ActionResult<MovieReturnFullDetails>> MovieDescription(int id)
        {
            var spec = new MovieFullDetails(id);

            var MovieFullDetails = await _unitOfWork.specificationRepository<Movies>().GetEntityWithSpecAsync(spec);

            if (MovieFullDetails == null) return NotFound(new ApiResponse(404));

            var mapMovieFullDetails = _mapper.Map<MovieReturnFullDetails>(MovieFullDetails);

            return Ok(mapMovieFullDetails);
        }


        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost("AddMovieDetails")]
        [ProducesResponseType(200) ]
        public async Task<ActionResult<string>> CreateMovie([FromBody] MovieCreateDTO movieDto)
        {
            if (movieDto == null) return BadRequest(new ApiResponse(400, "Invalid movie data."));

            var movie = _movieService.CreateMovieEntity(movieDto);

            await _unitOfWork.baseRepository<Movies>().AddAsync(movie);

            return Ok("Movie successfully added.");
        }

        [Authorize]
        [HttpDelete("DeleteMovie/{Id}")]
        public async Task<ActionResult<bool>> DelereMovie(int ID)
        {
            if (ID <= 0) return BadRequest(new ApiResponse(400, "Invalid movie ID"));

            var result = await _unitOfWork.baseRepository<Movies>().DeleteAsync(ID);

            if (!result) return NotFound(new ApiResponse(404));

            return Ok(result); 
        }


        [ValidateAntiForgeryToken]
        [HttpPut("UpdateMovie/{id}")]
        public async Task<ActionResult<bool>> UpdateMovie(int id, [FromBody] MovieCreateDTO movieDto)
        {
            var existingMovie = await _unitOfWork.baseRepository<Movies>().GetByIdAsync(id);

            if (existingMovie == null) return NotFound(new ApiResponse(404, "Moive Not Found"));

            var isUpdated = await _movieService.UpdateMovieAsync(existingMovie.ID, movieDto);

            if (isUpdated == false ) return NotFound(new ApiResponse(404, "Failed to update the movie"));

            return Ok(isUpdated);
        }


        [HttpGet("cast/{id}")]
        public async Task<ActionResult<MovieCastReturnDto>> GetMovieCast( int id)
        {
            var spec = new MovieWithCastSpecification(id);

            var MovieCastDetails = await _unitOfWork.specificationRepository<Movies>().GetEntityWithSpecAsync(spec);

            if (MovieCastDetails == null) return NotFound(new ApiResponse(404 , " "));

            var mapMovieFullDetails = _mapper.Map<MovieCastReturnDto>(MovieCastDetails);

            return Ok(mapMovieFullDetails);

        }

        //[HttpGet("trending")]
        //public async Task<ActionResult<Pagination<MovieCardDTO>> GetTrendingMovies([FromQuery] MovieFilterParams filterParams)
        //{
        //    var spec = new MovieWithGenre(filterParams);

        //    var result = await _unitOfWork.Respositores<Movies>().GetAllWithSpecAsync(spec);

        //    return Ok();
        //}












        //[HttpGet("top-rated")]
        //public async Task<ActionResult<Pagination<MovieCardDTO>> GetTopRatedMovies()
        //{
        //    // Implementation here
        //    return Ok();
        //}



    }
}
