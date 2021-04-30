using Microsoft.AspNetCore.Http;
using Shopify_Image_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify_Image_App.ViewModels.Images
{
    public class UserImagesViewModel
    {
        public string Path { get; set; }
        [Required(ErrorMessage = "Image name is required.")]
        [StringLength(20, ErrorMessage = "Image name cannot be more than 20 characters long.")]
        public string ImageName { get; set; }
        [Required(ErrorMessage = "Image file is required.")]
        public IFormFile ImageFile { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
