using Castle.Core.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Shopify_Image_App.Application.ImageRepo;
using Shopify_Image_App.Controllers;
using Shopify_Image_App.Models;
using Shopify_Image_App.ViewModels.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Shopify_Image_App.XUnitTest
{
    public class HomeControllerTests
    {
      
        [Fact]
        public async Task Index_ReturnsViewResult_WithListViewModelObject()
        {
            // Arrange
            string searchText = "";
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object,
                null, null, null, null, null, null, null, null);
            var mockRepo = new Mock<IImageRepository>();
            HomeController controller = new HomeController(userManager.Object, mockRepo.Object);

            // Act
            var result = await controller.Index(searchText);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ListViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task SpecificUser_ReturnsViewResult_WithListViewModelObject()
        {
            // Arrange
            string userId = "b1e5d1d3-d341-4e86-a73e-f47f658d00f7";
            var fakeUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Manar"),
                new Claim("Id", "b1e5d1d3-d341-4e86-a73e-f47f658d00f7")
            }
            , "mock"));
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object,
                null, null, null, null, null, null, null, null);
            var mockRepo = new Mock<IImageRepository>();
            HomeController controller = new HomeController(userManager.Object, mockRepo.Object);
            controller.ViewData["UserName"] = "Manar";
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = fakeUser }
            };
            

            // Act
            var result = await controller.SpecificUser(userId, "Manar");
            

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ListViewModel>(viewResult.ViewData.Model);
            Assert.NotNull(controller.ViewData);
        }

        [Fact]
        public async Task UserImages_ReturnsViewResult_WithUserImagesViewModelObject()
        {
            // Arrange
            var fakeUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] 
            {
                new Claim(ClaimTypes.Name, "Manar"),
                new Claim("Id", "b1e5d1d3-d341-4e86-a73e-f47f658d00f7")
            }
            , "mock"));
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object,
                null, null, null, null, null, null, null, null);
            var mockRepo = new Mock<IImageRepository>();
            HomeController controller = new HomeController(userManager.Object, mockRepo.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = fakeUser }
            };
            
            // Act
            var result = await controller.UserImages();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<UserImagesViewModel>(viewResult.ViewData.Model);
        }


        [Fact]
        public async Task UserImagesPost_ReturnsViewResult_WithUserImagesViewModelObject()
        {
            // Arrange
            var fakeUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Manar"),
                new Claim("Id", "b1e5d1d3-d341-4e86-a73e-f47f658d00f7")
            }
            , "mock"));
            var image = new Image() { Id = 1, ImageName = "testImage" };
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object,
                null, null, null, null, null, null, null, null);
            var mockRepo = new Mock<IImageRepository>();
            mockRepo.Setup(x => x.AddImage(image)).Returns(Task.CompletedTask).Verifiable();
            HomeController controller = new HomeController(userManager.Object, mockRepo.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = fakeUser }
            };

            // Act
            var result = await controller.UserImages();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<UserImagesViewModel>(viewResult.ViewData.Model);
        }


        [Fact]
        public async Task Delete_ReturnsRedirectToPage_WithUserId()
        {
            // Arrange
            var fakeUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Manar"),
                new Claim("Id", "b1e5d1d3-d341-4e86-a73e-f47f658d00f7")
            }
            , "mock"));
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object,
                null, null, null, null, null, null, null, null);
            var mockRepo = new Mock<IImageRepository>();
            mockRepo.Setup(x => x.DeleteImage(2)).Returns(Task.CompletedTask).Verifiable();
            HomeController controller = new HomeController(userManager.Object, mockRepo.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = fakeUser }
            };

            // Act
            var result = await controller.Delete(2);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
