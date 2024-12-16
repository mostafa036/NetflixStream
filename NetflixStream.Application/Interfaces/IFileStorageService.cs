
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.Interfaces
{
    public interface IFileStorageService
    {
        string GenerateUniqueFileName(string originalFileName);
        Task<string> SaveFileAsync(IFormFile file, string folderPath , string fileName);
        Task<string> SaveFile(IFormFile file, string folderName); 
    }
}
