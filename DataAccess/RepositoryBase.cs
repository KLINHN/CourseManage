using Microsoft.EntityFrameworkCore;
using BusinessData.Models;
using System;
using System.Linq;

namespace Repository
{
    public class RepositoryBase<T> where T : class
    {
        private readonly CourseManageContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(CourseManageContext context)
        {
            _context = new CourseManageContext  ();
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {

            return _dbSet;
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            //_dbSet.Update(entity);
            _context.SaveChanges();
        }
        public T getById(object id)
        {
            return _dbSet.Find(id);
        }
    }
}
