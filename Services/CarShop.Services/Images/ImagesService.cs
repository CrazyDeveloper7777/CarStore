using CarShop.Data.Common.Repositories;
using CarShop.Data.Models.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Images
{
    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public ImagesService(IDeletableEntityRepository<Image> imagesRepository)
        {
            this.imagesRepository = imagesRepository;
        }

        public async Task DeleteAllByAdIdAsync(string id)
        {
            var images = this.imagesRepository.All().Where(i => i.AdId == id);

            foreach (var image in images)
            {
                this.imagesRepository.Delete(image);
            }

            await this.imagesRepository.SaveChangesAsync();
        }
    }
}
