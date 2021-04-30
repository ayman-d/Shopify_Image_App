using Shopify_Image_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify_Image_App.ViewModels.Images
{
    public class ListViewModel
    {
        public IEnumerable<Image> Images { get; set; }
    }
}
