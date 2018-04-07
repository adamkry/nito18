using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Files
{
    public interface IImageFileProvider
    {
        Task<string> SaveBlogImageAsync(Guid blogPostId, IFormFile imageFile);
    }

    public class ImageFileProvider : IImageFileProvider
    {
        private string root;

        public ImageFileProvider(IHostingEnvironment env)
        {
            root = Path.Combine(env.WebRootPath, "images");
        }

        public async Task<string> SaveBlogImageAsync(Guid blogPostId, IFormFile imageFile)
        {
            string directoryName = Path.Combine(root, "blogPosts", $"{blogPostId}");
            CreateIfNotExists(directoryName);
            var fileName = await SaveImageAsync(directoryName, imageFile);
            return fileName;
        }

        private async Task<string> SaveImageAsync(string directoryName, IFormFile imageFile)
        {
            string fileName = Path.GetFileName(imageFile.FileName);
            string fullFileName = Path.Combine(directoryName, fileName);
            using (var stream = new FileStream(fullFileName, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return fileName;
        }

        private void CreateIfNotExists(string directoryName)
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }
    }
}
