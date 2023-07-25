using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly NewShopContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            _dbContext = new NewShopContext();
            _dbSet = _dbContext.Set<T>();
        }

        public GenericRepository(NewShopContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Delete(object id)
        {
            T exist = _dbSet.Find(id);
            if (exist != null)
            {
                _dbSet.Remove(exist);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);

        }

        public void Insert(T obj)
        {
            _dbSet.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Update(T obj)
        {
            _dbSet.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
