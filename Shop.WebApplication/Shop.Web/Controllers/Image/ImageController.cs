using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;
using Shop.Business.Services;

namespace Shop.Web.Controllers.Image
{
    public class ImageController : Controller
    {
        private ImageService _imageService = new ImageService();

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