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
            if (post == null)
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPostViewModel model)
        {
            var post = Map(model);
            _unitOfWork.BlogPosts.Add(post);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Details), new { post.Id });
        }

        [HttpPost("addphoto/{id}")]
        public IActionResult AddPhoto(int id, IFormFile photo)
        {
            _imageFileProvider.SaveBlogImage(id, photo);
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

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BlogPostViewModel model)
        {            
            var post = _unitOfWork.BlogPosts.Get(model.Id);
            post.Content = model.Content;            
            post.Title = model.Title;            
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Details), new { post.Id });
        }

        #endregion

        private BlogPost Map(BlogPostViewModel post)
        {
            return new BlogPost
            {
                Id = post.Id,
                Content = post.Content,
                Created = post.Created,
                Title = post.Title
            };
        }
    }
}
