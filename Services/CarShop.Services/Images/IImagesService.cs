using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Images
{
    public interface IImagesService
    {
        Task DeleteAllByAdIdAsync(string id);
    }
}
