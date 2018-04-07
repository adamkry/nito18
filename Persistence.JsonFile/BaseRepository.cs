﻿using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Persistence.JsonFile
{
    public abstract class BaseRepository<T> where T : IEntity
    {
        IDataFileProvider _dataFileProvider;

        private IList<T> entities;
        protected IList<T> Entities { get { return entities ?? (entities = GetEntities()); } }

        private IList<T> GetEntities()
        {
            var data = _dataFileProvider.GetFileText(typeof(T).Name);
            return JsonConvert.DeserializeObject<IList<T>>(data) ?? new List<T>();
        }

        public BaseRepository(IDataFileProvider dataFileProvider)
        {
            _dataFileProvider = dataFileProvider;
        }

        protected IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            return Entities.Where(predicate);
        }

        protected Guid AddEntity(T entity)
        {       
            if (entity.Id == Guid.Empty) {
                entity.Id = Guid.NewGuid();    
            }
            Entities.Add(entity);
            return entity.Id;
        }

        protected T GetEntity(Guid? id)
        {
            return Entities.SingleOrDefault(e => e.Id == id);
        }

        protected IEnumerable<T> GetAllEntities()
        {
            return Entities;
        }
    }
}
