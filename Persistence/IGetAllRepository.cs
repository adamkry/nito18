using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IGetAllRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
    }
}
