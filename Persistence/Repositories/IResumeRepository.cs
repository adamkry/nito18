using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public interface IResumeRepository : IAddRepository<Resume>, IGetRepository<Resume>, IGetAllRepository<Resume>
    {

    }
}
