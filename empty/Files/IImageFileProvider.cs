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
        void SaveBlogImage(int blogPostId, IFormFile imageFile);
    }

    public class ImageFileProvider : IImageFileProvider
    {
        private IFileProvider _fileProvider;

        public ImageFileProvider(IHostingEnvironment env)
        {
            string root = Path.Combine(env.WebRootPath, "images");
            _fileProvider = new PhysicalFileProvider(root);
        }

        public async void SaveBlogImage(int blogPostId, IFormFile imageFile)
        {   
            string directoryName = Path.Combine("blogPosts", $"{blogPostId}");
            CreateIfNotExists(directoryName);
            await SaveImageAsync(directoryName, imageFile);
        }

        private async Task SaveImageAsync(string directoryName, IFormFile imageFile)
        {
            string fileName = Path.GetFileName(imageFile.FileName);
            string fullFileName = Path.Combine(directoryName, fileName);
            using (var stream = new FileStream(fullFileName, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
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
