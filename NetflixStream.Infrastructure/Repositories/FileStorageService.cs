using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetflixStream.Application.DTOs;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;
using NetflixStream.Persistence.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Infrastructure.Repositories
{
    public class FileStorageService : IFileStorageService
    {
        public  string GenerateUniqueFileName(string originalFileName)
        {
            return  $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}_{originalFileName}";
        }

        public Task<string> SaveFile(IFormFile file, string folderName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folderPath , string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) || Path.GetInvalidFileNameChars().Any(c => fileName.Contains(c)))
            {
                throw new ArgumentException("Invalid file name.");
            }

            const long maxFileSize = 10 * 1024 * 1024; // e.g., 10 MB

            var allowedExtensions = new[] { ".mp4", ".avi", ".mov" }; 

            var fileExtension = Path.GetExtension(fileName)?.ToLowerInvariant();

            if (file.Length > maxFileSize)
                throw new ArgumentException("File size exceeds the maximum limit.");

            if (!allowedExtensions.Contains(fileExtension))
                throw new ArgumentException("Invalid file type.");

            Directory.CreateDirectory(folderPath); 

            var filePath = Path.Combine(folderPath, fileName);

            using FileStream stream = new(filePath, FileMode.Create);

            await file.CopyToAsync(stream);

            return fileName;
        }

        public async Task<string> SaveImageFile(IFormFile file, string folderName)
        { 
            if (file == null) return null;

            var uploads = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{folderName}");

            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var fileName = Path.GetFileName(file.FileName);

            var filePath = Path.Combine(uploads, fileName);

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return $"/{folderName}/{fileName}"; // Return the relative path
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving the image file: {ex.Message}");
            }
        }
    }
}
