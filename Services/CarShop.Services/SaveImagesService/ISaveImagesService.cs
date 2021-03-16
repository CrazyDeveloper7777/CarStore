using CarShop.Data.Models.Images;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.SaveImagesService
{
    public interface ISaveImagesService
    {
        public Task SaveImagesAsync(IEnumerable<IFormFile> images);

        public IEnumerable<IFormFile> SanitazeImages(IEnumerable<IFormFile> images);

        public Task DeleteImagesAsync(IEnumerable<Image> images);
    }
}
