using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify_Image_App.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        [Required(ErrorMessage = "Image name is required.")]
        [StringLength(20, ErrorMessage = "Image name cannot be more than 20 characters long.")]
        public string ImageName { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreatedOn { get; set; }

        public Image()
        {
            this.CreatedOn = DateTime.Now;
        }
    }
}
