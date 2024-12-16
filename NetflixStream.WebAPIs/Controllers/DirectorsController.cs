using Microsoft.EntityFrameworkCore;
using NetflixStream.Application.DTOs.Directors;
using NetflixStream.Application.Filters;

namespace NetflixStream.WebAPIs.Controllers
{
    [Authorize]
    public class DirectorsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DirectorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost("AddDirector")]
        public async Task<ActionResult> AddDirector(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new ApiResponse(400, "Director name cannot be empty."));

            var director = new Director { Name = name };

            var addedDirector = await _unitOfWork.baseRepository<Director>().AddAsync(director);

            await _unitOfWork.Commit();

            return Ok(new ApiResponse(200, "Director added successfully."));
        }


        [HttpDelete("DeleteDirector/{id}")]
        public async Task<ActionResult<bool>> DeleteDirector(int id)
        {
            if (id <= 0) return BadRequest(new ApiResponse(400, "Invalid movie ID"));

            var result = await _unitOfWork.baseRepository<Director>().DeleteAsync(id);

            if (!result) return NotFound(new ApiResponse(404, "Director not found"));

            return Ok(new ApiResponse(200, "Director deleted successfully"));
        }


        [HttpPost("AddDirectorToMovie")]
        public async Task<ActionResult> AddDirectorToMovie([FromBody] assignedDirectorToherWork dto)
        {

            var movie = await _unitOfWork.baseRepository<Movies>().Include(s => s.Directors)
                                        .FirstOrDefaultAsync(s => s.ID == dto.EntityID);

            if (movie == null)
                return NotFound(new ApiResponse(404, "Movie with ID {dto.MovieId} not found."));

            var director = await _unitOfWork.baseRepository<Director>().GetByIdAsync(dto.DirectorsID);

            if (director == null)
                return NotFound($"Director with ID {dto.DirectorsID} not found.");

            if (movie.Directors.Any(d => d.ID == dto.DirectorsID))
                return BadRequest(new ApiResponse(400, "Director is already assigned to this movie."));

            movie.Directors.Add(director);

            await _unitOfWork.Commit();

            return Ok(new ApiResponse(200, "Director added to movie successfully."));
        }


        [HttpPost("AddDirectorToSeries")]
        public async Task<ActionResult> AddDirectorToSeries([FromBody] assignedDirectorToherWork dto)
        {

            var series = await _unitOfWork.baseRepository<Series>().Include(s => s.Directors)
                                        .FirstOrDefaultAsync(s => s.ID == dto.EntityID);
            if (series == null)
                return NotFound(new ApiResponse(404, "Series not found."));

            var director = await _unitOfWork.baseRepository<Director>().GetByIdAsync(dto.DirectorsID);

            if (director == null) 
                return NotFound(new ApiResponse (404,"Director not found."));

            var cheack = series.Directors.Any(d => d.ID == director.ID);

            if (series.Directors.Any(d => d.ID == dto.DirectorsID))
                return BadRequest(new ApiResponse(400, "Director is already assigned to this series."));

            series.Directors.Add(director);

            await _unitOfWork.Commit();

            return Ok("Director added to series successfully.");
        }


        [HttpGet("GetDirector")]
        public async Task<ActionResult<Pagination<DirectorDto>>> GetAllDirectors([FromQuery] DirectorFilterParams directorFilter)
        {
            var spec = new DirectorWithMoviesAndSeriesSpecification(directorFilter);

            var directors = await _unitOfWork.specificationRepository<Director>().GetAllWithSpecAsync(spec);

            var mappedResult = _mapper.Map<IReadOnlyList<DirectorDto>>(directors);

            var CountSpec = new DirectorWithMoviesFiltersForCountSpecification(directorFilter);

            var Count = await _unitOfWork.specificationRepository<Director>().GetCountAsync(CountSpec);

            if (directors == null || !directors.Any())
                return NotFound(new ApiResponse(404, "No directors found."));

            return Ok(new Pagination<DirectorDto>(directorFilter.PageIndex, directorFilter.PageSize, Count, mappedResult));
        }


        [HttpGet("GetDirector/{id}")]
        public async Task<ActionResult<DirectorDto>> GetDirectorById(int id)
        {
            var spec = new DirectorWithMoviesAndSeriesSpecification(id);

            var director = await _unitOfWork.specificationRepository<Director>().GetEntityWithSpecAsync(spec);

            if (director == null) return NotFound(new ApiResponse(404, "No directors found."));

            var mappedResult = _mapper.Map<DirectorDto>(director);

            return Ok(mappedResult);
        }


        [HttpPut("UpdateDirectorDetails")]
        public async Task<ActionResult> UpdateDirector(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new ApiResponse(400, "Director name cannot be empty."));

            var director = await _unitOfWork.baseRepository<Director>().GetByIdAsync(id);

            if (director == null)
                return NotFound(new ApiResponse(404, "Director not found."));

            director.Name = name;

            await _unitOfWork.Commit();

            return Ok(director);
        }


        [HttpPut("UpdateDirectorForMovieOrSeries")]
        public async Task<ActionResult> UpdateDirectorForMovie([FromBody] UpdateDirectorForMovieDto dto)
        {
            var movie = await _unitOfWork.baseRepository<Movies>().GetByIdAsync(dto.MovieId);

            if (movie == null)
                return NotFound(new ApiResponse(404, $"Movie with ID {dto.MovieId} not found."));

            var director = await _unitOfWork.baseRepository<Director>().GetByIdAsync(dto.DirectorId);

            if (director == null)
                return NotFound(new ApiResponse(404, $"Director with ID {dto.DirectorId} not found."));

            if (!movie.Directors.Any(d => d.ID == dto.DirectorId))
                return BadRequest(new ApiResponse(400, "Director is not assigned to this movie."));

            movie.Directors.Remove(movie.Directors.First(d => d.ID == dto.DirectorId));

            await _unitOfWork.Commit();

            return Ok(new ApiResponse(200, "Director updated for movie successfully."));
        }

    }
}
