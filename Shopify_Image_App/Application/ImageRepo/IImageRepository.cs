using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify_Image_App.Models;

namespace Shopify_Image_App.Application.ImageRepo
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllImages();
        Task<Image> GetImage(int imageId);
        Task AddImage(Image newImage);
        Task DeleteImage(int imageId);
    }
}
