using Domain;
using empty.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using empty.Controllers.Extensions;
using Microsoft.AspNetCore.Http;
using empty.Files;

namespace empty.Controllers
{
    [Route("artykuly")]
    public class BlogPostController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IImageFileProvider _imageFileProvider;

        public BlogPostController(IUnitOfWork unitOfWork, IImageFileProvider imageFileProvider)
        {
            _unitOfWork = unitOfWork;
            _imageFileProvider = imageFileProvider;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _unitOfWork.BlogPosts.GetAll() ?? new List<BlogPost>();
            posts = posts.Where(p => p.IsDeleted != true);
            var result = new AllBlogPostsViewModel
            {
                BlogPosts = posts
                    .OrderByDescending(p => p.Created)
                    .Select(p => p.ToViewModel())
                    .ToList()
            };
            return View("ShowAll", result);
        }

        [HttpGet("{id}")]
        public IActionResult Details(Guid? id)
        {            
            if (!id.HasValue)
            {
                return NotFound();
            }
            var post = _unitOfWork.BlogPosts.Get(id);
            if (post == null || post.IsDeleted == true)
            {
                return NotFound();
            }
            return View(post.ToViewModel());
        }

        #region Create

        [HttpGet("nowy")]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost("nowy")]
        public IActionResult Create([FromBody] CreateBlogPostViewModel model)
        {
            var post = new BlogPost
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                Styles = model.Styles,
                TextContent = model.TextContent,
                Created = DateTime.Now
            };
            _unitOfWork.BlogPosts.Add(post);
            _unitOfWork.Complete();
            return Content($"{post.Id}");
        }

        [HttpPost("addphoto/{id}")]
        public async Task<IActionResult> AddPhoto(Guid id, IFormFile photo)
        {            
            if (photo == null) {
                return NoContent();
            }
            var post = _unitOfWork.BlogPosts.Get(id);
            
            var fileName = await _imageFileProvider.SaveBlogImageAsync(id, photo);
            if (String.IsNullOrWhiteSpace(post.MainPhotoName))
            {
                post.MainPhotoName = fileName;
            }
            _unitOfWork.Complete();
            return Ok();
        }

        #endregion

        #region Update

        [HttpGet("/nowy/{id}")]
        public IActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var post = _unitOfWork.BlogPosts.Get(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post.ToViewModel());
        }

        [HttpGet("renew/{id}")]        
        public IActionResult Renew(Guid id)
        {            
            var post = _unitOfWork.BlogPosts.Get(id);
            if (post != null)
            {
                post.IsDeleted = false;
                _unitOfWork.Complete();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var post = _unitOfWork.BlogPosts.Get(id);
            if (post != null)
            {
                post.IsDeleted = true;
                _unitOfWork.Complete();
            } 
            return Ok();
        }

        #endregion

        private BlogPost Map(BlogPostViewModel post)
        {
            return new BlogPost
            {
                Id = post.Id,
                Content = post.Content,
                TextContent = post.TextContent ?? post.Content,
                Styles = post.Styles,
                Created = post.Created,
                Title = post.Title
            };
        }
    }
}
