using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Models
{
    public class HomeViewModel
    {
        public List<BlogPostViewModel> BlogPosts { get; set; } = new List<BlogPostViewModel>();
    }
}
