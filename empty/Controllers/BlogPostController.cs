using Domain;
using empty.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Controllers
{
    public class BlogPostController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public BlogPostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("artykul/{id}")]
        [HttpGet]
        public IActionResult Details(int? id)
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
            return View(Map(post));
        }

        #region Create

        [Route("artykul/nowy")]
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        [Route("artykul/nowy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPostViewModel model)
        {
            var post = Map(model);
            _unitOfWork.BlogPosts.Add(post);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Details), new { post.Id });
        }

        #endregion

        #region Update

        [Route("artykul/{id}/edytuj")]
        [HttpGet]
        public IActionResult Edit(int? id)
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
            return View(Map(post));
        }

        [Route("artykul/{id}/edytuj")]
        [HttpPost]
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

        private BlogPostViewModel Map(BlogPost post)
        {
            return new BlogPostViewModel
            {
                Id = post.Id,
                Content = post.Content,
                Created = post.Created,
                Title = post.Title
            };
        }

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
