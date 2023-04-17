using OnlineOrdersManagement.Infrastructure.Interfaces;
using OnlineOrdersManagement.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace OnlineOrdersManagement.Services
{
    internal class DbRepository<T> : IRepository<T> where T : class
    {
        private readonly OnlineOrdersDBEntities _db;
        private readonly DbSet<T> _set;

        public DbRepository(OnlineOrdersDBEntities db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _set;

        public T Add(T item) 
        { 
            if(item is null) throw new ArgumentNullException(nameof(item));
            
            _db.Entry(item).State = EntityState.Added;           
            _db.SaveChanges();

            return item;
        }

        public void Delete(T item)
        {
            _db.Entry(item).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public void Update(T item, int id)
        {
            T oldEntity = _set.Find(id);
            _db.Entry(oldEntity).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
