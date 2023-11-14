using firstCoreapp.Models;

namespace firstCoreapp.Repository.Base
{
    public interface IEmpRepo : IRepository<Employee>
    {
        public int getsalary(Employee employee);
        public void paySalaryRoll(Employee employee);
    }
}
