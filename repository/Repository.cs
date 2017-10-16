using System;
using System.Collections.Generic;
using System.Linq;
using data;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get (long id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.Deleted = false;
            entity.AddedDate = DateTime.UtcNow;
            entities.Add(entity);
            SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.ModifiedDate = DateTime.UtcNow;
            SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.Deleted = true;
            entity.ModifiedDate = DateTime.UtcNow;
            SaveChanges();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}