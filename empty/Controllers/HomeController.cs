using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using empty.Controllers.Extensions;
using Microsoft.AspNetCore.Mvc;
using empty.Models;
using Persistence.Repositories;

namespace empty.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<BlogPost> blogPosts = _unitOfWork.BlogPosts.GetAll().ToList();
            if (blogPosts?.Count > 3)
            {
                blogPosts = blogPosts.Take(3).ToList();
            }

            var resultPosts = blogPosts.Select(bp => bp.ToViewModel()).ToList();

            var result = new HomeViewModel
            {
                BlogPosts = resultPosts
            };
            return View(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
