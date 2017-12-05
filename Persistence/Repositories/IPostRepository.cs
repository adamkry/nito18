using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public interface IBlogPostRepository : IGetRepository<BlogPost>, IGetAllRepository<BlogPost>, IAddRepository<BlogPost>
    {
    }
}
