using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;
using Shop.Business.Services;
using Shop.Business.Services.Interfaces;

namespace Shop.Web.Controllers
{
    public class ImageController : Controller
    {
        private IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            this._imageService = imageService;
        }

        public ActionResult ShowTestImages()
        {
            return View(
                new ImageViewModel
                {
                    Images = _imageService.GetAllByUserId(1)
                });
        }
    }
}