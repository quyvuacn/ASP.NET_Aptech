using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopASP.Features;
using ShopASP.Features.Models;


namespace ShopASP.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(FileModel image)
        {
            var ActionUpload = FileAction.Upload(image,"wwwroot/front/images/products");
            if(ActionUpload.Completed) { 
                string fileName = ActionUpload.Result;
                TempData["Message"] = $"{fileName} upload thành công";
            }
            else
            {
                string error = ActionUpload.Result;
                TempData["Message"] = $"Lỗi : {error}";
            }
            
            return RedirectToAction("Index", "Upload");
        }
    }
}
