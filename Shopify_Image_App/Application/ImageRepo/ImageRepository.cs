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

        public async Task<List<Image>> GetAllImages(string searchText)
        {

            List<Image> images = null;

            if (string.IsNullOrEmpty(searchText))
            {
                images = await _context.Images
                                    .Include(x => x.ApplicationUser)
                                    .OrderByDescending(x => x.CreatedOn)
                                    .ToListAsync();
            } else
            {
                images = await _context.Images
                                    .Include(x => x.ApplicationUser)
                                    .Where(x => x.ImageName.ToLower()
                                    .Contains(searchText.ToLower()))
                                    .OrderByDescending(x => x.CreatedOn)
                                    .ToListAsync();
            }

            return images;
        }

        public async Task<List<Image>> GetImagesByUser(string userId)
        {
            if (userId == null)
            {
                throw new Exception("No user ID provided");
            } else
            {
                List<Image> images = await _context.Images
                                            .Where(x => x.ApplicationUserId == userId)
                                            .OrderByDescending(x => x.CreatedOn)
                                            .Select(x => x)
                                            .ToListAsync();

                return images;
            }
        }

        public async Task<Image> GetImage(int imageId)
        {
            var image = await _context.Images.Where(x => x.Id == imageId).FirstOrDefaultAsync();

            if (image == null)
            {
                throw new Exception("No image found under the provided ID");
            }

            return image;
        }

        public async Task AddImage(Image newImage)
        {
            await _context.Images.AddAsync(newImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(int imageId)
        {
            Image image = await _context.Images.FindAsync(imageId);

            if (image == null)
            {
                throw new Exception("No image found under the provided image ID");
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }
    }
}
