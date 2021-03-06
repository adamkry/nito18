﻿using System;

namespace Domain
{
    public class BlogPost : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }
    }
}
