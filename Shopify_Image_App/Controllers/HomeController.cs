using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopify_Image_App.Application.ImageRepo;
using Shopify_Image_App.Models;
using Shopify_Image_App.ViewModels.Images;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify_Image_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageRepository _imageRepository;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            IImageRepository imageRepository
            )
        {
            _userManager = userManager;
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchText)
        {
            ViewData["searchText"] = searchText;

            List<Image> images = await _imageRepository.GetAllImages(searchText);

            ListViewModel model = new ListViewModel()
            {
                Images = images
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> SpecificUser(string userId, string userName)
        {
            

            List<Image> images = await _imageRepository.GetImagesByUser(userId);
            ListViewModel model = new ListViewModel()
            {
                Images = images
            };

            //var user = _userManager.FindByIdAsync(userId);
            ViewData["UserName"] = userName;

            return View(model);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UserImages()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            try
            {
                UserImagesViewModel model = new UserImagesViewModel()
                {
                    Images = await _imageRepository.GetImagesByUser(userId)
                };
                return View(model);
            }
            catch (Exception e)
            {
                return View("~/Views/Shared/ErrorPage.cshtml", e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserImages(UserImagesViewModel model)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {

                string uniqueFileName = null;

                string uploadFolder = Path.Combine("wwwroot", "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }

                Image newImage = new Image
                {
                    Path = filePath,
                    ImageName = model.ImageName,
                    ApplicationUserId = userId
                };

                await _imageRepository.AddImage(newImage);
            }

            model.Images = await _imageRepository.GetImagesByUser(userId);

            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> Delete(int imageId)
        {
            try
            {
                Image image = await _imageRepository.GetImage(imageId);

                var userId = _userManager.GetUserId(HttpContext.User);

                if (userId != image.ApplicationUserId)
                {
                    return RedirectToAction("Index", "Home");
                }

                System.IO.File.Delete(image.Path);

                await _imageRepository.DeleteImage(imageId);

                return RedirectToAction("UserImages", "Home", userId);
            }
            catch (Exception e)
            {
                return View("~/Views/Shared/ErrorPage.cshtml", e.Message);
            }
        }


        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
