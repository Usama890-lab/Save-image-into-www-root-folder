using LearnASPNETCoreMVCWithRealApps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LearnASPNETCoreMVCWithRealApps.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View("Index", new Product());
        }


        [Route("save")]
        [HttpPost]
        public IActionResult Save(Product product, IFormFile[] photos)
        {
            if (photos == null || photos.Length == 0)
            {
                return Content("File(s) not selected");
            }
            else
            {
                product.Photos = new List<string>();
                foreach (IFormFile photo in photos)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    photo.CopyToAsync(stream);
                    product.Photos.Add(photo.FileName);
                }
            }
            ViewBag.product = product;
            return View("Success");
        }

    }
}