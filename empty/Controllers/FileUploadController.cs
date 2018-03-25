using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace empty.Controllers
{    
    public class FileUploadController : Controller
    {
        private IHostingEnvironment _env;
        public FileUploadController(IHostingEnvironment env)
        {
            this._env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile[] files)
        {
            if (files == null || files.Length == 0)
            {
                return Content("File not selected");
            }

            // var tempPath = Path.GetTempFileName();
            var dir = _env.ContentRootPath + "\\userUploads\\";

            foreach (var file in files)
            {
                using (var stream = new FileStream(dir + file.FileName, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            
            return Ok();
        }
    }
}