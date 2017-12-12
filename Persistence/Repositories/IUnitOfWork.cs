using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogPostRepository BlogPosts { get; } 

        IResumeRepository Resume { get; }
        int Complete();
    }
}
