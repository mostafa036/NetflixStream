
namespace NetflixStream.WebAPIs.Controllers
{
    public class DownloadsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _movieFilePath;
        private readonly string _episodeFilePath;

        public DownloadsController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _movieFilePath = Path.Combine("wwwroot", "movies");
            _episodeFilePath = Path.Combine("wwwroot", "episodes");
        }



        //[Authorize(Roles = "Basic, Standard, Premium")]
        //[HttpPost("Download-Item/{id}")]
        //public async Task<ActionResult> DownloadItem(int id)
        //{


        //}


        //[HttpGet("download/{movieId}")]
        //public IActionResult DownloadEncryptedFile(int movieId)
        //{
        //    string filePath = Path.Combine(_videosFolderPath, $"movie_{movieId}.mp4");

        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        return NotFound("File not found.");
        //    }

        //    byte[] encryptedFile = EncryptFile(filePath);

        //    تحميل الملف المشفر
        //    return File(encryptedFile, "application/octet-stream", $"movie_{movieId}_encrypted.mp4");
        //}


















        //    if (downloadResult == null)
        //        return NotFound();

        //    var filePath = Path.Combine(_baseFilePath, downloadResult.FileName);
        //    if (!System.IO.File.Exists(filePath))
        //        return NotFound();

        //    var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
        //    return File(fileBytes, "application/octet-stream", downloadResult.FileName);
        //}


















        //[Authorize(Roles = "Basic, Standard, Premium")]
        //[HttpGet("Get-Available-Downloads")]
        //public async Task<ActionResult<IEnumerable<DownloadableItemDTO>>> GetAvailableDownloads()
        //{
        //    var items = await _unitOfWork.DownloadRepository.GetAvailableDownloadsAsync(UserId);
        //    return Ok(items);
        //}


























        //[Authorize(Roles = "Basic, Standard, Premium")]
        //[HttpDelete("Delete-Download/{id}")]
        //public async Task<ActionResult> DeleteDownload(int id)
        //{
        //    var result = await _unitOfWork.DownloadRepository.DeleteDownloadAsync(id, UserId);
        //    if (!result)
        //        return NotFound();

        //    return NoContent();
        //}

        //[Authorize(Roles = "Basic, Standard, Premium")]
        //[HttpGet("my")]
        //public async Task<ActionResult<IEnumerable<DownloadedItemDTO>>> GetDownloadedItems()
        //{
        //    var downloads = await _unitOfWork.DownloadRepository.GetUserDownloadsAsync(UserId);
        //    return Ok(downloads);
        //}
        //[Authorize(Roles = "Standard, Premium, Admin")]
        //[HttpGet("limits")]
        //public async Task<ActionResult<DownloadLimitDTO>> CheckDownloadLimits()
        //{
        //    var limits = await _unitOfWork.DownloadRepository.GetDownloadLimitsAsync(UserId);
        //    return Ok(limits);
        //}

        //// 6. Check Download Status (Admin only)
        //[Authorize(Roles = "Admin")]
        //[HttpGet("status/{id}")]
        //public async Task<ActionResult<DownloadStatusDTO>> GetDownloadStatus(int id)
        //{
        //    var status = await _unitOfWork.DownloadRepository.GetDownloadStatusAsync(id, UserId);
        //    return Ok(status);
        //}

    }
}
