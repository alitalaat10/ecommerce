using firstCoreapp.Data;
using firstCoreapp.Models;
using firstCoreapp.Repository.Base;

namespace firstCoreapp.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext db) 
        {
            //_db = db;
            categories = new MainRepository<category>(db);
            items = new MainRepository<item>(db);
            employees = new EmpRepo(db);  
            

        }

        //private readonly ApplicationDbContext _db;

        public IRepository<category> categories {  get; private set; }

        public IRepository<item> items { get; private set; }

        public IEmpRepo employees { get; private set; }

        //public int commitChanges()
        //{
        //    return _db.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    _db.Dispose();
        //}
    }
}
