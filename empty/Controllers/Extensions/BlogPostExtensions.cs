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
                    TextContent = post.TextContent ?? post.Content,
                    Styles = post.Styles,
                    Created = post.Created,
                    Title = post.Title,
                    MainPhotoName = post.MainPhotoName
                }
                : new BlogPostViewModel();
        }
    }
}
