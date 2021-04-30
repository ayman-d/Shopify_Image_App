using Microsoft.EntityFrameworkCore;
using Shopify_Image_App.Data;
using Shopify_Image_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify_Image_App.Application.ImageRepo
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _context;

        public ImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddImage(Image newImage)
        {
            await _context.Images.AddAsync(newImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(int imageId)
        {
            Image image = await _context.Images.FindAsync(imageId);

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            var images = _context.Images
                                    .Select(x => x)
                                    .Include(x => x.ApplicationUser);

            return await images.ToListAsync();
        }

        public async Task<Image> GetImage(int imageId)
        {
            return await _context.Images.Where(x => x.Id == imageId).FirstOrDefaultAsync();
        }
    }
}
