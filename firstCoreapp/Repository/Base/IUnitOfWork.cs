using firstCoreapp.Models;

namespace firstCoreapp.Repository.Base
{
    public interface IUnitOfWork /*:IDisposable*/
    {

        IRepository<category> categories { get; }
        IRepository<item> items { get; }
        IEmpRepo employees { get; }

        //int commitChanges();
    }
}
