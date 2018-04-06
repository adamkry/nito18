using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IAddRepository<T> where T : IEntity
    {
        Guid Add(T entity);
    }
}
