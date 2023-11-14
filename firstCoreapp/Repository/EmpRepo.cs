using firstCoreapp.Data;
using firstCoreapp.Models;
using firstCoreapp.Repository.Base;

namespace firstCoreapp.Repository
{
    public class EmpRepo : MainRepository<Employee>, IEmpRepo
    {
        public EmpRepo(ApplicationDbContext db) : base(db)
        {
        }

        public int getsalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void paySalaryRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
