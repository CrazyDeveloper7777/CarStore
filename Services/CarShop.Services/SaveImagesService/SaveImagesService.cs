﻿using CarShop.Data.Models.Images;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.SaveImagesService
{
    public class SaveImagesService : ISaveImagesService
    {
        private static ICollection<string> allowedTypes = new HashSet<string> { ".jpeg", ".jpg", ".png", ".svg", ".gif" };
        private static string pathToDirectory;
        private readonly IWebHostEnvironment env;

        public SaveImagesService(IWebHostEnvironment env)
        {
            this.env = env;

            pathToDirectory = env.ContentRootPath + @"\wwwroot\images";
            if (!Directory.Exists(pathToDirectory))
            {
                Directory.CreateDirectory(pathToDirectory);
            }
        }

        public async Task SaveImagesAsync(IEnumerable<IFormFile> images)
        {
            foreach (var image in images)
            {
                var pathToFile = Path.Combine(pathToDirectory, image.FileName);
                using (Stream fileStream = new FileStream(pathToFile, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
        }

        public Task DeleteImagesAsync(IEnumerable<Image> images)
        {
            foreach (var image in images)
            {
                var pathToFile = Path.Combine(pathToDirectory, image.Name);
                File.Delete(pathToFile);
            }

            return Task.CompletedTask;
        }

        public IEnumerable<IFormFile> SanitazeImages(IEnumerable<IFormFile> images)
        {
            var result = new List<IFormFile>();
            foreach (var image in images)
            {
                foreach (var allowedType in allowedTypes)
                {
                    if (image.FileName.EndsWith(allowedType))
                    {
                        result.Add(image);
                    }
                }
            }

            return result;
        }
    }
}