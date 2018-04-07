using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IRemoveRepository<T> where T : IEntity
    {
        void Remove(T entity);
    }
}
