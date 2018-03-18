using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Models
{
    public class HomeViewModel
    {
        public NewsCarouselViewModel News { get; set; } = new NewsCarouselViewModel();
        public AllBlogPostsViewModel BlogPosts { get; set; } = new AllBlogPostsViewModel();
    }
}
