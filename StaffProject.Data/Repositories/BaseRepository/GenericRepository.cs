using StaffProject.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffProject.Data.Repositories.BaseRepository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected readonly StaffDbContext dbContext;
        private bool disposed;

        public GenericRepository(StaffDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = dbContext.Set<Entity>().Find(id);
            dbContext.Set<Entity>().Remove(entity);
        }

        public List<Entity> GetAll()
        {
            return dbContext.Set<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            return dbContext.Set<Entity>().Find(id);
        }

        public void Insert(Entity entity)
        {
           entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.UtcNow);
           entity.GetType().GetProperty("CreatedBy").SetValue(entity, Environment.MachineName);

            dbContext.Set<Entity>().Add(entity);
        }

        public void Update(Entity entity)
        {
            entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.UtcNow);
            entity.GetType().GetProperty("CreatedBy").SetValue(entity, Environment.MachineName);
            dbContext.Set<Entity>().Update(entity);
        }


        public void Complete()
        {
            dbContext.SaveChanges();
        }


        private void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }

            disposed = true;
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            Clean(true);
        }
    }
}
