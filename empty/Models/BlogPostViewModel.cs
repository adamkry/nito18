﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empty.Models
{
    public class CreateBlogPostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string TextContent { get; set; } 
        public string Styles { get; set; }       
    }
    
    public class BlogPostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string TextContent { get; set; }
        public DateTime Created { get; set; }
        public string MainPhotoName { get; set; }
        public string Styles { get; set; }
    }
}
