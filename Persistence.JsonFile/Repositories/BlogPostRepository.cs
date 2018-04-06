using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using System.Linq;

namespace Persistence.JsonFile.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(IDataFileProvider dataFileProvider) : base(dataFileProvider) { }

        public Guid Add(BlogPost entity)
        {
            return AddEntity(entity);
        }

        public BlogPost Get(Guid? id)
        {
            return Entities.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<BlogPost> GetAll()
        {
            return GetAllEntities();
        }
    }
}
