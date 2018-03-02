using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using empty.Models;

namespace empty.Controllers.Extensions
{
    public static class BlogPostExtensions
    {
        public static BlogPostViewModel ToViewModel(this BlogPost post)
        {
            return post != null
                ? new BlogPostViewModel
                {
                    Id = post.Id,
                    Content = post.Content,
                    Created = post.Created,
                    Title = post.Title
                }
                : new BlogPostViewModel();
        }
    }
}
