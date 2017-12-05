using Domain;
using Newtonsoft.Json;
using Persistence.JsonFile.Repositories;
using Persistence.Repositories;
using System;

namespace Persistence.JsonFile
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBlogPostRepository BlogPosts { get; }

        private IDataFileProvider _dataFileProvider;

        public UnitOfWork(IDataFileProvider dataFileProvider)
        {
            _dataFileProvider = dataFileProvider;
            BlogPosts = new BlogPostRepository(dataFileProvider);
        }

        public int Complete()
        {
            SaveToFile(BlogPosts);
            return 1;
        }

        private bool SaveToFile<T>(IGetAllRepository<T> entities) where T : IEntity
        {
            var data = JsonConvert.SerializeObject(entities.GetAll());
            return _dataFileProvider.UpdateFileText(typeof(T).Name, data);
        }

        public void Dispose()
        {
            
        }
    }
}
