using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IGetRepository<T> where T: IEntity
    {
        T Get(int? id);
    }
}
