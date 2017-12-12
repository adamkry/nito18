using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.JsonFile.Repositories
{
    public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
    {
        public ResumeRepository(IDataFileProvider dataFileProvider) : base(dataFileProvider)
        {
        }

        public int Add(Resume entity)
        {
            return AddEntity(entity);
        }

        public Resume Get(int? id)
        {            
            //There will be only one resume for now
            return GetAll().SingleOrDefault();
        }

        public IEnumerable<Resume> GetAll()
        {
            return GetAllEntities();
        }
    }
}
