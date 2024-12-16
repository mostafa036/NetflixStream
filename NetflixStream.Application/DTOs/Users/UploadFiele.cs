using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Users
{

    public class UploadFile
    {
        public IFormFile files { get; set; } = null!;

        public int entityIdId { get; set; } // Optional: Use if you want to associate the file with a movie
    }

}

