using firstCoreapp.Data;
using firstCoreapp.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace firstCoreapp.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(ApplicationDbContext db) {
            _db = db;
        }
        private readonly ApplicationDbContext _db;
        public T Find(int id)
        { 
        return _db.Set<T>().Find(id);
        }

        public T selectone(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().SingleOrDefault(predicate);
        }
        public IEnumerable<T> FindAll()
        {
        return _db.Set<T>().ToList();
                
        }
        

        public async Task<T> FindAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAll(params string[] eagers)
        {
            IQueryable<T> query = _db.Set<T>();
            if(eagers.Length > 0)
            {
                foreach(string eager in eagers)
                {
                    query = query.Include(eager);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] eagers)
        {
            IQueryable<T> query = _db.Set<T>();
            if (eagers.Length > 0)
            {
                foreach (string eager in eagers)
                {
                    query = query.Include(eager);
                }
            }
            return await query.ToListAsync();
        }

        public void Addone(T myItem)
        {
            _db.Set<T>().Add(myItem);
            _db.SaveChanges();
        }

        public void UpdateOne(T myItem)
        {
            _db.Set<T>().Update(myItem);
            _db.SaveChanges();
        }

        public void DeleteOne(T myItem)
        {
            _db.Set<T>().Remove(myItem);
            _db.SaveChanges();
        }

        public void AddMany(IEnumerable<T> myItem)
        {
            _db.Set<T>().AddRange(myItem);
            _db.SaveChanges();
        }

        public void UpdateMany(IEnumerable<T> myItem)
        {
            _db.Set<T>().UpdateRange(myItem);
            _db.SaveChanges();
        }

        public void DeleteMany(IEnumerable<T> myItem)
        {
            _db.Set<T>().RemoveRange(myItem);
            _db.SaveChanges();
        }
    }
}
