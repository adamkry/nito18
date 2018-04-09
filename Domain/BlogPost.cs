using System;

namespace Domain
{
    public class BlogPost : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string TextContent { get; set; }

        public string Styles { get; set; }

        public DateTime Created { get; set; }

        public string MainPhotoName { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
