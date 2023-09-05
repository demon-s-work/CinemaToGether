using System.Runtime.InteropServices;
using CinameToGether.Dal.Context;
using CinameToGether.Dal.Models;
using Microsoft.EntityFrameworkCore;
namespace CinameToGether.Dal.Repositories
{
    public class BaseRepository<TEntity> where TEntity : DbModel
    {
        private DbContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository()
        {
            _context = new ApplicationDbContext();
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity? Get(string id)
        {
            return _dbSet.FirstOrDefault(e => e.Id == id);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }
    }
}